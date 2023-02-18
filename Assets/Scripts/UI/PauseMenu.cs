using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject _pauseMenuUI;
    private bool _isPaused = false;

    private void OnEnable()
    {
        Player.GamePaused += PauseGame;
    }
    private void OnDisable()
    {
        Player.GamePaused -= PauseGame;
    }
    public void PauseGame()
    {
        Debug.Log("PauseUI");
        Time.timeScale = _isPaused?1f:0f;
        _pauseMenuUI.SetActive(!_pauseMenuUI.activeInHierarchy);
        _isPaused = !_isPaused;
    }
    public void ReturnToMainScreen()
    {
        Time.timeScale = 1f;
        MatchManager.SwitchScene?.Invoke(0);
    }

}
