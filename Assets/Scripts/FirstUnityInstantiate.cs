using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstUnityInstantiate : MonoBehaviour
{
    public GameObject card;
    // click
    public void click()
    {
        Instantiate(card);
    }
}
