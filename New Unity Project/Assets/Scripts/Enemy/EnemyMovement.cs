using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool m_Delete;
    public GameObject m_Player;

    public Collider m_Temp;

    public bool m_AimAtPlayer;
    // Start is called before the first frame update
    void Start()
    {
        m_AimAtPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Delete)
            GameObject.Destroy(gameObject);
        if (m_AimAtPlayer)
        {
            gameObject.transform.LookAt(m_Player.transform);
        }

    }

    public void SetDelete()
    {
        m_Delete = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_Player = other.gameObject;
            m_AimAtPlayer = true;
        }
        //if (other.tag == "Bullet")
           // gameObject.GetComponent<Details>().ModHealth(other.GetComponent<BulletControll>().GetDamage());
    }
    public void OnTriggerExit(Collider other)
    {

        m_AimAtPlayer = false;
    }
    public void OnCollisionEnter(Collision collision)
    {
        m_Temp = collision.collider;
       // print(collision.collider.);
        gameObject.GetComponent<Details>().ModHealth(collision.gameObject.GetComponent<BulletControll>().GetDamage());
    }
    
}
