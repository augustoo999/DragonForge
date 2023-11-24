using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeFogo : MonoBehaviour
{
    public float velocidade;
    public float tempo;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * velocidade;

        tempo -= Time.deltaTime;
        if (tempo < 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out var pl))
        {
            pl.TomeDano();
            Destroy(gameObject);
        }
    }
}
