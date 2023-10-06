using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Player : MonoBehaviour

{

    public float velocidade = 5.0f; // Velocidade de movimento do personagem 

    public float puloForca = 8.0f; // Força do salto 

    private bool estaNoChao = true; // Verifica se o personagem está no chão 



    private Rigidbody2D rb;



    void Start()

    {

        rb = GetComponent<Rigidbody2D>();

    }



    void Update()

    {

        // Movimento horizontal 

        float movimentoHorizontal = Input.GetAxis("Horizontal");

        Vector2 velocidadeMovimento = new Vector2(movimentoHorizontal * velocidade, rb.velocity.y);

        rb.velocity = velocidadeMovimento;



        // Verifica se o personagem está no chão 

        //Collider2D thiago = Physics2D.OverlapCircle(transform.position, 0.0000001f);

        //Debug.Log(thiago.gameObject.name);

        // Pulo 

        if (estaNoChao && Input.GetKeyUp(KeyCode.Space))

        {

            rb.AddForce(Vector2.up * puloForca, ForceMode2D.Impulse);
            Debug.Log("Jump");
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            estaNoChao = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            estaNoChao = false;
        }
    }
}


