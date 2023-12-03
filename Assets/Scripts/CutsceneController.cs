using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public Image characterImage;
    public Text characterSpeech;
    public string nextScene;

    private void Start()
    {
        // Iniciar a cutscene
        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        // Mostrar a imagem e fala
        characterImage.gameObject.SetActive(true);
        characterSpeech.text = "Ele est� aqui me provocando, vou entrar nesse vulc�o e salvar minha amada Celeste!!";

        // Aguarde alguns segundos (tempo suficiente para o jogador ler a fala)
        yield return new WaitForSeconds(3f);

        // Ocultar a imagem e fala
        characterImage.gameObject.SetActive(false);
        characterSpeech.text = "";

        // Trocar para a pr�xima cena
        SceneManager.LoadScene(3);
    }
}

