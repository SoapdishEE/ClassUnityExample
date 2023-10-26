using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using UnityEditor.U2D.Sprites;

public class TextureManager : MonoBehaviour
{
    [SerializeField] private Texture2D mTextureFile = null;
    [SerializeField] private TextAsset mAtlasFile = null;

    private TextureData[] mAtlas;

    public static TextureManager Instance { get { return sInstance; } }

    private static TextureManager sInstance;

    private void Awake()
    {
        if(sInstance != null && sInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            sInstance = this;
        }

        DontDestroyOnLoad(this.gameObject);
        var textData = mAtlasFile.text;
        ParseXML(textData);
    }

    private void ParseXML(string xmlData)
    {
        var xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(xmlData));
        var xmlPathPattern = "//atlas/image";
        var nodeList = xmlDoc.SelectNodes(xmlPathPattern);
        mAtlas = new TextureData[nodeList.Count];
        var counter = 0;

        foreach (XmlNode node in nodeList )
        {
            mAtlas[counter] = ParseNode(node);
            counter++;
        }
    }

    private TextureData ParseNode(XmlNode node)
    {
        var nameNode = node.FirstChild;
        var xNode = nameNode.NextSibling;
        var yNode = xNode.NextSibling;
        var widthNode = yNode.NextSibling;
        var heightNode = widthNode.NextSibling;

        TextureData data;
        data.name = nameNode.InnerXml;
        data.x = int.Parse(xNode.InnerXml);
        data.y = int.Parse(yNode.InnerXml);
        data.width = int.Parse(widthNode.InnerXml);
        data.height = int.Parse(heightNode.InnerXml);

        data.x /= mTextureFile.width;
        data.y /= mTextureFile.height;
        data.width /= mTextureFile.width;
        data.height /= mTextureFile.height;

        return data;
    }

    public TextureData GetTexture(string name)
    {
        foreach(TextureData data in mAtlas)
        {
            if(data.name == name)
            {
                return data;
            }
        }

        return new TextureData();
    }
}
