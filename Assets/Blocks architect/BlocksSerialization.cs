using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public class BlocksSerialization : MonoBehaviour {
    public BlocksArchitect architect;

    public struct serializedBlock {
        public bool canRotate;

        [XmlArray("ArenaLines"), XmlArrayItem("line")]
        public string[] line;
    }

    public List<serializedBlock> blocks = new List<serializedBlock>();

    void Awake() {
        architect = FindObjectOfType<BlocksArchitect>();
        load();
    }

    public void addNewBlock() {
        serializedBlock block = new serializedBlock();

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
