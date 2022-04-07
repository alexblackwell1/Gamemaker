using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LocationHandler : MonoBehaviour
{
    public ConstructedLocation locInfo;
    public DragAndDrop DaD;
    public Text textField;
   

    private static int locCount;
    private string curElem;
    private string curLoc;
    // Start is called before the first frame update
    void Awake()
    {
        curElem = locInfo.TempLocNames.ElementAt(0).Value;
        if (curElem == null)
        {
            curElem = "Cards";
        }
        //curElem = locInfo.TempLocNames.ElementAt(0).Value;
        curLoc = locInfo.TempLocNames.ElementAt(0).Key;
        //DaD.curElem = curElem;
        //DaD.curLoc = curLoc;
        //Debug.Log(curLoc + "   " + curElem);
        locCount = 0;
        textField.text = "Click to add location " + curLoc + " for element " + curElem;
    }

   
    public int getLocationCords(Vector3 lV)
    {
        locCount++;
        if (curElem == "Cards")
        {
            //GameInfo.GAMEINFO.CardLocations.Add(curLoc, new Vector2(lV.x, lV.y));
            CardLocation cl = GameInfo.GAMEINFO.CardLocations[curLoc];//.Add(curLoc, new CardLocation(curLoc));
            cl.boardLocation = lV;
            
        }
        else
        {
            ElementLocation e1 = GameInfo.GAMEINFO.ElementLocations[curLoc];
            e1.boardLocation = lV;
            //GameElement cur = locInfo.BuiltElements.Find(x => x.Name == curElem);
            //cur.getLocations().Add(curLoc, new Vector2(lV.x, lV.y));
        }

        if (locCount < locInfo.TempLocNames.Count) {
            curElem = locInfo.TempLocNames.ElementAt(locCount).Value;
            curLoc = locInfo.TempLocNames.ElementAt(locCount).Key;
            textField.text = "Click to add location " + curLoc + " for element " + curElem;
            return locCount;
        }
        GameInfo.GAMEINFO.Elements = locInfo.BuiltElements;
        return -1;
    }


    /*    private void getElementLocations()
        {
            foreach (var item in locInfo.TempLocNames)
            {
                textField.text = "Click to add location " + item.Key + " for element " + item.Value;
            }
        }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
