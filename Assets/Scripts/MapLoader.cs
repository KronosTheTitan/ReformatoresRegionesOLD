using System.Collections;
using System.Collections.Generic;
using GameWorld;
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

    Vector3[] _vertices;
    int[] _triangles;
    Vector2[] _uvs;

    Mesh _mesh;

    void Start()
    {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
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
                    province.id = p;
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
        _vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float scaleFactor = 8;
                float y = heightData.GetPixel(x * (int)scaleFactor, z *(int)scaleFactor).grayscale * 10;
                Debug.Log(y);
                _vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        _triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                _triangles[tris + 0] = vert + 0;
                _triangles[tris + 1] = vert + xSize + 1;
                _triangles[tris + 2] = vert + 1;
                _triangles[tris + 3] = vert + 1;
                _triangles[tris + 4] = vert + xSize + 1;
                _triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        _uvs = new Vector2[_vertices.Length];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                _uvs[i] = new Vector2((float)x / xSize, (float)z / zSize);
                i++;
            }
        }

        _mesh.Clear();
        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;
        _mesh.uv = _uvs;
        _mesh.RecalculateNormals();
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
        foreach (Vector3 vector3 in _vertices)
            Gizmos.DrawSphere(vector3, .1f);
    }
}
