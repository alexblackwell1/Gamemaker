using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutBoard : MonoBehaviour
{
    public GameObject board;

    // Start is called before the first frame update
    void Start()
    {
        if (GameInfo.GAMEINFO.getBoard() != null)
        {
            board.GetComponent<Image>().sprite = GameInfo.GAMEINFO.getBoard();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
