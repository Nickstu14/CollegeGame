using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monolith : MonoBehaviour
{
    public Renderer m_Monolith;
    public bool m_Bool;
    // Start is called before the first frame update
    void Start()
    {
        m_Monolith = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {

        SceneManager.LoadScene(0);
    }
}
