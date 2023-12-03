using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public Image characterImage;
    public Text characterSpeech;
    public string nextScene;

    [Header("Cutscene Settings")]
    public string cutsceneText;
    public float cutsceneDuration = 3f;

    private void Start()
    {
        // Iniciar a cutscene
        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        // Mostrar a imagem e fala
        characterImage.gameObject.SetActive(true);
        characterSpeech.text = cutsceneText;

        // Aguarde o tempo configurado (tempo suficiente para o jogador ler a fala)
        yield return new WaitForSeconds(cutsceneDuration);

        // Ocultar a imagem e fala
        characterImage.gameObject.SetActive(false);
        characterSpeech.text = "";

        // Trocar para a próxima cena, se fornecida
        if (!string.IsNullOrEmpty(nextScene))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
