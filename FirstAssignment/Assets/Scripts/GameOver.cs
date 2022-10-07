using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    static public bool isGameOver;
    private float _time;
    [SerializeField] private TextMeshProUGUI _teamNameText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Canvas _playerHudCanvas;

    private void Start()
    {
        isGameOver = false;
        _time = 5;
    }

    private void Update()
    {
        if (isGameOver)
        {
            _time -= Time.deltaTime;
        }

        if (_time <= 0)
        {
            LoadNextScene();
        }

        _timeText.text = Mathf.Round(_time * 1).ToString();
    }

    public void WinnerIsDecided(string teamName)
    {
        _playerHudCanvas.enabled = false;
        _gameOverPanel.SetActive(true);
        _teamNameText.text = teamName;
        Cursor.lockState = CursorLockMode.None;

    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

}
