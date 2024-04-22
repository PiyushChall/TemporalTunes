using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public int Level1 = 2;

    public int SettingScene = 1;
   

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Lvl1()
    {
        SceneManager.LoadScene(Level1);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void SettingScenee()
    {
        SceneManager.LoadScene(SettingScene);
    }
}
