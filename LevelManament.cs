using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManament : MonoBehaviour
{
    public Button[] levelButtons;
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void back()
    {
        SceneManager.LoadScene(0);
    }
    public void Levels(int level)
    {
        SceneManager.LoadScene(level);
    }
}
