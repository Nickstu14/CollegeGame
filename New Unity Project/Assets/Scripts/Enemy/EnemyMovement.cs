using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public bool m_Delete;
    public GameObject m_Player;

    public Collider m_Temp;

    public bool m_AimAtPlayer;

    public float m_MovementDuration;
    public float m_Duration;
    public Movement m_Direction;
    public float m_Speed;
    public float m_RotateSpeed;
    public Vector3 m_EnemyTotlal;

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
        m_Duration = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Delete)
            GameObject.Destroy(gameObject);
        if (m_AimAtPlayer)
        {
            gameObject.transform.LookAt(m_Player.transform);
        }

        if ((m_Duration >= m_MovementDuration) && (!m_AimAtPlayer))
        {
            CalculateMovement();
            m_Duration = 0;
        }
        //after random duration of movement

        m_Duration += Time.deltaTime;
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
                m_MovementDuration = CalculateDuration(2.5f, 10);

            }
            else
            {
                //random 40% chance of turning
                if (Random.value > m_TurningDirection)
                {
                    //random 50% chance of turning right
                    m_Direction = Movement.RIGHT;
                    m_MovementDuration = CalculateDuration(2, 4);
                }
                else
                {
                    //random 50% chance of turning left
                    m_Direction = Movement.LEFT;
                    m_MovementDuration = CalculateDuration(2, 4);
                }
            }
        }
        else
        {
            //random 20% chance of stopping 
            m_Direction = Movement.STOP;
            m_MovementDuration = CalculateDuration(1, 5);
        }
    }

    float CalculateDuration(float _Min, float _Max)
    {
        return Random.Range(_Min, _Max);
    }

    void FixedUpdate()
    {

        switch (m_Direction)
        {
            case Movement.FOLLOW_PLAYER:
            case Movement.FORWARD:
                MoveForward(gameObject.transform.rotation.y);
                break;
            case Movement.RIGHT:
                transform.Rotate(0.0f, m_RotateSpeed * Time.deltaTime, 0.0f);
                break;
            case Movement.LEFT:
                transform.Rotate(0.0f, -m_RotateSpeed * Time.deltaTime, 0.0f);
                break;
            case Movement.STOP:
                break;

        }
    }

    public void MoveForward(float _Aim)
    {
        Vector3 m_EnemyF;
        Vector3 m_EnemyR;
        Vector2 m_Input;

        m_Input = new Vector2(0, _Aim);
        m_EnemyF = gameObject.transform.forward;
        m_EnemyR = gameObject.transform.right;

        m_EnemyF.y = 0;
        m_EnemyR.y = 0;

        m_EnemyTotlal = (m_EnemyF * m_Input.y + m_EnemyR);
        transform.position += m_EnemyTotlal * Time.deltaTime * m_Speed;//transform.position 
    }

    public void SetDelete()
    {
        m_Delete = true;
    }

    public void OnTriggerStay(Collider other)
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
        if(collision.gameObject.tag == "Bullet")
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
