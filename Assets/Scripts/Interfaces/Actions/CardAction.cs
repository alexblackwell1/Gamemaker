using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAction : ActionEvent
{
    List<string> actionList;

    public CardAction(List<string> _actionList)
    {
        actionList = _actionList;
    }

    public void interact()
    {
        CardLocation loc1 = getLocation(actionList[0]);
        if (loc1.Condition.check())
        {
            // deck2 gets cards drawn by deck1
            if (actionList[1] == "draw")
            {
                int num = int.Parse(actionList[2]);
                CardLocation loc2 = getLocation(actionList[3]);
                while (num-- > 0)
                    loc1.cardDeck.discardToDeck(loc2.cardDeck);
                return;
            }
            if (actionList[1] == "=")
            {
                CardLocation loc2 = getLocation(actionList[2]);
                loc2.cardDeck.discardAllToDeck(loc1.cardDeck);
            }
        }
       
    }

    CardLocation getLocation(string loc)
    {
        return GameInfo.GAMEINFO.CardLocations[loc];
    }


    public override string ToString()
    {
        string ret = "ACTION: ";
        for (int i = 0; i < actionList.Count; i++)
        {
            ret += actionList[i];
            if (i != actionList.Count - 1)
                ret += " ";
            else
                ret += "\n";
        }
        return ret;
    }
}
