using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _backButton;
    [SerializeField] private GameObject _serializeMainPanel;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _controlsPanel;

    static public bool isToggle;
    static public GameObject staticMainPanel;

    private void Start()
    {
        isToggle = false;
        staticMainPanel = _serializeMainPanel;
    }

    public void OnClickPlay()
    {
        Destroy(Camera.main.gameObject);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
        _playButton.enabled = false;
        _continueButton.enabled = true;
        _serializeMainPanel.SetActive(false);
    }

    public void OnClickQuit()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void OnClickContinue()
    {
        _serializeMainPanel.SetActive(false);

    }

    public void OnClickControls()
    {
        _controlsPanel.SetActive(true);
        _menuPanel.SetActive(false);
    }

    public void OnClickBack()
    {
        _controlsPanel.SetActive(false);
        _menuPanel.SetActive(true);
    }

    static public void ToggleMainMenu()
    {
        isToggle = !isToggle;
        staticMainPanel.SetActive(isToggle);
        if (isToggle)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

}
