using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField]
    private int mapWidthInTiles, mapDepthInTiles;

    [SerializeField]
    private GameObject m_TilePrefab;

    void Start()
    {
        GenerateMap();
    }
    // Start is called before the first frame update
    
    void Update()
    {
        
    }
    void GenerateMap()
    {
        // get the tile dimensions from the tile Prefab
        Vector3 m_TileSize = m_TilePrefab.GetComponent<MeshRenderer>().bounds.size;
        int m_TileWidth = (int)m_TileSize.x;
        int m_TileDepth = (int)m_TileSize.z;

        // for each Tile, instantiate a Tile in the correct position
        for (int m_X = 0; m_X < mapWidthInTiles; m_X++)
        {
            for (int m_Z = 0; m_Z < mapDepthInTiles; m_Z++)
            {
                // calculate the tile position based on the X and Z indices
                Vector3 m_TilePosition = new Vector3(this.gameObject.transform.position.x + m_X * m_TileWidth,
                this.gameObject.transform.position.y,
                this.gameObject.transform.position.z + m_Z * m_TileDepth);
                // instantiate a new Tile
                GameObject m_tile = Instantiate(m_TilePrefab, m_TilePosition, Quaternion.identity) as GameObject;
                m_tile.transform.parent = this.transform;
            }
        }
    }
}
