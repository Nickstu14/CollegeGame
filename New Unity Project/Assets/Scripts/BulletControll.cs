using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControll : MonoBehaviour
{

    public bool m_Delete;

    public float m_Time;
    //public float m_BulletDuration;
    //public List<Vector3> m_Pos = new List<Vector3>();
    // Use this for initialization
    void Start()
    {
       // m_Pos = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Delete)
            GameObject.Destroy(gameObject);

        m_Time += 1.0F * Time.deltaTime;

        //m_Pos.Add(gameObject.transform.position);
    }

    public float GetTime()
    {
        return m_Time;
    }

    public void SetDelete()
    {
        m_Delete = true;
    }
}
