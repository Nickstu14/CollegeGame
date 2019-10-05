using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    [SerializeField]
    NoiseMapGeneration m_NoiseMapGeneration;

    [SerializeField]
    private MeshRenderer m_TileRenderer;

    [SerializeField]
    private MeshFilter m_MeshFilter;

    [SerializeField]
    private MeshCollider m_MeshCollider;

    [SerializeField]
    private float m_MapScale;

    [SerializeField]
    private float m_HeightMultiplier;

    [SerializeField]
    private TerrainType[] m_TerrainTypes;

    [SerializeField]
    private AnimationCurve m_HeightCurve;

    [SerializeField]
    private NoiseMapGeneration.Wave[] m_Waves;

    [SerializeField]
    private TerrainType[] m_HeightTerrainTypes;

    [SerializeField]
    private TerrainType[] m_HeatTerrainTypes;

    [SerializeField]
    private VisualizationMode m_VisualizationMode;


    // Start is called before the first frame update
    void Start()
    {
        m_NoiseMapGeneration = gameObject.GetComponent<NoiseMapGeneration>();
        m_TileRenderer = gameObject.GetComponent<MeshRenderer>();
        m_MeshFilter = gameObject.GetComponent<MeshFilter>();
        m_MeshCollider = gameObject.GetComponent<MeshCollider>();

        GenerateTile(10f,11f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateTile(float _CenterVertexZ, float _MaxDistanceZ)
    {
        Vector3[] m_MeshVertices = this.m_MeshFilter.mesh.vertices;

        int m_TileDepth = (int)Mathf.Sqrt(m_MeshVertices.Length);
        int m_TileWidth = (int)Mathf.Sqrt(m_MeshVertices.Length);

        float m_OffsetX = -this.gameObject.transform.position.x;
        float m_OffsetZ = -this.gameObject.transform.position.z;

        float[,] m_HeightMap = this.m_NoiseMapGeneration.GeneratePerlinNoiseMap(m_TileDepth, m_TileWidth, this.m_MapScale, m_OffsetX, m_OffsetZ, m_Waves);

        Vector3 m_TileDimensions = this.m_MeshFilter.mesh.bounds.size;
        float m_DistanceBetweenVertices = m_TileDimensions.z / (float)m_TileDepth;
        float m_VertexOffsetZ = this.gameObject.transform.position.z / m_DistanceBetweenVertices;

        //Generate heatmap
        float[,] m_UniformHeatMap = this.m_NoiseMapGeneration.GenerateUniformNoiseMap(m_TileDepth, m_TileWidth, _CenterVertexZ, _MaxDistanceZ, m_VertexOffsetZ);

        float[,] m_RandomHeatMap = this.m_NoiseMapGeneration.GeneratePerlinNoiseMap(m_TileDepth, m_TileWidth, this.m_MapScale, _OffsetX, _OffsetZ, this.m_HeatWaves)


        Texture2D m_HeightTexture = BuildTexture(m_HeightMap, this.m_HeightTerrainTypes);
        Texture2D m_HeatTexture = BuildTexture(m_HeatMap, this.m_HeatTerrainTypes);

        //Texture2D m_TileTexture = BuildTexture(m_HeightMap);
        //this.m_TileRenderer.material.mainTexture = m_TileTexture;

        switch(this.m_VisualizationMode)
        {
            case VisualizationMode.Height: this.m_TileRenderer.material.mainTexture = m_HeightTexture;
                break;
            case VisualizationMode.Heat: this.m_TileRenderer.material.mainTexture = m_HeatTexture;
                break;
        }
        
        UpdateMeshVertices(m_HeightMap);

    }

    enum VisualizationMode
    {
        Height,
        Heat
    }

    private Texture2D BuildTexture(float[,] _HeightMap, TerrainType[] _TerrainType)
    {
        int m_TileDepth = _HeightMap.GetLength(0);
        int m_TileWidth = _HeightMap.GetLength(1);

        Color[] m_ColorMap = new Color[m_TileDepth * m_TileWidth];
        for (int m_Z = 0; m_Z < m_TileDepth; m_Z++)
        {
            for (int m_X = 0; m_X < m_TileWidth; m_X++)
            {
                // transform the 2D map index is an Array index
                int m_ColorIndex = m_Z * m_TileWidth + m_X;
                float m_Height = _HeightMap[m_Z, m_X];
                TerrainType m_TerrainType = ChooseTerrainType(m_Height, _TerrainType);
                // assign as color a shade of grey proportional to the height value
                m_ColorMap[m_ColorIndex] = m_TerrainType.m_Colour; //Color.Lerp(Color.black, Color.white, m_Height);
            }
        }
        // create a new texture and set its pixel colors
        Texture2D m_TileTexture = new Texture2D(m_TileWidth, m_TileDepth);
        m_TileTexture.wrapMode = TextureWrapMode.Clamp;
        m_TileTexture.SetPixels(m_ColorMap);
        m_TileTexture.Apply();

        return m_TileTexture;
    }
    TerrainType ChooseTerrainType(float _Height, TerrainType[] _TerrainTypes)
    {
        // for each terrain type, check if the height is lower than the one for the terrain type
        foreach (TerrainType terrainType in m_TerrainTypes)
        {
            // return the first terrain type whose height is higher than the generated one
            if (_Height < terrainType.m_Height)
            {
                return terrainType;
            }
        }
        return m_TerrainTypes[m_TerrainTypes.Length - 1];
    }
    private void UpdateMeshVertices(float[,] _HeightMap)
    {
        int m_TileDepth = _HeightMap.GetLength(0);
        int m_TtileWidth = _HeightMap.GetLength(1);

        Vector3[] m_meshVertices = this.m_MeshFilter.mesh.vertices;

        // iterate through all the heightMap coordinates, updating the vertex index
        int m_VertexIndex = 0;
        for (int m_Z = 0; m_Z < m_TileDepth; m_Z++)
        {
            for (int m_X = 0; m_X < m_TtileWidth; m_X++)
            {
                float m_Height = _HeightMap[m_Z, m_X];

                Vector3 m_Vertex = m_meshVertices[m_VertexIndex];
                // change the vertex Y coordinate, proportional to the height value
                m_meshVertices[m_VertexIndex] = new Vector3(m_Vertex.x, this.m_HeightCurve.Evaluate(m_Height) * this.m_HeightMultiplier, m_Vertex.z);

                m_VertexIndex++;
            }
        }

        // update the vertices in the mesh and update its properties
        this.m_MeshFilter.mesh.vertices = m_meshVertices;
        this.m_MeshFilter.mesh.RecalculateBounds();
        this.m_MeshFilter.mesh.RecalculateNormals();
        // update the mesh collider
        this.m_MeshCollider.sharedMesh = this.m_MeshFilter.mesh;
    }


    [System.Serializable]
    public class TerrainType
    {
        public string m_Name;
        public float m_Height;
        public Color m_Colour;
    }

}

