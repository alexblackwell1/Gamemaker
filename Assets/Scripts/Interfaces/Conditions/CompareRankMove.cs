using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareRankMove : ActionEvent
{
    Dictionary<string, int> cardValues;
    List<CardLocation> location;

    public CompareRankMove(CardLocation l1, CardLocation l2, CardLocation l3, CardLocation l4)
    {
        location = new List<CardLocation>();
        location.Add(l1);
        location.Add(l2);
        location.Add(l3);
        location.Add(l4);

        cardValues = new Dictionary<string, int>();
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        for (int i = 0; i < 13; i++)
            cardValues.Add(ranks[i], i + 2);
    }

    public void interact()
    {
        // empty loc1 || loc2 case
        if (location[0].cardDeck.isEmpty() || location[1].cardDeck.isEmpty())
            return;
        // greater in loc1 case
        if (cardValues[location[0].cardDeck.topCard.getRank()] > cardValues[location[1].cardDeck.topCard.getRank()])
        {
            location[0].cardDeck.discardAllToDeck(location[2].cardDeck);
            location[1].cardDeck.discardAllToDeck(location[2].cardDeck);
            return;
        }
        // greater in loc2 case
        if (cardValues[location[0].cardDeck.topCard.getRank()] < cardValues[location[1].cardDeck.topCard.getRank()])
        {
            location[0].cardDeck.discardAllToDeck(location[3].cardDeck);
            location[1].cardDeck.discardAllToDeck(location[3].cardDeck);
            return;
        }
        // equal case (do nothing)
    }
}