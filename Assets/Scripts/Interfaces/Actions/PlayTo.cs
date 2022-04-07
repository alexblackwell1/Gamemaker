using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTo : ActionEvent
{
    CardLocation c1;
    CardLocation c2;
    public PlayTo(Location l1, Location l2)
    {
        c1 = (CardLocation)l1;
        c2 = (CardLocation)l2;
    }

    public void interact()
    {
        c2.cardDeck.addCard(c1.cardDeck.draw());
    }
}
