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
    
    CardProp[] playedCards = new CardProp[2];
    
    void Start()
    {

    }

    public BoardState()
    {

    }
    
    public void setPlayedCard(int playerNumber, CardProp card)
    {
        playedCards[playerNumber] = card;
    }

    public CardProp getPlayedCard(int playerNumber)
    {
        return playedCards[playerNumber];
    }

}
