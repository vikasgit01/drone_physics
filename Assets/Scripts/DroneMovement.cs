using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class DroneMovement : MonoBehaviour
{

    [SerializeField] private Transform m_fRight, m_bLeft, m_bRight, m_fLeft;
    //[SerializeField] private float m_frt, m_flt, m_brt, m_blt;

    public float m_frtSpeed, m_fltSpeed, m_brtSpeed, m_bltSpeed, m_speed = 2.454f,m_sensitivity;
    private Rigidbody m_rigidbody;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        m_frtSpeed = m_fltSpeed = m_brtSpeed = m_bltSpeed = -(Physics.gravity.y/4f) * m_rigidbody.mass;
    }

    private void Update()
    {
        if (Input.GetKeyDown(GameManager.instance.upMovement)) m_speed += 0.1f;
        if (Input.GetKeyDown(GameManager.instance.downMovement)) m_speed -= 0.1f;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(0f, 4f, 0f);
            transform.rotation = Quaternion.identity;
            m_rigidbody.angularVelocity = Vector3.zero;

        }

        if (Input.GetKeyDown(GameManager.instance.forwardMovement))
        {
            m_frtSpeed -= m_sensitivity;
            m_fltSpeed -= m_sensitivity;
            m_bltSpeed += m_sensitivity;
            m_brtSpeed += m_sensitivity;
        }
        else if (Input.GetKeyDown(GameManager.instance.backwardMovement))
        {
            m_bltSpeed -= m_sensitivity;
            m_brtSpeed -= m_sensitivity;
            m_frtSpeed += m_sensitivity;
            m_fltSpeed += m_sensitivity;
        }
    }

    private void FixedUpdate()
    {
        m_rigidbody.AddForceAtPosition(m_fRight.up * m_frtSpeed, m_fRight.position, ForceMode.Acceleration);
        m_rigidbody.AddForceAtPosition(m_fLeft.up * m_fltSpeed, m_fLeft.position, ForceMode.Acceleration);
        m_rigidbody.AddForceAtPosition(m_bRight.up * m_brtSpeed, m_bRight.position, ForceMode.Acceleration);
        m_rigidbody.AddForceAtPosition(m_bLeft.up * m_bltSpeed, m_bLeft.position, ForceMode.Acceleration);
    }
}
