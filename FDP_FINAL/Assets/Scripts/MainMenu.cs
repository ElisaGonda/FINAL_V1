using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
    }


    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

  
    
    
}
