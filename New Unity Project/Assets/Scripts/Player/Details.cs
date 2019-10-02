using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Details : MonoBehaviour
{
    public string m_Name;
    public bool m_Player;
    public int m_Health;

    // Start is called before the first frame update
    void Start()
    {
        if (m_Player)
        {
            SetName("Tic Tac");
            SetHealth(100);
        }
        else
        {
            SetName("Enemy");
            SetHealth(10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Health <= 0)
            GameObject.Destroy(gameObject);
    }
    public void SetName(string _Name)
    {
        m_Name =  "Enemy";
    }

    public string GetName()
    {
        return m_Name;
    }

    public void SetHealth(int _Health)
    {
        m_Health = _Health;
    }
    public int GetHealth()
    {
        return m_Health;
    }
    public void ModHealth(int _Damage)
    {
        m_Health = GetHealth() - _Damage;
    }



}
