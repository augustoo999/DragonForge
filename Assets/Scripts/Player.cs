using System.Collections;

using UnityEngine;

using UnityEngine.UI;



public class Player : MonoBehaviour

{

    public float velocidade = 5.0f; // Velocidade de movimento do personagem 

    public float puloForca = 8.0f; // Força do salto 

    private bool estaNoChao = true; // Verifica se o personagem está no chão 

    
    public GameObject balaProjetil;
   
    public Transform arma;
   
    private bool tiro;
   
    public float forcaDoTiro;
   
    private bool flipX = true;

    private Rigidbody2D rb;

    private float cooldownTimer = 0f;

    public float cooldownDuration = 1f;

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


        if (flipX == false && movimentoHorizontal > 0)
        {
            Flip();
        }
        if (flipX == true && movimentoHorizontal < 0)
        {
            Flip();
        }

        if (estaNoChao && Input.GetKeyUp(KeyCode.Space))

        {

            rb.AddForce(Vector2.up * puloForca, ForceMode2D.Impulse);
        }

        if (cooldownTimer >= 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        tiro = Input.GetButtonDown("Fire1");

        Atirar();
    }

    void Flip()
    {
        flipX = !flipX;
       float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
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
        if(Input.GetButtonDown("Fire1") && cooldownTimer <= 0)
        {
            GameObject temp = Instantiate(balaProjetil);
            temp.transform.position = arma.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(forcaDoTiro, 0);
            Destroy(temp.gameObject, 3f);
            cooldownTimer = cooldownDuration;
        }
    }
}