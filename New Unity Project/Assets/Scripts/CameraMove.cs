/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float m_Sensitivity;
    private float m_H;
    private float m_V;
    // Use this for initialization
    void Start()
    {

    }

    void FixedUpdate()
    {
        Debug.Log("Update");
        m_H = Input.GetAxis("Mouse X");
        m_V = Input.GetAxis("Mouse Y");
        transform.Rotate(-transform.up * m_H * m_Sensitivity); //use transform.Rotate(-transform.up * rotateHorizontal * sensitivity) instead if you dont want the camera to rotate around the player
        transform.Rotate(transform.right * m_V * m_Sensitivity); // again, use transform.Rotate(transform.right * rotateVertical * sensitivity) if you don't want the camera to rotate around the player
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //Mouse
    /* private Transform m_CameraTransform;
     public Transform m_Parent;

     private Vector3 m_LocalRotation;
     private Vector3 m_vec;
     private float m_CamDistance = 1.5f;

     public float m_MouseSensitivity = 4f;
     public float m_KeySpeed = 40f;
     public float m_ScrollSensitivity = 2f;
     public float m_OrbitDamp = 10f;
     public float m_ScrollDamp = 6f;
     public float m_MoveSpeed = 0.1f;

     private bool m_Panning = false;
     private bool m_Moving;
     private bool m_Debug;
     private bool m_ObjectSelect;
     private bool m_MenuScroll;

     public GameObject m_Object;

     private Camera m_Cam;

     public Vector3 m_ScreenPoint;
     public Vector3 m_Offset;
     public RaycastHit hit;
     public float m_distance;

     public LayerMask m_LayerMask;*/
    [Space(1)]
    [Header("GameObjects")]
    public Transform m_CameraTransform;
    public Transform m_Parent;

    public GameObject m_CamPivot;
    public Camera m_Cam;
    [Space(1)]
    [Header("Other")]
    public Vector3 m_LocalRotation;
    public Vector3 m_ScreenPoint;
    public Vector3 m_Offset;

    [Space(1)]
    public float m_OrbitDamp = 10f;
    public float m_MoveSpeed = 0.1f;
    public float m_CamDistance = 1.5f;


    [Space(1)][Header("Mouse Settings")]
    public float m_MouseSensitivity = 4f;
    [Header("Clamp Val")]
    public float m_YLoc = 45f;
    public float m_XLoc = 45f;
    [Header("Visability")]
    public bool m_CursorLock;
    private bool m_cursorIsLocked = true;

    // Use this for initialization
    void Start()
    {
        m_CameraTransform = this.transform;
        m_Parent = this.transform.parent;
        m_Cam = GetComponent<Camera>();

        /*m_TargetPos = transform.position;

        m_Moving = false;
        m_Debug = false;
        m_ObjectSelect = false;
        m_Object = null;*/
        // m_ModuleMenu = null;
    }



    void Update()
    {
        CursorUpdate();
        //m_ScreenPoint = m_Cam.WorldToScreenPoint(Input.mousePosition);
        //m_Offset = m_ScreenPoint - m_Cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, hit.distance));
        // Debug.Log(Input.mousePosition);


        //Moves camera around
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            m_LocalRotation.x += Input.GetAxis("Mouse X") * m_MouseSensitivity;
            m_LocalRotation.y -= Input.GetAxis("Mouse Y") * m_MouseSensitivity;
            m_LocalRotation.y = Mathf.Clamp(m_LocalRotation.y, -m_YLoc, m_YLoc);
            m_LocalRotation.x = Mathf.Clamp(m_LocalRotation.x, -m_XLoc, m_XLoc);
        }
        //Debug.Log(Input.GetAxis("Mouse X"));
        //Debug.Log(Input.GetAxis("Mouse Y"));
        Quaternion m_Qt = Quaternion.Euler(m_LocalRotation.y, m_LocalRotation.x, 0);
        m_Parent.rotation = Quaternion.Lerp(m_Parent.rotation, m_Qt, Time.deltaTime * m_OrbitDamp);

    }
    private void CursorUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            m_cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_cursorIsLocked = true;
        }

        if (m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void LateUpdate()
    {

       /* if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            m_LocalRotation.x += Input.GetAxis("Mouse X") * m_MouseSensitivity;
            m_LocalRotation.y -= Input.GetAxis("Mouse Y") * m_MouseSensitivity;

            m_LocalRotation.y = Mathf.Clamp(m_LocalRotation.y, -90f, 90f);

            Debug.Log(m_LocalRotation);
        }*/


        //keyboard input left right up and down
        /* if (Input.GetKey(KeyCode.A))
             m_LocalRotation.x += Time.deltaTime * m_KeySpeed;
         if (Input.GetKey(KeyCode.D))
             m_LocalRotation.x -= Time.deltaTime * m_KeySpeed;
         if (Input.GetKey(KeyCode.W))
         {
             m_LocalRotation.y += Time.deltaTime * m_KeySpeed;
             m_LocalRotation.y = Mathf.Clamp(m_LocalRotation.y, -90f, 90f);
         }
         if (Input.GetKey(KeyCode.S))
         {
             m_LocalRotation.y -= Time.deltaTime * m_KeySpeed;
             m_LocalRotation.y = Mathf.Clamp(m_LocalRotation.y, -90f, 90f);
         }*/



        //Mouse zoom in and out
        /* if (Input.GetAxis("Mouse ScrollWheel") != 0f && !m_MenuScroll)
         {
             float m_ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * m_ScrollSensitivity;

             m_ScrollAmount *= (m_CamDistance * 0.3f);
             m_CamDistance += m_ScrollAmount * -1f;
             m_CamDistance = Mathf.Clamp(m_CamDistance, 0.5f, 3f);
         }*/

        //Keyboard in and out
        /*if (Input.GetKey(KeyCode.Q))
        {
            float m_ScrollAmount = Time.deltaTime * m_ScrollSensitivity;

            m_ScrollAmount *= (m_CamDistance * 0.3f);
            m_CamDistance += m_ScrollAmount * -1;
            m_CamDistance = Mathf.Clamp(m_CamDistance, 0.5f, 3f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            float m_ScrollAmount = Time.deltaTime * m_ScrollSensitivity;

            m_ScrollAmount *= (m_CamDistance * 0.3f);
            m_CamDistance -= m_ScrollAmount * -1;
            m_CamDistance = Mathf.Clamp(m_CamDistance, 0.5f, 3f);
        }*/


       // Quaternion m_Qt = Quaternion.Euler(m_LocalRotation.y, m_LocalRotation.x, 0);
       // m_Parent.rotation = Quaternion.Lerp(m_Parent.rotation, m_Qt, Time.deltaTime * m_OrbitDamp);

        /*if (m_CameraTransform.localPosition.z != m_CamDistance * -1f)
        {
            m_CameraTransform.localPosition = new Vector3(0f, 0f, Mathf.Lerp(m_CameraTransform.localPosition.z, m_CamDistance * -1f, Time.deltaTime * m_ScrollDamp));
        }*/

    }

    /*public bool GetDebug()
    {
        return m_Debug;
    }*/

}

