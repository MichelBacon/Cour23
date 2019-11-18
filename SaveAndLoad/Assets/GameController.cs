using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController control;

    public int attack;
    public int defense;
    public int health;

    PlayerData playerData = new PlayerData();

    public int currentWeaponIndex;

    // Use this for initialization
    void Start () {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
            SetDefaultValue();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDefaultValue()
    {
        attack = 1;
        defense = 1;
        health = 1;
        currentWeaponIndex = 0;
        playerData.weapons = new List<Weapon>();
    }

    public void AddAttack()
    {
        attack++;
    }

    public void AddDefense()
    {
        defense++;
    }

    public void AddHealth()
    {
        health++;
    }

    public void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if(!File.Exists(Application.persistentDataPath + "gameInfo.data"))
        {
            throw new Exception("Game file doesnt exist");
        }
        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.data", FileMode.Open);
        PlayerData playerDataToLoad = (PlayerData)bf.Deserialize(file);
        file.Close();
        attack = playerDataToLoad.attack;
        defense = playerDataToLoad.defense;
        health = playerDataToLoad.health;
        playerData.weapons = playerDataToLoad.weapons;
        playerData.weaponindex = playerDataToLoad.weaponindex;
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.data", FileMode.Create);
        PlayerData playerDataToSave = new PlayerData();
        playerDataToSave.attack = attack;
        playerDataToSave.defense = defense;
        playerDataToSave.health = health;
        playerDataToSave.weapons = playerData.weapons;
        playerDataToSave.weaponindex = currentWeaponIndex;
        bf.Serialize(file, playerDataToSave);
        file.Close();
    }

    public void AddAttackWeapon()
    {
        print(currentWeaponIndex);
        playerData.weapons[currentWeaponIndex].attack++;
    }

    public void AddWeapon()
    {
        Weapon weaponToAdd = new Weapon();
        weaponToAdd.attack = 1;
        playerData.weapons.Add(weaponToAdd);
        currentWeaponIndex = playerData.weapons.Count - 1;
    }


    public void NextWeapon()
    {
        if (currentWeaponIndex == playerData.weapons.Count - 1)
        {
            currentWeaponIndex = 0;
        }
        else
        {
            currentWeaponIndex++;
        }
    }

    public void PreviousWeapon()
    {
        if (currentWeaponIndex == 0)
        {
            currentWeaponIndex = playerData.weapons.Count - 1;
        }
        else
        {
            currentWeaponIndex--;
        }
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
        GUI.Label(new Rect(10, 60, 180, 10), "Attack :" + attack,style);
        GUI.Label(new Rect(10, 110, 180, 10), "Defense :" + defense, style);
        GUI.Label(new Rect(10, 160, 180, 10), "Health :" + health, style);
        if(playerData.weapons.Count != 0)
        {
            GUI.Label(new Rect(10, 200, 180, 10), "Attack Weapon :" + playerData.weapons[currentWeaponIndex].attack, style);
            GUI.Label(new Rect(10, 240, 180, 10), "Weapon Index :" + currentWeaponIndex, style);
        }

        
    }
}

[Serializable]
class PlayerData
{
    public int attack;
    public int defense;
    public int health;
    public List<Weapon> weapons;
    public int weaponindex;
}

[Serializable]
class Weapon
{
    public int attack;
}
