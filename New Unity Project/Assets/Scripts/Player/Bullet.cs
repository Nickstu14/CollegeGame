using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public bool m_Delete;

    public float m_Time;
    public int m_Damage;
    public float m_TimeAlive;
    public BulletsManager m_BM;
   
    // Use this for initialization
    void Start()
    {
        m_Damage = 10;
        m_BM = GetComponentInParent<BulletsManager>();
        m_TimeAlive = m_BM.m_BulletDuration;
        
       // m_Pos = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Delete)
            GameObject.Destroy(gameObject);

        m_Time += 1.0F * Time.deltaTime;

        if (m_Time >= m_TimeAlive)
            SetDelete();
        //m_Pos.Add(gameObject.transform.position);
    }

    public float GetTime()
    {
        return m_Time;
    }

    public void SetDelete()
    {
        m_BM.BulletDeleted();
        m_Delete = true;
    }

    public int GetDamage()
    {
        return m_Damage;
    }
}
