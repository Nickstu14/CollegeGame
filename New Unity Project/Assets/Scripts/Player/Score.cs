using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;




public class Score : MonoBehaviour
{
    public Canvas m_UIText;
    public TextField m_Text;
    public int m_Score;
    public string m_ScoreString;
    // Start is called before the first frame update
    void Start()
    {
        m_ScoreString = "Score: ";
        m_Score = 0;
        
    }



    // Update is called once per frame
   public void UpdateScore(int _Val)
    {
        m_Score += _Val;
        //m_UIText.GetComponentInChildren<TextField>().text = m_ScoreString + m_Score ;

    }
}
