using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserTextInput : MonoBehaviour
{
    public InputField nameInput;
    public string gameName;

    public void getName() {
        gameName = nameInput.text;
        Debug.Log(gameName);
    }
}
