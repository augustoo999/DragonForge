using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovimentoInimigo : MonoBehaviour
{
    public GameObject LaserInimigo;
    public Transform LocalDisparo;
    public float tempoMaximoEntreAsBolasDeFogo;
    public float TempoAtualDasBolasDeFogo;
    public bool inimigoAtirador;
    public float Speed;
    public bool Ground;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool FacingRight = true;
    public int Health = 10;
    Animator animator;

    void Start()
    {
        if (groundCheck == null)
        {
            Debug.Log(this);
            Debug.Break();
        }

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
        Ground = Physics2D.Linecast(groundCheck.position, transform.position, groundLayer);


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

        if (inimigoAtirador == true)
        {
            AtirarBolaDeFogo();
        }
    }

    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    void CheckHealth()
    {
        if (Health <= 0)
        {
            animator.SetBool("IsAlive", false);
            Speed = 0;

            StartCoroutine(DestroyEnemy());
        }
    }

    public IEnumerator DestroyEnemy()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Destroy(gameObject);
    }



    void TakeDamage(int amount)
    {
        Health -= amount;
        CheckHealth();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bala"))
        {
            Destroy(collision.gameObject);
            TakeDamage(5);
        }
    }
    private void AtirarBolaDeFogo()
    {
        if (TempoAtualDasBolasDeFogo >= 0)
        {
            TempoAtualDasBolasDeFogo -= Time.deltaTime;
        }
        if (TempoAtualDasBolasDeFogo < 0)
        {
            RaycastHit2D Hit = Physics2D.Raycast(LocalDisparo.position, Vector2.right * (FacingRight ? 1 : -1), 6);
            if (Hit.collider != null && Hit.collider.gameObject.CompareTag("Player"))
            {
                TempoAtualDasBolasDeFogo = tempoMaximoEntreAsBolasDeFogo;
                Instantiate(LaserInimigo, LocalDisparo.position, Quaternion.LookRotation(Vector3.forward, Vector2.right * (FacingRight ? 1 : -1)));
            }
        }
    }
}


