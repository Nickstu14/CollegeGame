using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public GameObject m_Player;
    public float m_Force;
    public float m_JumpForce;
    public bool m_Jump;
    public bool m_Jumping;
    public float m_Rotate;
    private Rigidbody m_RB;
    private SphereCollider m_SC;

    public Camera m_MainCam;
    public Camera m_GunCam;

    // Use this for initialization
    void Start()
    {
        m_RB = GetComponent<Rigidbody>();
        m_Jump = false;
        m_SC = GetComponent<SphereCollider>();
        if (m_SC.isTrigger == false)
        {
            m_SC.isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //movement
        /*if (Input.GetKey(KeyCode.W))
        {
            //m_RB.AddForce(transform.forward * m_Force);
            transform.position = new Vector3(transform.position * m_Force)
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_RB.AddForce(transform.right * m_Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_RB.AddForce(-transform.right * m_Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_RB.AddForce(-transform.forward * m_Force);
        }*/

        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        //update the position
        transform.position = transform.position + new Vector3(horizontalInput * m_Force * Time.deltaTime, 0, verticalInput * m_Force * Time.deltaTime);

        //rotation
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0.0f, -m_Rotate * Time.deltaTime, 0.0f);
            //m_RB.MoveRotation(new Quaternion(0.0f, -m_Rotate, 0.0f, 0.0f));
            //transform.Rotate(Vector3.left * Time.deltaTime * m_Rotate);

        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0.0f, m_Rotate* Time.deltaTime, 0.0f);
            //transform.Rotate(Vector3.right * Time.deltaTime * m_Rotate);
        }

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
}
