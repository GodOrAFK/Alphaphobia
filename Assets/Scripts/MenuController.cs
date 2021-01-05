using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Sub-Menus")]
    public GameObject MainMenu;
    public GameObject SettingMenu;

    public void StartGame()
    {
        SceneManager.LoadScene("World");
    }

    public void Exit()
    {
        if (Debug.isDebugBuild)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }

    public void ToggleSettings(bool open)
    {
        if (open)
        {
            MainMenu.SetActive(false);
            SettingMenu.SetActive(true);
        }
        else
        {
            MainMenu.SetActive(true);
            SettingMenu.SetActive(false);
        }
    }
}
