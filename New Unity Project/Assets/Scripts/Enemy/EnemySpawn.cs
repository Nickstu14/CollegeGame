using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Spawning Area")]
    public GameObject m_SpawnLoc;
    public float m_SpawnRadius;
    public Vector3 m_SpawnPos;
    private SphereCollider m_SC;

    [Header("Player")]
   // public GameObject m_Player;
   // public SphereCollider m_PlayerSphere;
    //public float m_PlayerRadus;

    [Header("Map Dims")]
    public float m_Width;
    public float m_Length;
    private float m_Min = 0;

    [Space(2)]
    [Header("Enemies")]
    public GameObject m_EnemyPrefab;
    public Vector3 m_Eneypos;
    public List<GameObject> m_Enemies;
    [Range(1,5)]
    public int m_EnemyCap;


    // Start is called before the first frame update
    void Start()
    {
       // m_Player = GameObject.Find("Player");
       // m_PlayerSphere = m_Player.GetComponent<SphereCollider>();
       // m_PlayerRadus = m_PlayerSphere.radius;

        if (m_Width == 0.0f)
            m_Width = 5f;
        if (m_Length == 0.0f)
            m_Length = 5f;

        //Get spawner gameobject
        m_SpawnLoc = this.gameObject;
        //calculate spawner location which will be outside the radius of the player
        m_SpawnPos = new Vector3(0, 0, 0);
        //set spawning position
        m_SpawnLoc.transform.position = m_SpawnLoc.transform.position; //CalculateEnemySpawnPos();

        //get the spawning radius to spawn in enemies
        m_SC = m_SpawnLoc.GetComponent<SphereCollider>();
        m_SpawnRadius = m_SC.radius;
       
        if (m_SC.isTrigger == false)
        {
            m_SC.isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (m_Enemies.Count == 0)
        {   
            if(m_EnemyPrefab == null)
            {
                Debug.Log("No Enemy prefab");
                return;
            }
            for (int m_I = m_Enemies.Count; m_I < m_EnemyCap; m_I ++)
            {
                GameObject m_EnemyInstance = Instantiate(m_EnemyPrefab, CalculateEnemyPos(), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                m_EnemyInstance.transform.parent = this.gameObject.transform;
                m_Enemies.Add(m_EnemyInstance);
            }
        }
    }

    Vector3 CalculateEnemySpawnPos()
    {
       Vector3 m_Loc = new Vector3();

        //m_Loc.x = Random.Range((m_Player.transform.position.x - m_PlayerRadus) - m_Min, (m_Player.transform.position.x + m_PlayerRadus) + m_Length);
        //m_Loc.z = Random.Range((m_Player.transform.position.z - m_PlayerRadus) - m_Min, (m_Player.transform.position.z + m_PlayerRadus) + m_Width);
        //m_Loc.y = m_Player.transform.position.y;

        return m_Loc;
    }

    Vector3 CalculateEnemyPos()
    {
        Vector3 m_Loc = new Vector3();

        m_Loc.x = Random.Range((m_SpawnLoc.transform.position.x - m_SpawnRadius), (m_SpawnLoc.transform.position.x + m_SpawnRadius));
        m_Loc.z = Random.Range((m_SpawnLoc.transform.position.z - m_SpawnRadius), (m_SpawnLoc.transform.position.z + m_SpawnRadius));
        m_Loc.y = m_SpawnLoc.transform.position.y;

        return m_Loc;
    }


}
