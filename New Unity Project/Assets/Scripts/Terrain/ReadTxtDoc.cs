using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadTxtDoc : MonoBehaviour
{
    public StreamReader m_File;
    public string LevelName;
    public string m_FileLoc;
    public string m_ApplicationPath;
    private List<string> m_Level;
    private string m_Line;
    public CityObjects[] m_City;
    public List<CityMap> m_Map;
    private CityMap m_TempMap;
    private int m_Count;
    public float m_Offset;


    // Start is called before the first frame update
    void Start()
    {
        m_ApplicationPath = Application.dataPath;

        if (m_FileLoc != null)
            m_File = new StreamReader(@"" + m_ApplicationPath + "\\LevelTxt\\" + LevelName + ".txt");


        m_Level = new List<string>();

        while ((m_Line = m_File.ReadLine()) != null)
        {
            m_Level.Add(m_Line);
            ReadMap(m_Line, m_Count);
            m_Count++;
        }
        m_File.Close();

        SetLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ReadMap(string _Line, int _Count)
    {
        int m_J = 0;

        for (int m_I = 0; m_I < _Line.Length; m_I++)
        {
            m_J = m_I;
            m_TempMap = new CityMap();
            m_TempMap.m_Coor.x = m_J;
            m_TempMap.m_Coor.y = _Count;
            m_TempMap.m_Character = _Line[m_I];

            m_J++;

            //if (m_I+1 < _Line.Length)
            //{
            //    if ((_Line[m_I +1] == '{') && (_Line[m_I + 3] == '}'))
            //    { //Config from anouther file
            //        m_I++;
            //        m_TempMap = FindConfig(m_TempMap, _Line[m_I + 1]);
            //        m_I++;
            //    }
            //    else if (_Line[m_I+1] == '{' && _Line[m_I + 3] != '}')
            //    { //internal config
            //        CityConfig m_cityConfig = CityConfig.Rotation;
            //        m_I++;
            //        do
            //        {

            //            if (_Line[m_I] == '{' || _Line[m_I] == ' ')
            //            { // skip if any spaces or 
            //                m_I++;
            //            }
            //            else if (_Line[m_I] == ',')
            //            {
            //                m_cityConfig++;
            //                m_I++;
            //            }
            //            else
            //            {
            //                switch (m_cityConfig)
            //                {
            //                    case CityConfig.Rotation:
            //                        m_TempMap.m_Rotation = _Line[m_I];
            //                        break;
            //                    //case CityConfig.Scale: m_TempMap.m_Scale = _Line[m_I];
            //                    //   break;
            //                    case CityConfig.Colour:
            //                        m_TempMap = GetColour(m_TempMap, _Line, m_I);
            //                        break;
            //                }
            //                m_I++;
            //            }

            //        } while (_Line[m_I] != '}');
            //    }
            //    else
            //    {
            //        //default config
            //        m_TempMap.m_Colour = Color.grey;
            //        m_TempMap.m_Rotation = Random.Range(0, 4);
            //    }
            //}
            //else
            //{
                //default config
                m_TempMap.m_Colour = Color.grey;
                m_TempMap.m_Rotation = Random.Range(0, 4);
            //}
            m_Map.Add(m_TempMap);

        }
    }
    CityMap FindConfig(CityMap _Data, char _Value)
    {


        return _Data;
    }

    CityMap GetColour(CityMap _Data, string _Line, int _Value)
    {
        //string m_Colour;
        //string m_Value;

        if (_Line[_Value + 1] == '[')
        { //[255,255,255]
            do
            {

                _Value++;
            } while (_Line[_Value] != ']');
        }
        else
        {//colour


            do
            {
                // m_Value += _Line[_Value];

                _Value++;
            } while (_Line[_Value] != ',');

        }

        return _Data;
    }


    void SetLevel()
    {
        foreach (CityMap m_MO in m_Map)
        {
            GameObject m_Level = Instantiate(GetObject(m_MO.m_Character), new Vector3(m_MO.m_Coor.x * m_Offset, 0, m_MO.m_Coor.y * m_Offset), GetRotation(m_MO.m_Rotation), transform.parent);
        }

    }
    /* Vector3 GetScale()
     {

     }*/

    GameObject GetObject(char _Character)
    {
        foreach (CityObjects m_CO in m_City)
        {
            if (m_CO.m_Character == _Character)
            {
                return m_CO.m_Object;
            }
        }
        return new GameObject();
    }
    Quaternion GetRotation(int _Val)
    {
        Quaternion m_rot = new Quaternion();

        switch (_Val)
        {
            case 0:
                m_rot = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                break;
            case 1:
                m_rot = new Quaternion(0.0f, 90f, 0.0f, 0.0f);
                break;
            case 2:
                m_rot = new Quaternion(0.0f, 180f, 0.0f, 0.0f);
                break;
            case 3:
                m_rot = new Quaternion(0.0f, 270f, 0.0f, 0.0f);
                break;
        }
        return m_rot;
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
        public int m_Rotation;
        //public Vector3 m_Scale;
        public Color m_Colour;
    }
    private enum CityConfig
    {
        Rotation = 1,
        // Scale = 2,
        Colour
    }

}


