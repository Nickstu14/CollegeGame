using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGen : MonoBehaviour
{
    public string m_Seed;
    public int m_SeedLength;
    /*
        Seed will work in HEX each number of letter will represent something.
        if letter is greter then G then by default letter will be G as highest.
        Seed will be 8 long currently, default will be all 0
    */

    // Use this for initialization
    void Start()
    {
        
        if (m_Seed.Length < m_SeedLength)
        {
            for (int m_I=m_Seed.Length;m_I < m_SeedLength; m_I++)
            {
                m_Seed += "0";
            }
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
