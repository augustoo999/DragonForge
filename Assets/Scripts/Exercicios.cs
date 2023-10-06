using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercicios : MonoBehaviour
{
    private void Start()
    {
        Ex01();
        Ex02("Pedro");
    }

    public void Ex01()
    {
        Debug.Log("Ex01");
        Debug.Log("Olá Mundo!");
    }

    public void Ex02(string name)
    {
        Debug.Log("Ex02");
        Debug.Log("Olá " + name);
    }
}
