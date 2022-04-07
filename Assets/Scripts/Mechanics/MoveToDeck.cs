using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToDeck : CardInteractionInterface
{
    CardLocation l1;
    CardLocation l2;

    public MoveToDeck(CardLocation _l1, CardLocation _l2)
    {
        l1 = _l1;
        l2 = _l2;
    }

    public void interact()
    {
        l1.cardDeck.discardToDeck(l2.cardDeck);
    }
}
