using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpScript : MonoBehaviour
{
    public GameObject Panel;
    GameObject myButton;
    public bool firstSceneDone;
    private void Start()
    {
        firstSceneDone = true;
        myButton = GameObject.FindGameObjectWithTag("Button");
    }
    private void Update()
    {
        /*if (Drag.instance.IsDone && firstSceneDone)
        {
            myButton.transform.position = new Vector3(-630, 280, 0);
            myButton.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
            firstSceneDone = false;
        }  */
    }
    public void PanelControl()
    {
        if (Panel!=null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive); 
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        SceneManager.LoadScene(1);
    }
}
