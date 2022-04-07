using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConstructedLocation : MonoBehaviour
{ 
    private static ConstructedLocation _LOC_SETUP;
    public static ConstructedLocation LOC_SETUP
    {
        get
        {
            if (_LOC_SETUP == null)
            {
                _LOC_SETUP = GameObject.FindObjectOfType<ConstructedLocation>();
            }
            return _LOC_SETUP;
        }
    }

    private static string locName = null;
    public string LocName
    {
        get { return locName; }
        set { locName = value; }
    }
    public static string elemType = null;
    public string ElemType
    {
        get { return elemType; }
        set { elemType = value; }
    }

    public static CardDeck deck = null;
    private static int startingAmount = 0;
    public int StartingAmount
    {
        get { return startingAmount; }
        set { startingAmount = value; }
    }

    private static bool placingCard = false;
    public bool PlacingCard
    {
        get { return placingCard; }
        set { placingCard = value; }
    }


    private static Dictionary<string, string> tempLocNames = new Dictionary<string, string>();
    public Dictionary<string, string> TempLocNames
    {
        get { return tempLocNames; }
    }



    private static List<GameElement> builtElements;
    public List<GameElement> BuiltElements
    {
        get { return builtElements; }
    }

    void Awake()
    {
        builtElements = GameInfo.GAMEINFO.Elements;
    }


    public void builElemLocation()
    {
        if (locName != null && elemType != null)
        {
            for (int i = 0; i < GameInfo.GAMEINFO.NumPlayers; i++)
            {
                if (elemType == "Cards")
                {
                    GameInfo.GAMEINFO.CardLocations.Add(locName+"_"+(i+1), new CardLocation(locName, i+1));
                }
                else
                {
                    GameInfo.GAMEINFO.ElementLocations.Add(locName+ "_"+(i+1), new ElementLocation(locName, elemType, i+1));
                }
                tempLocNames.Add(locName+"_"+(i+1), elemType);
                //Dictionary<string, Vector2> locs = GameInfo.GAMEINFO.Elements.Find(x => x.Name == elemType).getLocations();
                //locs.Add(locName, new Vector2(0,0)); 
            }
            Debug.Log("Loc created!");
            locName = null;
            setInputFields();
        } 
        else
        {
            Debug.Log("Need to have input selected");
        }
    }

    private void setInputFields()
    {
        GameObject.Find("name_txtInput").GetComponent<InputField>().text = locName;
    }

    public string location1;
    public string parseInput;

   
    public void build()
    {
        CardLocation primaryLocation = GameInfo.GAMEINFO.CardLocations[location1]; ;
        if (tempLocNames[location1] == "Cards")
        {
            //primaryLocation = GameInfo.GAMEINFO.CardLocations[location1];
        } else
        {
            //primaryLocation = GameInfo.GAMEINFO.ElementLocations[location1];
        }
        Parser parser = new Parser();
        parser.parse(parseInput);
        primaryLocation.Action = parser.actions[0];
        primaryLocation.Condition = parser.condition;

        Debug.Log(primaryLocation.Action.ToString());
        Debug.Log(primaryLocation.Condition.ToString());

        //primaryLocation.Action = new CardAction();
    }
}
