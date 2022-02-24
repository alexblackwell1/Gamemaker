using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public GameObject cardPF;
    public CardProp cardProps;
    private string suit = "C";
    private string rank = "9";  

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void drawCard(string suit, string rank)
    {
        
    }

    public void test()
    {
        GameObject nObj = Instantiate(cardPF);
        cardProps = nObj.GetComponent<CardProp>();
        cardProps.setCard(suit, rank);
    }
}
