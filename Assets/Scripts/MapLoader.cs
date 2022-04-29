using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
public class MapLoader : MonoBehaviour
{
    [SerializeField]
    Texture2D provinceData;

    [SerializeField]
    Texture2D heightData;

    [SerializeField]
    int xSize;

    [SerializeField]
    int zSize;

    Vector3[] vertices;
    int[] triangles;
    Vector2[] uvs;

    Mesh mesh;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        //LoadMap();
        Debug.Log("test");
        CreateMapMesh();
    }
    public void LoadMap()
    {
        if(provinceData == null)
        {
            Debug.LogError("no image added");
        }
        List<Color> usedColors = new List<Color>();
        List<Province> provinces = new List<Province>();
        for(int x = 0, p = 0; x < provinceData.width; x++)
        {
            for(int y = 0; x < provinceData.height; y++)
            {
                Color color = provinceData.GetPixel(x, y);
                if (!ContainsColor(usedColors,color))
                {
                    usedColors.Add(color);
                    GameObject gameObject = Instantiate<GameObject>(new GameObject());
                    Province province = gameObject.AddComponent<Province>();
                    province.ID = p;
                    provinces.Add(province);
                    p++;
                }
                else
                    Debug.Log("There is a duplicate color");
            }
        }
        Debug.Log("done");
    }
    void CreateMapMesh()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float scaleFactor = 8;
                float y = heightData.GetPixel(x * (int)scaleFactor, z *(int)scaleFactor).grayscale * 10;
                Debug.Log(y);
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        uvs = new Vector2[vertices.Length];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                uvs[i] = new Vector2((float)x / xSize, (float)z / zSize);
                i++;
            }
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
    }

    bool ContainsColor(List<Color> list, Color color)
    {
        foreach(Color listColor in list)
        {
            if (ColorUtility.ToHtmlStringRGB(color) == ColorUtility.ToHtmlStringRGB(listColor))
                return true;
        }
        return false;
    }
    private void OnDrawGizmosSelected()
    {
        foreach (Vector3 vector3 in vertices)
            Gizmos.DrawSphere(vector3, .1f);
    }
}
