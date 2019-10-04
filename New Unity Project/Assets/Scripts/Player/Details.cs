using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Details : MonoBehaviour
{
    public string m_ForeName;
    public string m_SureName;
    public string m_Title;
    public bool m_Player;
    public int m_Health;

    // Start is called before the first frame update
    void Start()
    {
        if (m_Player)
        {
            SetName("Mr", "Tic", " Tac");
            SetHealth(100);
        }
        else
        {
            SetName("Mr", "Enemy");
            SetHealth(10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Health <= 0)
            GameObject.Destroy(gameObject);
    }
    public void SetName(string _title = "Mr", string _Forename = "", string _Surename = "")
    {
        m_Title = _title;
        m_ForeName = _Forename;
        m_SureName = _Surename;
    }

    public string GetName()
    {
        return m_Title + " " + m_ForeName + " " + m_SureName;
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
