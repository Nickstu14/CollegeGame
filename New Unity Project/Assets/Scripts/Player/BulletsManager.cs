using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsManager : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject m_Spawn;
    public GameObject m_Bullet;
    
    [Space(2)][Header("Bullets")][Range(1, 100)]
    public int m_MaxBullet;
    public List<GameObject> m_BulletList;
    private int m_BulletCount;
    [Space(2)]
    [Header("Individual Bullets")]
    [Range(0.1f, 10f)]
    public float m_BulletDuration;
    [Range(100f, 10000f)]
    public float m_BulletSpeed;

    // Use this for initialization
    void Start()
    {
        m_BulletList = new List<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //on click  shoot
        if (Input.GetMouseButton(0))//Input.GetMouseButtonDown(0))
        {
            if (/*m_BulletList.Count*/ m_Spawn.transform.childCount< m_MaxBullet)
            {
                /*GameObject m_BulletInstance = Instantiate(m_Bullet, m_Spawn.transform.position, new Quaternion(90.0f, 0.0f, 0.0f, 0.0f));
                m_BulletInstance.GetComponent<Rigidbody>().AddForce(m_Spawn.transform.forward * m_BulletSpeed);
                m_BulletInstance.transform.parent = m_Spawn.transform;*/
                //m_BulletList.Add(m_BulletInstance);
                //Debug.Log(m_Spawn.transform.childCount);
            }
        }

        /*m_BulletCount = 0;
        if (m_BulletList.Count != 0)
        {
            foreach (GameObject m_B in m_BulletList)
            {
                if (m_B.GetComponent<BulletControll>().GetTime() >= m_BulletDuration)
                {
                    m_B.GetComponent<BulletControll>().SetDelete();
                    m_BulletList.RemoveAt(0);
                    // Debug.Log("Destroyed");
                }
                m_BulletCount++;
            }
        }*/
    }
}
