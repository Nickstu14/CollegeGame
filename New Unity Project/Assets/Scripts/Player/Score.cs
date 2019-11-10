using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Score : MonoBehaviour
{
    public GameObject m_Canvas;
    public Text m_Text;
    public int m_Score;
    public string m_ScoreString;
    // Start is called before the first frame update
    void Start()
    {
        m_ScoreString = "Score: ";
        m_Score = 0;
        m_Canvas = GameObject.FindGameObjectWithTag("Canvas");
        m_Text = m_Canvas.GetComponentInChildren<Text>();
        
    }

    private void LateUpdate()
    {
        m_Text.text = "Score: " + m_Score;
    }



    // Update is called once per frame
    public void UpdateScore(int _Val)
    {
        m_Score += _Val;
        //m_UIText.GetComponentInChildren<TextField>().text = m_ScoreString + m_Score ;

    }
}
