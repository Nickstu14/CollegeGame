using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public Collider m_Collider;
    public CoinCollect m_Coin;
    public int m_CoinVal;
    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<Collider>();
        //m_Coin = GetComponentInChildren<GameObject>().GetComponent<CoinCollect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            m_CoinVal = m_Coin.GetValue();
            other.GetComponent<Score>().UpdateScore(m_CoinVal);
            m_Coin.Destroy();
            
        }
    }
}
