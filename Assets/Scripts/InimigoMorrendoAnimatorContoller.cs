using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMorrendoAnimatorContoller : MonoBehaviour
{
    private Animator animador;
    private bool estaMorto = false;

    void Start()
    {
        // Obt�m o componente Animator do inimigo
        animador = GetComponent<Animator>();
    }

    // Fun��o para chamar quando o inimigo morre
    public void Morrer()
    {
        // Verifica se o inimigo j� est� morto para evitar chamar a anima��o v�rias vezes
        if (!estaMorto)
        {
            // Ativa o trigger "Morreu" para acionar a anima��o de morte
            animador.SetTrigger("Morreu");

            // Define o inimigo como morto para evitar que a anima��o seja chamada novamente
            estaMorto = true;

            // Adicione aqui qualquer outra l�gica que voc� queira executar quando o inimigo morrer
        }
    }
}