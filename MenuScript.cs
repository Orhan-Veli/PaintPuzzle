using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.GetActiveScene();
    }
    public void play()
    {
        SceneManager.LoadScene(1);
    }
    
}
