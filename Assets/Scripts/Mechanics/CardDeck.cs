using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public GameObject cardPF;
    public CardProp cardProps;


    private int cardsInDeck = 52;
    private List<string> deck = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        string[] suits = { "C", "S", "H", "D" }; 
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                deck.Add(suits[i] + ranks[j]);
            }
        }
    }

    public void drawCard()
    {
        if (cardsInDeck > 0)
        {
            int num = Random.Range(0, cardsInDeck);
            string drawnCard = deck[num];
            deck.RemoveAt(num);
            cardsInDeck--;
            Debug.Log("Card remaining = "  + cardsInDeck);
            GameObject nObj = Instantiate(cardPF, new Vector3(0,0,0), transform.rotation);
            nObj.transform.SetParent(GameObject.Find("PlayArea").transform, false);
            //Temp to make sure cards appear in different locations
if (cardsInDeck % 2 == 0) nObj.transform.position = GameObject.Find("Location1").transform.position;
else nObj.transform.position = GameObject.Find("Location2").transform.position;
            
            cardProps = nObj.GetComponent<CardProp>();
            cardProps.setCard(drawnCard.Substring(0,1), drawnCard.Substring(1));

            //Set the drawn card to be the most recently played card in its respective pile
            BoardState.BOARD.setPlayedCard(cardsInDeck % 2, cardProps);
        }     
    }

}
