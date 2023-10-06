using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Player : MonoBehaviour

{

    public float velocidade = 5.0f; // Velocidade de movimento do personagem 

    public float puloForca = 8.0f; // Força do salto 

    private bool estaNoChao = true; // Verifica se o personagem está no chão 

    
    public GameObject balaProjetil;
   
    public Transform arma;
   
    private bool tiro;
   
    public float forcaDoTiro;
   
    private bool flipX = false;

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

        if (flipX == true && velocidade > 0)
        {
            Flip();
        }
        else if (flipX == false && velocidade < 0)
        {
            Flip();
        }

        // Verifica se o personagem está no chão 

        //Collider2D thiago = Physics2D.OverlapCircle(transform.position, 0.0000001f);

        //Debug.Log(thiago.gameObject.name);

        // Pulo 

        if (estaNoChao && Input.GetKeyUp(KeyCode.Space))

        {

            rb.AddForce(Vector2.up * puloForca, ForceMode2D.Impulse);
            Debug.Log("Jump");
        }

        tiro = Input.GetButtonDown("Fire1");

        Atirar();

    }

    void Flip()
    {
        flipX = !flipX;
       float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        forcaDoTiro *= -1;
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

    private void Atirar()
    {
        if(tiro == true)
        {
            GameObject temp = Instantiate(balaProjetil);
            temp.transform.position = arma.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(forcaDoTiro, 0);
            Destroy(temp.gameObject, 3f);
        }
    }

}


