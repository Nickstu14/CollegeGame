using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject m_Player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject m_GO = Instantiate(m_Player, transform.position, Quaternion.identity);
    }
}