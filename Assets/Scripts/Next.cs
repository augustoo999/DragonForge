using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Next : MonoBehaviour
{
    [SerializeField] private string Sinopse;
    public void NextScene()
    {
        SceneManager.LoadScene(Sinopse);
    }
}
