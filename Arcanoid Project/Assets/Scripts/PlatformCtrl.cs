using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCtrl : MonoBehaviour
{
    private const float range = 0.5f;
    private Rigidbody2D rb;
    private float speed;
    private Vector2 mousePos;

    void Start()
    {
        mousePos = Vector2.zero;
        speed = 10f;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x - range > transform.position.x)
        {
            speed = 10f;
        }
        else if (mousePos.x + range < transform.position.x)
        {
            speed = -10f;
        }
        else
        {
            speed = 0f;
        }
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}
