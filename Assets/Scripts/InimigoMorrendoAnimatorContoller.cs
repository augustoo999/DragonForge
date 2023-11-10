using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMorrendoAnimatorContoller : MonoBehaviour
{
    private Animator animador;
    private bool estaMorto = false;

    void Start()
    {
        // Obtém o componente Animator do inimigo
        animador = GetComponent<Animator>();
    }

    // Função para chamar quando o inimigo morre
    public void Morrer()
    {
        // Verifica se o inimigo já está morto para evitar chamar a animação várias vezes
        if (!estaMorto)
        {
            // Ativa o trigger "Morreu" para acionar a animação de morte
            animador.SetTrigger("Morreu");

            // Define o inimigo como morto para evitar que a animação seja chamada novamente
            estaMorto = true;

            // Adicione aqui qualquer outra lógica que você queira executar quando o inimigo morrer
        }
    }
}