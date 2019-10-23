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
    public bool[][] m_Grid;


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

        MapNeighbour();

        SetLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ReadMap(string _Line, int _Count)
    {
        //int m_J = 0;

        for (int m_I = 0; m_I < _Line.Length; m_I++)
        {

            m_TempMap = new CityMap();
            m_TempMap.m_Coor.x = m_I;
            m_TempMap.m_Coor.y = _Count;
            m_TempMap.m_Character = _Line[m_I];

            m_TempMap.m_Colour = Color.grey;
            m_TempMap.m_Rotation = Random.Range(0, 4);

            m_Map.Add(m_TempMap);

        }
    }


    void SetLevel()
    {
        foreach (CityMap m_MO in m_Map)
        {
            GameObject m_Level = Instantiate(GetObject(m_MO.m_Character), new Vector3(m_MO.m_Coor.x * m_Offset, 0, m_MO.m_Coor.y * m_Offset), GetRotation(m_MO.m_Rotation), transform.parent);
        }

    }

    //int SetRotation()
    //{

    //}

    void MapNeighbour()
    {
        for (int m_I = 0; m_I < m_Map.Count; m_I++)
        {
            //North
            if (!((m_Map[m_I].m_Coor.y - 1) <= -1))
            {//If north of the cell is not less than 0
                m_Map[m_I].m_Neighbour[0] = FindNeighbourCharacter(new Vector2(m_Map[m_I].m_Coor.x, m_Map[m_I].m_Coor.y - 1));
            }
            else
            {
                m_Map[m_I].m_Neighbour[0] = '#';
            }
            //East
            if (!((m_Map[m_I].m_Coor.x + 1) >= GetRowWidth((int)m_Map[m_I].m_Coor.y)+1))
            {//If east of the cell is greater than the width of that row
                m_Map[m_I].m_Neighbour[1] = FindNeighbourCharacter(new Vector2(m_Map[m_I].m_Coor.x+1, m_Map[m_I].m_Coor.y));
            }
            else
            {
                m_Map[m_I].m_Neighbour[1] = '#';
            }
            //South
            if (!((m_Map[m_I].m_Coor.y + 1) <= GetRowLength() +1))
            {//If south of the cell is greater than the max number of rows
                m_Map[m_I].m_Neighbour[2] = FindNeighbourCharacter(new Vector2(m_Map[m_I].m_Coor.x, m_Map[m_I].m_Coor.y +1));
            }
            else
            {
                m_Map[m_I].m_Neighbour[2] = '#';
            }
            //West
            if (!((m_Map[m_I].m_Coor.x - 1) <= -1))
            {//If west of the cell is not less than 0
                m_Map[m_I].m_Neighbour[3] = FindNeighbourCharacter(new Vector2(m_Map[m_I].m_Coor.x - 1, m_Map[m_I].m_Coor.y));
            }
            else
            {
                m_Map[m_I].m_Neighbour[3] = '#';
            }
        }
    }

    int GetRowWidth(int _Row)
    {
        int m_TempVal = 0;

        foreach (CityMap m_CM in m_Map)
        {
            if (m_CM.m_Coor.y == _Row)
            {
                if (m_TempVal >= m_CM.m_Coor.x)
                {
                    m_TempVal = (int)m_CM.m_Coor.x;
                }

            }
        }
        return m_TempVal;
    }
    int GetRowLength()
    {
        int m_TempVal = 0;

        foreach (CityMap m_CM in m_Map)
        {
            if (m_TempVal >= m_CM.m_Coor.y)
            {
                m_TempVal = (int)m_CM.m_Coor.y;
            }
        }
        return m_TempVal;
    }

    char FindNeighbourCharacter(Vector2 _Coords)
    {
        foreach (CityMap m_CM in m_Map)
        {
            if ((m_CM.m_Coor.x == _Coords.x) && (m_CM.m_Coor.y == _Coords.y))
            {
                return m_CM.m_Character;
            }
        }
        return '~';
    }


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
        //m_Neighbour will hold the character 
        //of it's neightbour otherwise hold # as empty or out of map
        public char[] m_Neighbour = new char[4];
    }
    private enum CityConfig
    {
        Rotation = 1,
        // Scale = 2,
        Colour
    }

}


