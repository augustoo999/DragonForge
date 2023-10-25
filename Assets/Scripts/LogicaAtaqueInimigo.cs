using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaAtaqueInimigo : MonoBehaviour
{
    public Transform player;
    public GameObject projetilPrefab;
    public Transform arma;
    public float velocidadeProojetil = 10f;

    // Update is called once per frame
    void Update()
    {
        Vector3 direcaoJogador = player.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direcaoJogador, Mathf.Infinity);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            AtirarNoPlayer();
        }
    }
    void AtirarNoPlayer()
    {
        GameObject projetil = Instantiate(projetilPrefab, arma.position, arma.rotation);
        Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();
        rb.AddForce(arma.up * velocidadeProojetil, ForceMode2D.Impulse);
    }
}
