using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] conjuntosDePlataformas;
    public float distanciaEntrePlataformas = 1f;

    void Start()
    {
        SortearPlataformas();
    }

    void SortearPlataformas()
    {
        Vector3 posicaoInicial = Vector3.zero;

        for (int i = 0; i < 5; i++)
        {
            int indiceSorteado = Random.Range(0, conjuntosDePlataformas.Length);
            GameObject conjuntoSorteado = conjuntosDePlataformas[indiceSorteado];

            // Use o conjuntoSorteado conforme necessário
            GameObject plataforma = Instantiate(conjuntoSorteado, posicaoInicial, Quaternion.identity);

            // Obter a largura do conjunto para garantir a próxima posição
            Renderer rend = plataforma.GetComponentInChildren<Renderer>();
            float larguraConjunto = rend != null ? rend.bounds.size.x : 0f;

            // Atualizar a posição inicial para a próxima plataforma
            posicaoInicial.x += larguraConjunto + distanciaEntrePlataformas;
        }
    }
}