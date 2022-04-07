using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCondition
{
    List<string> ifInput;
    bool defaultReturn;

    public CardCondition()
    {
        defaultReturn = true;
    }

    public CardCondition(List<string> _ifInput)
    {
        defaultReturn = false;
        ifInput = _ifInput;
    }

    public  bool check()
    {
        if (defaultReturn)
            return true;

        //  0       1       2           3       4
        // object, field, comparsion, object, field
        CardLocation loc1 = getLocation(ifInput[0]);
        int field1 = getField(loc1, ifInput[1]);
        CardLocation loc2 = getLocation(ifInput[3]);
        int field2 = getField(loc2, ifInput[4]);
        switch (ifInput[2][0])
        {
            case '<':
                return field1 < field2;
            case '>':
                return field1 > field2;
            case '=':
                return field1 == field2;
        }
        return false;
    }

    int getField(CardLocation loc, string field)
    {
        if (field == "count")
        {
            return loc.cardDeck.size();
        }
        if (field == "rank")
        {
            int rank = (int)loc.cardDeck.topCardName[1];
            if ((rank - 48) > 1 && (rank - 48) < 10)
                return rank;
            switch (rank)
            {
                case (int)'j':
                    return 10;
                case (int)'q':
                    return 11;
                case (int)'k':
                    return 12;
                case (int)'a':
                    return 13;
            }
        }
        return -1;
    }

    CardLocation getLocation(string loc)
    {
        return GameInfo.GAMEINFO.CardLocations[loc];
    }

    public override string ToString()
    {
        string ret = "CONDITION: ";
        for (int i = 0; i < ifInput.Count; i++)
        {
            ret += ifInput[i];
            if (i != ifInput.Count - 1)
                ret += " ";
            else
                ret += "\n";
        }
        return ret;
    }
}
