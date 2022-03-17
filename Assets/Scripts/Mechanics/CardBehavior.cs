using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardBehavior : MonoBehaviour
{
    public GameObject card1;
    public GameObject card2;

    private Dictionary<string, int> cardValues = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        for (int i = 0; i < 13; i++)
        {
            cardValues.Add(ranks[i], i+2);
        }
    }

    public void compareCard()
    {
        //From the BoardState object get the 2 most recently played cards and compare them
        CardProp c1 = BoardState.BOARD.getPlayedCard(0);
        CardProp c2 = BoardState.BOARD.getPlayedCard(1);
        //CardProp c1 = card1.GetComponent<CardProp>();
        //CardProp c2 = card2.GetComponent<CardProp>();
        Debug.Log(cardValues[c1.getRank()]);
        Debug.Log(cardValues[c2.getRank()]) ;
        if (cardValues[c1.getRank()] > cardValues[c2.getRank()])
        {
            Debug.Log("Card 1 is larger!");
            //return true;
        }
        else if (cardValues[c1.getRank()] < cardValues[c2.getRank()])
        {
            Debug.Log("Card 2 is larger!");
            //return false;
        } else
        {
            Debug.Log("The cards have the same rank!");
        }
        
        //return false;
    }
}
