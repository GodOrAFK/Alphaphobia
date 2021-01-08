using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject SettingMenu;

    private bool _isPaused;
    private bool _isSettingOpen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused) { Resume(); }
            else { Pause(); }
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);

        Time.timeScale = 1f;
        _isPaused = false;
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);

        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ToggleSetting()
    {
        SettingMenu.SetActive(!SettingMenu.activeSelf);
        PauseMenu.SetActive(!PauseMenu.activeSelf);

        _isSettingOpen = !_isSettingOpen;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
