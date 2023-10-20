using UnityEngine;

public struct TextureData
{
    public string name;
    public float x;
    public float y;
    public float width;
    public float height;
}

public class ShipSprite : MonoBehaviour
{
    [SerializeField] private string mImageName;
    private TextureData mData;

    private void Start()
    {
        mData = TextureManager.Instance.GetTexture(mImageName);

        var uvs = new Vector2[4];

        uvs[0].x = mData.x;
        uvs[0].y = 1 - (mData.y + mData.height);

        uvs[1].x = (mData.x + mData.width);
        uvs[1].y = 1 - (mData.y + mData.height);

        uvs[2].x = mData.x;
        uvs[2].y = 1 - mData.y;

        uvs[3].x = mData.x + mData.width;
        uvs[3].y = 1 - mData.y;

        var mesh = GetComponent<MeshFilter>().mesh;
        mesh.uv = uvs;
    }
}
