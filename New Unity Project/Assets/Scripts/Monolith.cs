using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monolith : MonoBehaviour
{
    public Material m_Monolith;
    public float m_AlphaVal;
    public bool m_Bool;
    public float fadeSpeed = 0.1f;
    // Value used to know when the enemy has been spawned
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        m_Monolith = GetComponent<Renderer>().material;
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
       
        //SetAlpha((Time.time - spawnTime) * fadeSpeed);
    }

    public void OnCollisionEnter(Collision collision)
    {

        SceneManager.LoadScene(0);
    }
    void SetAlpha(float alpha)
    {
        // Here you assign a color to the referenced material,
        // changing the color of your renderer
        Color color = m_Monolith.color;
        color.a = Mathf.Clamp(alpha, 0, 1);
        m_Monolith.color = color;
    }
}
