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
    void Start()
    {
        
    }

    // Update is called once per frame
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bala"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
    private void AtirarBolaDeFogo()
    {
        TempoAtualDasBolasDeFogo -= Time.deltaTime;
        if(TempoAtualDasBolasDeFogo <= 0)
        {
            Instantiate(LaserInimigo, LocalDisparo.position, Quaternion.Euler(0f, 0f, 90f));
            TempoAtualDasBolasDeFogo = tempoMaximoEntreAsBolasDeFogo;
        }
    }
}
