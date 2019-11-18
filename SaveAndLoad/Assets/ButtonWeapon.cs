using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWeapon : MonoBehaviour {
    public void IncreaseAttack()
    {
        GameController.control.AddAttackWeapon();
    }

    public void AddNewWeapon()
    {
        GameController.control.AddWeapon();
    }
    public void Next()
    {
        GameController.control.NextWeapon();
    }
    public void Previous()
    {
        GameController.control.PreviousWeapon();
    }
}
