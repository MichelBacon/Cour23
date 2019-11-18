using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSaveAndLoad : MonoBehaviour {
    public void Save()
    {
        GameController.control.Save();
    }

    public void Load()
    {
        GameController.control.Load();
    }
}
