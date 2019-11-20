using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject m_Player;
    public float m_Force;
    public float m_JumpForce;
    public bool m_Jump;
    private bool m_Stop;
    public bool m_Jumping;
    public float m_Rotate;
    private Rigidbody m_RB;
    private SphereCollider m_SC;
    private Vector2 m_Input;
    public Camera m_MainCam;
    public Camera m_GunCam;

    public Vector3 m_CamF;
    public Vector3 m_CamR;

    // Use this for initialization
    void Start()
    {
        m_RB = GetComponent<Rigidbody>();
        m_Jump = false;
        m_Stop = false;
        m_SC = GetComponent<SphereCollider>();
        if (m_SC.isTrigger == false)
        {
            m_SC.isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //get the Input from Horizontal axis

        m_Input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        m_Input = Vector2.ClampMagnitude(m_Input, 1);


        //get the Input from Vertical axis

        m_CamF = m_MainCam.transform.forward;
        m_CamR = m_MainCam.transform.right;

        m_CamF.y = 0;
        m_CamR.y = 0;
        m_CamF = m_CamF.normalized;
        m_CamR = m_CamR.normalized;

        transform.position += (m_CamF * m_Input.y + m_CamR * m_Input.x) * Time.deltaTime * m_Force;



        //jump
        /*if (Input.GetKey(KeyCode.Space))
        {
            m_RB.AddForce(transform.up * m_JumpForce);
        }*/

        //Gun Cam
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_MainCam.enabled = false;
            m_GunCam.enabled = true;
            GetComponent<MeshRenderer>().enabled = false;
            //Debug.Log("GunCam");
        }
        else
        {
            m_MainCam.enabled = true;
            m_GunCam.enabled = false;
            GetComponent<MeshRenderer>().enabled = true;
            //Debug.Log("Cam");
        }


    }

    void FixedUpdate()
    {
        if (m_Jump)
        {
            m_RB.AddForce(transform.up * m_JumpForce);
            //m_MoveDir.y = m_JumpForce;
            m_Jump = false;
            m_Jumping = true;
        }
    }
    private void JumpUpdate()
    {
        if (!m_Jump)
        {
            m_Jump = Input.GetKeyDown(KeyCode.Space);
        }
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bullet" && gameObject.tag != "Player")
            gameObject.GetComponent<Details>().ModHealth(other.GetComponent<Bullet>().GetDamage());
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Building")  // or if(gameObject.CompareTag("YourWallTag"))
        {
            print("HIT Building");
            //m_RB.velocity = Vector3.zero;
            m_Stop = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Building")  // or if(gameObject.CompareTag("YourWallTag"))
        {
            print("Move away");
            //m_RB.velocity = Vector3.zero;
            m_Stop = false;
        }
    }
}
