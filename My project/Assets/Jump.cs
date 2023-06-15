using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpPower;
    [SerializeField] Transform feetPos;
    [SerializeField] float radius;
    [SerializeField] LayerMask layerMask;
    [SerializeField] int gravityScale;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log(IsGrounded());

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        }
        Gravity();

    }
    


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(feetPos.position, radius, layerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(feetPos.position, radius);
    }
    void Gravity()
    {
        if (rb.velocity.y > 0)
        {
            rb.gravityScale = 1;
        }
        else if (rb.velocity.y < 0)

            rb.gravityScale = gravityScale;

           
    }

}
