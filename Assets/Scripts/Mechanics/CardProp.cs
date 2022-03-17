using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class CardProp : MonoBehaviour
{
    private string suit;
    private string rank;
    public GameObject faceField;
    
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
        this.suit = s;
        this.rank = r;
        string name =  s + r;
        //Debug.Log(name);
        var cardFace = Resources.Load<Sprite>(Path.Combine("GameElements/PlayingCards/", name));
        //var cardFace = Resources.Load<Sprite>("GameElements/PlayingCards/SA");
        faceField.GetComponent<Image>().sprite = cardFace;
    }

    
    
}
