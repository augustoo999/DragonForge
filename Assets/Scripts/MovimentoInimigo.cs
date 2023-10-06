using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{
    public float Speed;
    public bool Ground;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool FacingRight = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
        Ground = Physics2D.Linecast(groundCheck.position, transform.position, groundLayer);
        Debug.Log(Ground);

        if (Ground == false)
        {
            Speed *= -1;
        }
        if (Speed > 0 && !FacingRight)
        {
            Flip();
        }
        else if (Speed < 0 && FacingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
