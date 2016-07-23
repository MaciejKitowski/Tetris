using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public class BlocksSerialization : MonoBehaviour {
    public struct serializedBlock {
        public bool deletable;
        public bool canRotate;

        [XmlArray("ArenaLines"), XmlArrayItem("line")]
        public string[] line;
    }

    private List<serializedBlock> blocks = new List<serializedBlock>();
    private BlocksArchitect architect;

    void Awake() {
        architect = GameObject.FindGameObjectWithTag("BlockArchitect").GetComponent<BlocksArchitect>();
        load();
    }

    public void addNewBlock() {
        serializedBlock block = new serializedBlock();

        block.deletable = true;
        block.canRotate = architect.canRotate;
        block.line = new string[6];
        for (int i = 0; i < 6; ++i) block.line[i] = "000000";

        for (int y = 0; y < 6; ++y) {
            char[] line = block.line[y].ToCharArray();
            for (int x = 0; x < 6; ++x) if (architect.tile[x, y].pressed) line[x] = '1';
            block.line[y] = new string(line);
        }

        blocks.Add(block);
    }

    public void save() {
        XmlSerializer serializer = new XmlSerializer(blocks.GetType());
        FileStream stream = new FileStream(Path.Combine(Application.persistentDataPath, "Blocks.xml"), FileMode.Create);
        serializer.Serialize(stream, blocks);
        stream.Close();
    }

    public bool[,] getConvertedTiles(int index) {
        bool[,] buffer = new bool[6, 6];

        for (int y = 0; y < 6; ++y) {
            char[] line = blocks[index].line[y].ToCharArray();

            for (int x = 0; x < 6; ++x) {
                if (line[x] == '1') buffer[x, y] = true;
                else buffer[x, y] = false;
            }
        }
        return buffer;
    }

    public int blockCount() { return blocks.Count; }
    public bool isDeletable(int blockIndex) { return blocks[blockIndex].deletable; }
    public bool isRotatable(int blockIndex) { return blocks[blockIndex].canRotate; }
    public void delete(int blockIndex) { blocks.RemoveAt(blockIndex); }

    private void load() {
        try {
            XmlSerializer serializer = new XmlSerializer(blocks.GetType());
            FileStream stream = new FileStream(Path.Combine(Application.persistentDataPath, "Blocks.xml"), FileMode.Open);
            blocks = (List<serializedBlock>)serializer.Deserialize(stream);
            stream.Close();
        }
        catch { loadFromResources(); }
    }

    private void loadFromResources() {
        XmlSerializer serializer = new XmlSerializer(blocks.GetType());
        TextAsset Block = Resources.Load("BlocksXMLPrefab") as TextAsset;

        StringReader reader = new StringReader(Block.text);
        blocks = (List<serializedBlock>)serializer.Deserialize(reader);
        save();
    }
}
