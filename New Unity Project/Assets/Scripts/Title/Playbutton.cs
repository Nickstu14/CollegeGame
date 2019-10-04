﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playbutton : MonoBehaviour
{
    public Material m_Original;
    public Material m_Hover;
    public Renderer m_Material;

    
    // Start is called before the first frame update
    void Start()
    {
        m_Material = gameObject.GetComponent<Renderer>();
        //m_Original = m_Material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        SceneManager.LoadScene(1);
    }
    public void OnMouseOver()
    {
        m_Material.material = m_Hover;
    }
    public void OnMouseExit()
    {
        m_Material.material = m_Original;
    }
}
