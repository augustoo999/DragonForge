using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string[] PlayerNames;

    public ScriptableObject sc;

    public GameObject ene;
   
    void Start()
    {
        Instantiate(ene);
        Debug.Log(sc.name);
        //ene.GetComponent<MovimentoInimigo>().Speed = sc.movespeed;
    }

}
