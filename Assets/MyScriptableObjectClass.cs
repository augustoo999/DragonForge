using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Criador")]
public class MyScriptableObjectClass : ScriptableObject {
    public string name = "Roberto";
    public int vidas;
    public float movespeed;
}

[CreateAssetMenu(fileName = "Dados", menuName = "Armazenamento")]
public class AAAA : ScriptableObject {
   public float idade;
}