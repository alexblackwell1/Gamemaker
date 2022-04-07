using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardState : MonoBehaviour
{
    private static BoardState _BOARD;

    // BoardState instance that can be referenced by any scripts in the scene
    public static BoardState BOARD
    {
        get
        {
            if (_BOARD == null)
            {
                _BOARD = GameObject.FindObjectOfType<BoardState>();
            }
            return _BOARD;
        }
    }
    
    PhysicalCard[] playedCards = new PhysicalCard[2];
    
    void Start()
    {

    }

    public BoardState()
    {

    }
    
    public void setPlayedCard(int playerNumber, PhysicalCard card)
    {
        playedCards[playerNumber] = card;
    }

    public PhysicalCard getPlayedCard(int playerNumber)
    {
        return playedCards[playerNumber];
    }

}
