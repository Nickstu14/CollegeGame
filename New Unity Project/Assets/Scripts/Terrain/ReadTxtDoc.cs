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
    public List<string> m_Level;
    public string m_Line;
    public CityObjects[] m_City;
    public List<CityMap> m_Map;
    public CityMap m_TempMap;
    private int m_Count;


    // Start is called before the first frame update
    void Start()
    {
        m_ApplicationPath = Application.dataPath;

        if (m_FileLoc != null)
            m_File = new StreamReader(@"" + m_ApplicationPath + "\\LevelTxt\\" + LevelName +".txt");


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
            m_TempMap = new CityMap();
            m_TempMap.m_Coor.x = m_I;
            m_TempMap.m_Coor.y = _Count;
            m_TempMap.m_Character = _Line[m_I];

            if((_Line[m_I+1] == '{') && (_Line[m_I+3] == '}'))
            { //Config from anouther file
                m_I += 1;
                m_TempMap = FindConfig(m_TempMap, _Line[m_I]);
                m_I += 1;
            }
            else if(_Line[m_I+1] == '{' && _Line[m_I+3] != '}' )
            { //internal config
                CityConfig m_cityConfig = CityConfig.Rotation;
                m_I ++;
                do
                {

                    if (_Line[m_I] == '{' || _Line[m_I] == ' ')
                    { // skip if any spaces or 
                        m_I++;
                    }
                    else if (_Line[m_I] == ',')
                    {
                        m_cityConfig++;
                        m_I++;
                    }
                    else
                    {
                        switch (m_cityConfig)
                        {
                            case CityConfig.Rotation: m_TempMap.m_Rotation = _Line[m_I];
                                break;
                            //case CityConfig.Scale: m_TempMap.m_Scale = _Line[m_I];
                             //   break;
                            case CityConfig.Colour:
                                m_TempMap = GetColour(m_TempMap ,_Line, m_I);
                                break;
                        }
                        m_I++;
                    }

                } while (_Line[m_I] == '}');
            }
            else
            {
                //default config
            }
            m_Map.Add(m_TempMap);

            print(_Line[m_I]);
        }
    }
    CityMap FindConfig(CityMap _Data, char _Value)
    {


        return _Data;
    }

    CityMap GetColour(CityMap _Data, string _Line, int _Value)
    {


        return _Data;
    }

    
   /* Vector3 GetScale()
    {

    }*/


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
    private enum CityConfig
    {
        Rotation = 1,
       // Scale = 2,
        Colour
    }

}


