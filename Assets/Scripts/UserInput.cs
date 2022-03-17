using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UserInput : MonoBehaviour
{
    public InputField nameInput;
    //public string gameName;

    public void getInputField(string field) {
        GameObject child;
        switch (field)
        {
            case "gamename":
                child = gameObject.transform.GetChild(0).gameObject;
                //Debug.Log(child.GetComponent<InputField>().text);
                GameInfo.GAMEINFO.GameName = child.GetComponent<InputField>().text;
                Debug.Log(GameInfo.GAMEINFO.GameName);
                break;
            case "num_players":
                child = gameObject.transform.GetChild(1).gameObject;
                GameInfo.GAMEINFO.NumPlayers = Int32.Parse(child.GetComponent<Dropdown>().options[child.GetComponent<Dropdown>().value].text);
                Debug.Log(GameInfo.GAMEINFO.NumPlayers);
                break;
            case "element":
                // to-do
                break;
            case "amount":
                // to-do
                break;
                
        }
    }
}
