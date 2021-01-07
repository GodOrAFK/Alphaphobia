using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject SoundController;

    [Header("Sub-Menus")]
    public GameObject MainMenu;
    public GameObject SettingMenu;

    private void Awake()
    {
        if (SoundController != null) { DontDestroyOnLoad(SoundController); }
    }

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("World_Tilemap");
    }

    public void Exit()
    {
        Application.Quit();
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
