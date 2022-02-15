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
}
