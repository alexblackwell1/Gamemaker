using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LayoutBoard : MonoBehaviour
{
    public GameObject board;
    public GameObject elemPF;
    public GameObject cardPF;
    public List<GameObject> locations = new List<GameObject>();
    public List<GameObject> cardLocations = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        //If a board was selected, set board
        if (GameInfo.GAMEINFO.getBoard() != null)
        {
            board.GetComponent<Image>().sprite = GameInfo.GAMEINFO.getBoard();
        }


        //For each game elemen, go through its locations and create a gameobject at each location
        //List<GameElement> elems = GameInfo.GAMEINFO.Elements;
        Dictionary<string, ElementLocation> elems = GameInfo.GAMEINFO.ElementLocations;
        for (int i = 0; i < elems.Count; i++)
        {
            //Dictionary<string, Vector2> elemLocs = elems[i].getLocations();
            string locName = elems.ElementAt(i).Key;
            GameObject loc = new GameObject(locName);
            loc.transform.SetParent(GameObject.Find("Canvas").transform, false);
            loc.transform.position = elems.ElementAt(i).Value.boardLocation;

            GameObject gObj = Instantiate(elemPF, new Vector3(0, 0, 0), transform.rotation);
            gObj.transform.SetParent(GameObject.Find(locName).transform, false);
            Location _loc = gObj.GetComponent<Location>();
            _loc.setElemObjImg(elems.ElementAt(i).Value.img.GetComponent<Sprite>());
        }

        //Dictionary<string, Vector2> cardLocs = GameInfo.GAMEINFO.CardLocations;
        Dictionary<string, CardLocation > cardLocs = GameInfo.GAMEINFO.CardLocations;
        for (int i = 0; i < cardLocs.Count; i++)
        {
            string locName = cardLocs.ElementAt(i).Key;
            GameObject loc = new GameObject(locName);
            loc.transform.SetParent(GameObject.Find("Canvas").transform, false);
            loc.transform.position = cardLocs[locName].boardLocation;
            //cardLocations.Add(loc);

            GameObject cardBack = Instantiate(cardPF, new Vector3(0, 0, 0), transform.rotation);
            Sprite cardSprite = Resources.Load<Sprite>("GameElements/cardBack");
            cardBack.transform.SetParent(GameObject.Find(locName).transform, false);
            cardBack.transform.localScale = new Vector3(.8f,1.161f,1f);
            Location l = cardBack.GetComponent<Location>();
            l.setElemObjImg(cardSprite); 
        }
        

        //CurrentGameInfo.CUR_GAME.cardObjLocations = cardLocations;
        //CurrentGameInfo.CUR_GAME.DeckButton = cardBack;
        //Debug.Log(GameObject.Find("ElemButton").name);
    }

}
