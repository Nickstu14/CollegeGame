using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadTxtDoc : MonoBehaviour
{
    public StreamReader m_File;
    public string m_FileLoc;
    public List<string> m_Level;
    public string m_Line;
    public CityObjects[] m_City;
    public List<CityMap> m_Map;
    public CityMap m_TempMap;
    private int m_Count;

    // Start is called before the first frame update
    void Start()
    {


        if (m_FileLoc != null)
            m_File = new StreamReader(@"" + m_FileLoc);


        m_Level = new List<string>();

        while ((m_Line = m_File.ReadLine()) != null)
        {
            m_Level.Add(m_Line);
            ReadMap(m_Line, m_Count);
            m_Count++;
        }
        m_File.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ReadMap(string _Line, int _Count)
    {
        for (int m_I = 0; m_I < _Line.Length; m_I++)
        {
            m_TempMap.m_Coor.x = m_I;
            m_TempMap.m_Coor.y = _Count;
            m_TempMap.m_Character = _Line[m_I];
            m_Map.Add(m_TempMap);

            print(m_I + "," + _Count);
        }
    }


    [System.Serializable]
    public class CityObjects
    {
        public GameObject m_Object;
        public char m_Character;
    }

    [System.Serializable]
    public class CityMap
    {
        public Vector2 m_Coor;
        [Space(2)]
        public char m_Character;
        public char m_Rotation;
        public char m_Scale;
        public char m_Colour;
    }

}


