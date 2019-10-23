using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public int m_Value;

    public void Start()
    {
        m_Value = 5;
    }

    public int GetValue()
    {
        return m_Value;
    }

    public void Destroy()
    {
        GameObject.Destroy(gameObject);
    }
}
