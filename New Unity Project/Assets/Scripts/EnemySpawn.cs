using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Spawning Area")]
    public GameObject m_SpawnLoc;
    public float m_SpawnWidth;
    public Vector3 m_SpawnPos;
    [Header("Player")]
    public GameObject m_Player;
    public SphereCollider m_PlayerSphere;

    [Header("Map Dims")]
    public float m_Width;
    public float m_Length;

    [Space(2)]
    [Header("Enemies")]
    public int m_EnemyCap;

    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.Find("Player");
        m_PlayerSphere = m_Player.GetComponent<SphereCollider>();

        if (m_Width == 0.0f)
            m_Width = 10f;
        if (m_Length == 0.0f)
            m_Length = 10f;

        //Get spawner gameobject
        m_SpawnLoc = this.gameObject;
        //calculate spawner location which will be outside the radius of the player
        m_SpawnPos = new Vector3(0, 0, 0);
        //set spawning position
        m_SpawnLoc.transform.position = m_SpawnPos;

        //get the spawning radius to spawn in enemies
        m_SpawnWidth = m_SpawnLoc.GetComponent<SphereCollider>().radius;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
