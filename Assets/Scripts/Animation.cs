using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Animation : MonoBehaviour
{

    public Action TypeFinished;

    public float typeDelay = 0.05f;
    public TextMeshProUGUI textObject;

    public string fullText;

    Coroutine coroutine;

    void Start()
    {
        StartAnimation();
    }

    public void StartAnimation()
    {
        coroutine = StartCoroutine(TypeTexto());
    }

    IEnumerator TypeTexto()
    {

        textObject.text = fullText;
        textObject.maxVisibleCharacters = 0;
        for (int i = 0; i <= textObject.text.Length; i++)
        {
            textObject.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeDelay);
        }

        TypeFinished?.Invoke();

    }

    public void Skip()
    {

        StopCoroutine(coroutine);
        textObject.maxVisibleCharacters = textObject.text.Length;

    }

}
