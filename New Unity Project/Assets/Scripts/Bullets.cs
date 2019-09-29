using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    public GameObject m_Spawn;
    public GameObject m_Bullet;
    public float m_BulletSpeed;
    public List<GameObject> m_BulletList;
    public float m_BulletTime;
    private int m_BulletCount;
    public int m_MaxBullet;

    // Use this for initialization
    void Start()
    {
        m_BulletList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //on click  shoot
        if (Input.GetMouseButton(0))//Input.GetMouseButtonDown(0))
        {
            if (m_BulletList.Count < m_MaxBullet)
            {
                GameObject m_BulletInstance = Instantiate(m_Bullet, m_Spawn.transform.position, new Quaternion(90.0f, 0.0f, 0.0f, 0.0f));
                m_BulletInstance.GetComponent<Rigidbody>().AddForce(m_Spawn.transform.forward * m_BulletSpeed);
                //m_BulletInstance.transform.parent = m_Spawn.transform;
                m_BulletList.Add(m_BulletInstance);
                //Debug.Log("Bullet");
            }
        }

        m_BulletCount = 0;
        if (m_BulletList.Count != 0)
        {
            foreach (GameObject m_B in m_BulletList)
            {
                if (m_B.GetComponent<BulletControll>().GetTime() >= m_BulletTime)
                {
                    m_B.GetComponent<BulletControll>().SetDelete();
                    m_BulletList.RemoveAt(m_BulletCount);
                    // Debug.Log("Destroyed");
                }
                m_BulletCount++;
            }
        }
    }
}
