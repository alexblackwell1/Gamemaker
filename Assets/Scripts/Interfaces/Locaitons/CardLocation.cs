using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardLocation : Location
{
    private string name;
    private int numElements;
    public Vector3 boardLocation;
    public int playerNum;
    public PhysicalCard cardSceneObj;

    public CardAction action;
    public CardCondition condition;


    public CardLocation(string n, int pnum)
    {
        name = n;
        numElements = 0;
        playerNum = pnum;  
    }

    string Location.Name
    {
        get { return name; }
        set { name = value; }
    }
    int Location.NumElements
    {
        get { return numElements; }
        set { numElements = value; }
    }
    public CardAction Action
    {
        get { return action; }
        set { action = value; }
    }

    public CardCondition Condition
    {
        set { condition = value; }
        get { return condition; }
    }

    public CardDeck cardDeck;
    public GameObject img;
     

    public void setShowingCard(string s)
    {
        cardSceneObj.setCard(s.Substring(0,1), s.Substring(1));
    }

    //Dont use
    public void setElemObjImg(Sprite s)
    {
        cardSceneObj.faceField.GetComponent<Image>().sprite = s;
    }

    public void onTap()
    {

    }

    public void check()
    {

    }
}
