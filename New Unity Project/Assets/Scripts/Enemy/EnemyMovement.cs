using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public bool m_Delete;
    public GameObject m_Player;

    public Collider m_Temp;

    public bool m_AimAtPlayer;

    private float m_MovementDuration;
    private float m_Duration;
    public Movement m_Direction;
    public float m_Speed;
    public float m_RotateSpeed;

    [Header("Movement %")]
    [Range(0.1f, 1.0f)]
    public float m_Moving;
    [Range(0.1f, 1.0f)]
    public float m_Forward;
    [Range(0.1f, 1.0f)]
    public float m_TurningDirection;


    // Start is called before the first frame update
    void Start()
    {
        m_AimAtPlayer = false;
        CalculateMovement();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Delete)
            GameObject.Destroy(gameObject);
        if (m_AimAtPlayer)
        {
            gameObject.transform.LookAt(m_Player.transform);
            transform.position += Vector3.forward * Time.deltaTime * m_Speed;
        }

        if ((m_Duration >= m_MovementDuration)&&(!m_AimAtPlayer))
        {
            CalculateMovement();
        }
        //after random duration of movement
            

    }

    void CalculateMovement()
    {

        //Calculate direction
        //random 80% chance of moving 
        if (Random.value > m_Moving)
        {
            if (Random.value > m_Forward)
            {
                //random 60% chance of moving forward
                m_Direction = Movement.FORWARD;

            }
            else
            {
                //random 40% chance of turning
                if (Random.value > m_TurningDirection)
                {
                    //random 50% chance of turning right
                    m_Direction = Movement.RIGHT;
                }
                else
                {
                    //random 50% chance of turning left
                    m_Direction = Movement.LEFT;
                }
            }
        }
        else
        {
            //random 20% chance of stopping 
            m_Direction = Movement.STOP;
        }

        //Calculate random movement duration
        CalculateDuration();
    }

    void CalculateDuration()
    {

    }

    void FixedUpdate()
    {
        switch(m_Direction)
        {
            case Movement.FORWARD: transform.position += Vector3.forward * Time.deltaTime * m_Speed;//transform.position += m_Speed * Time.deltaTime;
                break;
            case Movement.RIGHT: transform.Rotate(0.0f, m_RotateSpeed * Time.deltaTime, 0.0f);
                break;
            case Movement.LEFT: transform.Rotate(0.0f, -m_RotateSpeed * Time.deltaTime, 0.0f);
                break;
            case Movement.FOLLOW_PLAYER:
                break;
            case Movement.STOP:
                break;

        }
    }

    public void SetDelete()
    {
        m_Delete = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_Player = other.gameObject;
            m_AimAtPlayer = true;
            m_Direction = Movement.FOLLOW_PLAYER;
        }
        //if (other.tag == "Bullet")
           // gameObject.GetComponent<Details>().ModHealth(other.GetComponent<BulletControll>().GetDamage());
    }
    public void OnTriggerExit(Collider other)
    {

        m_AimAtPlayer = false;
        CalculateMovement();
    }
    public void OnCollisionEnter(Collision collision)
    {
        m_Temp = collision.collider;
       // print(collision.collider.);
        gameObject.GetComponent<Details>().ModHealth(collision.gameObject.GetComponent<Bullet>().GetDamage());
    }

    public enum Movement
    {
        LEFT,
        RIGHT,
        FORWARD,
        STOP,
        FOLLOW_PLAYER
    }
    
}
