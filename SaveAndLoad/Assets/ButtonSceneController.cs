using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSceneController : MonoBehaviour {
    public void NextScene()
    {
        SceneController.sceneControl.NextScene();
    }

    public void PreviousScene()
    {
        SceneController.sceneControl.PreviousScene();
    }
}
