using System.Collections;

using UnityEngine;

using UnityEngine.UI;

using UnityEngine.SceneManagement;



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

    public float tempoMachado;

    public int Hp = 8;

    public Transform Blaze;
    DialogueSystem dialogueSystem;

    Animator animPlayer;

    private AudioSource Sound;

    private void Awake()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();

        Sound = GetComponent<AudioSource>();
    }


    void Start()

    {
        animPlayer = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }



    void Update()

    {

        // Movimento horizontal 

        float movimentoHorizontal = Input.GetAxis("Horizontal");

        Vector2 velocidadeMovimento = new Vector2(movimentoHorizontal * velocidade, rb.velocity.y);

        rb.velocity = velocidadeMovimento;

        animPlayer.SetFloat("velocidadeMovimento",Mathf.Abs (movimentoHorizontal));
        animPlayer.SetBool("Pulo", !estaNoChao);


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
            Sound.Play();
        }



        if (Mathf.Abs(transform.position.x - Blaze.position.x) < 2.0f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueSystem.Next();
            }
        }




        if (cooldownTimer >= 0)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                animPlayer.SetBool("Atirar", false);
            }
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
        if (Input.GetButtonDown("Fire1") && cooldownTimer <= 0)
        {
            animPlayer.SetBool("Atirar", true);

            GameObject temp = Instantiate(balaProjetil);
            temp.transform.position = arma.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(forcaDoTiro, 0);
            Destroy(temp.gameObject, 3f);
            cooldownTimer = cooldownDuration;
            tempoMachado -= Time.deltaTime;

            // Verificar se a bala colidiu com o chão (Ground)
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(temp.transform.position, 0.2f);
            foreach (Collider2D hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Ground"))
                {
                    // Destruir a bala se colidir com o chão
                    Destroy(temp.gameObject);
                    break;
                }
            }

            if (tempoMachado < 0)
                Destroy(gameObject);

            
        }
        else
        {
            
        }
    }



    public void TomeDano(int amount)
    {
        Hp -= amount;
        if (Hp <= 0)
        {
            //Trigger animação de morrer
            ResetCena();
        }
    }

    public void ResetCena()
    {
        SceneManager.LoadScene(1);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoladeFogo"))
        {
            Destroy(collision.gameObject);
            
            TomeDano(2);
        }
        
    }

}
