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
        characterSpeech.text = "Ele está aqui me provocando, vou entrar nesse vulcão e salvar minha amada Celeste!!";

        // Aguarde alguns segundos (tempo suficiente para o jogador ler a fala)
        yield return new WaitForSeconds(3f);

        // Ocultar a imagem e fala
        characterImage.gameObject.SetActive(false);
        characterSpeech.text = "";

        // Trocar para a próxima cena
        SceneManager.LoadScene(3);
    }
}

