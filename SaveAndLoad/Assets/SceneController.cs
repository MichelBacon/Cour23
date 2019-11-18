using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public static SceneController sceneControl;

    private void Start()
    {
        if (sceneControl == null)
        {
            DontDestroyOnLoad(gameObject);
            sceneControl = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextScene()
    {
        if (SceneManager.sceneCountInBuildSettings - 1 > SceneManager.GetActiveScene().buildIndex - 1)
        {
            print("Loading" + (SceneManager.GetActiveScene().buildIndex + 1));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            print("Error cant load next scene : This is the last scene");
        }
    }

    public void PreviousScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            print("Loading" + (SceneManager.GetActiveScene().buildIndex - 1));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
        {
            print("Error cant load previous scene : This is the first scene");
        }
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 56;
        GUI.Label(new Rect(10, 10, 180, 10), "Active Scene :" + SceneManager.GetActiveScene().buildIndex, style);
    }

}
