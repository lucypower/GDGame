using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float m_horizontal;
    private float m_vertical;

    [SerializeField] private float m_speed = 5f;
    [SerializeField] private Rigidbody2D m_RB;

    private void Update()
    {
        m_horizontal = Input.GetAxisRaw("Horizontal");
        m_vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        m_RB.velocity = new Vector2(m_horizontal * m_speed, m_vertical * m_speed);
    }
}
