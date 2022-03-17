using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour
{
    private static GameInfo _GAMEINFO;

    public static GameInfo GAMEINFO
    {
        get
        {
            if (_GAMEINFO == null)
            {
                _GAMEINFO = GameObject.FindObjectOfType<GameInfo>();
            }
            return _GAMEINFO;
        }
    }


    private static string gameName = "Game";
    public string GameName
    {
        get { return gameName; }
        set { gameName = value; }
    }

    private static Sprite boardImage;
    public void setBoard(Sprite b) { boardImage = b; }
    public Sprite getBoard() { return boardImage; }

    private static int numPlayers = 1;
    public int NumPlayers
    {
        get { return numPlayers; }
        set { numPlayers = value; }
    }

    void Start()
    {

    }

    public void build()
    {
        //gameName = nameInputField.text;

    }


}
