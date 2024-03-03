using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class TerrainGenerator : MonoBehaviour
{
    public int xVertices = 250;
    public int yVertices = 250;
    public float width = 10000.0f;
    public float height = 10000.0f;
    public float noiseScale = 0.001f;
    public float amplitude = 75.0f;
    public float frequency = 100.0f;
    public float minHeight = -10000.0f;
    public float maxHeight = 10000.0f;
    public bool normalizeHeight = true;
    private Vector3[] vertices;
    private Mesh mesh;

    void Awake()
    { 
        this.vertices = new Vector3[(this.xVertices + 1) * (this.yVertices + 1)];
        this.Generate();
    }

    public void Generate()
    {
        this.mesh = new Mesh();
        this.mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        this.gameObject.GetComponent<MeshFilter>().mesh = this.mesh;
        this.mesh.name = "PCG Terrain";

        this.vertices = new Vector3[(this.xVertices + 1) * (this.yVertices + 1)];
        var uv = new Vector2[this.vertices.Length];

        var noiseMap = this.PerlinNoiseMap(this.noiseScale);

        for (int i = 0, y = 0; y <= this.yVertices; y++)
        {
            for (int x = 0; x <= this.xVertices; x++, i++)
            {
                var vpos = new Vector3(
                    (float)x * this.width / (float)this.xVertices, 
                    (float)y * this.height / (float)this.yVertices, 
                    (float)noiseMap[i]);
                
                this.vertices[i] = vpos;
                uv[i] = new Vector2((float)x / (float)this.xVertices, (float)y / (float)this.yVertices);
            }
        }

        this.mesh.vertices = this.vertices;
        this.mesh.uv = uv;

        int[] triangles = new int[this.xVertices * this.yVertices * 6];
        for (int ti = 0, vi = 0, y = 0; y < this.yVertices; y++, vi++)
        {
            for (int x = 0; x < this.xVertices; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + this.xVertices + 1;
                triangles[ti + 5] = vi + this.xVertices + 2;
            }
        }
        
        this.mesh.triangles = triangles;
        this.mesh.RecalculateNormals();
    }

    private float[] PerlinNoiseMap(float scale = 0.001f)
    { 
        var noiseMap = new float[(this.xVertices + 1) * (this.yVertices + 1)];
        var min = float.MaxValue;
        var max = float.MinValue;

        for (int y = 0, i = 0; y <= this.yVertices; y++)
        {
            for (var x = 0; x <= this.xVertices; x++, i++)
            {
                float value = Mathf.PerlinNoise((float)x * scale * this.frequency, (float)y * scale * this.frequency);
                noiseMap[i] = Mathf.Clamp(value, this.minHeight, this.maxHeight);
                if(value < min)
                {
                    min = value;
                }
                if(value > max)
                {
                    max = value;
                }
            }
        }

        for (var i = 0; i < noiseMap.Length; ++i)
        {
            if (this.normalizeHeight)
            {
                noiseMap[i] = this.amplitude * (noiseMap[i] - min) / (max - min);
            }
            else
            {
                noiseMap[i] = this.amplitude * noiseMap[i];
            }
        }

        return noiseMap;
    }

    public void ChangeTerrainHeight(Vector3 worldPosition, float amount)
    {
        //determine the vertex number
        var localPosition = this.transform.InverseTransformPoint(worldPosition);
        float xv =  localPosition.x / ((float)this.width / ((float)this.xVertices));
        float yv = localPosition.y / ((float)this.height / ((float)this.yVertices));
        int vertexIndex = Mathf.RoundToInt(xv) + Mathf.RoundToInt(yv) * (this.xVertices+1);

        //flip the amount to match our flipped z-coords
        if(vertexIndex < this.vertices.Length) { 
            this.vertices[vertexIndex].z += -amount;
            this.mesh.vertices = this.vertices;
        }
    }
}
