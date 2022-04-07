using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour
{
    private static GameInfo _GAMEINFO;

    public static GameInfo GAMEINFO
    {
        get
        {
            if (_GAMEINFO == null)
            {
                _GAMEINFO = GameObject.FindObjectOfType<GameInfo>();
            }
            return _GAMEINFO;
        }
    }


    private static string gameName = "Game";
    public string GameName
    {
        get { return gameName; }
        set { gameName = value; }
    }

    private static Sprite boardImage;
    public void setBoard(Sprite b) { boardImage = b; }
    public Sprite getBoard() { return boardImage; }

    private static int numPlayers = 1;
    public int NumPlayers
    {
        get { return numPlayers; }
        set { numPlayers = value; }
    }

    private static bool hasDeckOfCards;
    public bool HasDeckOfCards
    {
        get { return hasDeckOfCards; }
        set { hasDeckOfCards = value; }
    }

    private static CardDeck deckOfCards;
    public CardDeck DeckOfCards
    {
        get { return deckOfCards; }
        set { deckOfCards = value; }
    }

    /* private static Dictionary<string, Vector2> cardLocations = new Dictionary<string, Vector2>();
     public Dictionary<string, Vector2> CardLocations
     {
         get { return cardLocations; }
         set { cardLocations = value; }
     }*/

    private static Dictionary<string, ElementLocation> elementLocations = new Dictionary<string, ElementLocation>();
    public Dictionary<string, ElementLocation> ElementLocations
    {
        get { return elementLocations; }
    }

    private static Dictionary<string, CardLocation> cardLocations = new Dictionary<string, CardLocation>();
    public Dictionary<string, CardLocation> CardLocations
    {
        get { return cardLocations; }
    }

    private static List<GameElement> elements = new List<GameElement>();
    public List<GameElement> Elements
    {
        get { return elements; }
        set { elements = value; }
    }

    public string curElem;
    public Sprite curImg;
    public void buildCurElement()
    {
        if (curElem != null && curImg != null)
        {
            createGameElement(curElem, curImg);
            curElem = null;
            curImg = null;
            GameObject.Find("name_txtInput").GetComponent<InputField>().text = curElem;
            GameObject.Find("image_btn").GetComponent<Button>().GetComponent<Image>().sprite = curImg;
            Debug.Log("Element created!");
        } 
        else
        {
            Debug.Log("Fields cannot be empty");
        }
            
    }

    public void createGameElement(string en, Sprite es)
    {
        //Creates a gameElement with specified attributes
        GameElement newElem = new GameElement(en);
        newElem.setImage(es);
        elements.Add(newElem);
    }
}
