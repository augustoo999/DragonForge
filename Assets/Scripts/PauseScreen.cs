using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject pauseOptionsPanel;

    private void Start()
    {
        if (pauseOptionsPanel != null) pauseOptionsPanel.SetActive(false);
        if (pauseMenuPanel != null) pauseMenuPanel.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (pauseMenuPanel is null) return;
            if (pauseMenuPanel.activeInHierarchy) ClosePauseMenu();
            else OpenPauseMenu();
        }
    }

    private void OpenPauseMenu()
    {
        pauseMenuPanel.SetActive(true);
        pauseOptionsPanel.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ClosePauseMenu()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenOptionsGame()
    {
        pauseOptionsPanel.SetActive(true);
    }

    public void CloseOptionsGame()
    {
        pauseOptionsPanel.SetActive(false);
    }

    public void LoadMainMenuScene()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(0);
    }
}