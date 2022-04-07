using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class PhysicalCard : MonoBehaviour
{
    private string suit;
    private string rank;
    public Button faceField;

    public CardCondition condition;

    public string getRank() { return this.rank; }
    public string getSuit() { return this.suit; }
    
    //[SerializeField] private Image _face;
    //private Sprite cardFace;

    

    // Start is called before the first frame update
    void Start()
    {
        //faceField = GameObject.Find("Canvas").transform.Find("Face").gameObject;
        
    }

    public void setCard(string s, string r)
    {
        if (s == "_" && r == "_")
        {
            faceField.GetComponent<Image>().sprite = Resources.Load<Sprite>("Assets/Resources/GameElements/cardBack");
        } else
        {
            this.suit = s;
            this.rank = r;
            string name = s + r;
            //Debug.Log(name);
            //var cardFace = Resources.Load<Sprite>(Path.Combine());
            //var cardFace = Resources.Load<Sprite>("GameElements/PlayingCards/SA");
            faceField.GetComponent<Image>().sprite = Resources.Load<Sprite>("GameElements/PlayingCards/"+name);
        }
    }

    public ActionEvent action;
    public void setOnClick(ActionEvent ae)
    {   
        action = ae;
        faceField.onClick.AddListener( wrapper );
    }

    private void wrapper()
    {
        action.interact();
    }
}
