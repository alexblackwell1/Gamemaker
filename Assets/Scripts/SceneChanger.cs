using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Go to the Load Start Screen
    public void CreateLoadScreen() {
        SceneManager.LoadScene("CreateLoadScreen");
    }


    // Go to the Game Info Screen
    public void GameInfoScreen() {
        SceneManager.LoadScene("GameInfo");
    }

    // Go to Game Elements Screen 
    public void GameElementScreen() {
        SceneManager.LoadScene("GameElementScreen");
    }
}
