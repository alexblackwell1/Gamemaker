using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck //: MonoBehaviour
{
    public GameObject cardPF;
    public PhysicalCard cardProps;
	public PhysicalCard topCard;
	public string topCardName;
	public bool topVisible;

    private List<string> deck = new List<string>();

    public CardDeck()
    {
        //resetDeck();
    }

    public void fullDeck()
    {
		topVisible = false;
		
        string[] suits = { "C", "S", "H", "D" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                deck.Add(suits[i] + ranks[j]);
            }
        }
		
		setTopRandom();
		//topCard = 
    }

    public void setTopRandom()
    {
        if (deck.Count <= 0)
        {
            topCardName = "";
            return;
        }
        int num = Random.Range(0, deck.Count);
        // get a random card still in the deck
        string drawnCard = deck[num];
        // remove it from the deck
        deck.RemoveAt(num);
        // add it as the top card
        topCardName = drawnCard;
    }

    public string draw()
    {
        // return the top card
        string tc = topCardName;
        // set a new top card
        setTopRandom();
        return tc;
    }

    public List<CardDeck> divyOutXCards(int num_cards)
    {
        int num_players = GameInfo.GAMEINFO.NumPlayers;
        num_cards *= num_players;
        if (num_cards >= deck.Count)
            return splitDeck();

        List<CardDeck> split_decks = new List<CardDeck>();
        for (int i = 0; i < num_players; i++) split_decks.Add(new CardDeck());
        for (int i = 0; i < num_cards; i++)
        {
            split_decks[i % num_players].addCard(draw());
        }
        return split_decks;
    }

    public void discardToDeck(CardDeck _deck2)
    {
        // send over the top card
        _deck2.addCard(topCardName);
        // set a new top card
        setTopRandom();
    }

    public void discardAllToDeck(CardDeck deck2)
    {
        while (!isEmpty())
            discardToDeck(deck2);
    }

    public List<CardDeck> splitDeck()
    {
        int num_splits = GameInfo.GAMEINFO.NumPlayers;
        List<CardDeck> split_decks = new List<CardDeck>();
        for (int i = 0; i < num_splits; i++) split_decks.Add(new CardDeck());
        int player = 0;
        while (deck.Count > 0)
        {
            split_decks[player].addCard(this.draw());
            player = (++player) % num_splits;
        }
        return split_decks;
    }
    
    public void addCard(string cardName)
    {
        if (cardName == null)
            return;
        deck.Add(cardName);
    }

    public void addCards(List<string> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            deck.Add(cards[i]);
        }
    }

    public bool removeCard(string card)
    {
        // if the card wasn't in the deck
        if (!deck.Remove(card))
        {
            if (topCardName == card)
            {
                draw();
                return true;
            }
            return false;
        }
        return true;
    }
	
	public void revealTop() {
		topVisible = true;
		// topCard = cardProp topCardName
	}
	
	public void hideTop() {
		topVisible = false;
		// topCard = default back
	}

    public int size() {
        if (topCardName == "")
            return 0;
        return 1+deck.Count;
    }
	
	public bool isEmpty() { return deck.Count == 0 && topCardName == ""; }
}
