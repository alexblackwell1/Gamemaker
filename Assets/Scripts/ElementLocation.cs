using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementLocation : Location
{
    private string name;
    public string elementType;
    private int numElements;
    private ActionEvent action;
    public Vector3 boardLocation;
    public int playerNum;

    public ElementLocation(string n, string etype, int pnum)
    {
        name = n;
        elementType = etype;
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
    ActionEvent Action
    {
        set { action = value; }
    }

    public GameObject img;

    public void setElemObjImg(Sprite s)
    {
        img.GetComponent<Image>().sprite = s;
    }

    public void onTap()
    {

    }

    public void check()
    {

    }

}
