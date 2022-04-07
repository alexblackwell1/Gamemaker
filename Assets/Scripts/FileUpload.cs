using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;
using System.IO;

public class FileUpload : MonoBehaviour
{
    public GameObject button;
    private Sprite selectedImage;
    public String buttonName;

    void Start()
    {
        //button = GameObject.Find("Canvas").transform.Find(buttonName).gameObject;
    }

    public void loadImage(string imageOf)
    {
        selectedImage = openExplorer(imageOf);
        if (selectedImage == null) return;
        switch (imageOf) 
        {
            case "Boards":
                button.GetComponent<Image>().sprite = selectedImage;
                button.GetComponentInChildren<Text>().enabled = false;
                GameInfo.GAMEINFO.setBoard(selectedImage);
                break;
            case "GameElements":
                button.GetComponent<Image>().sprite = selectedImage;
                button.GetComponentInChildren<Text>().enabled = false;
                GameInfo.GAMEINFO.curImg = selectedImage;
                //ConstructedElement.ELEM_SETUP.setElemImage(selectedImage);
                break;
        }
    }

    public Sprite openExplorer(string imageOf)
    {
        //Open file explorer and look for jpg/png file types
        string filePath = EditorUtility.OpenFilePanel("Game Board", "", "jpg,png");
        //If file path exists
        if (filePath.Length != 0)
        {
            Debug.Log(filePath);
            string[] splitF = filePath.Split('/');
            string fname = splitF[splitF.Length - 1];

            //If the file is not already present in the the directory
            if (!File.Exists("Assets/Resources/" + imageOf + "/" + fname))
            {
                //Copy the image into the Boards folder with its name
                File.Copy(filePath, "Assets/Resources/"+ imageOf + "/" + fname);
                
            }
            return convertToSprite("Assets/Resources/" + imageOf + "/" + fname);
        }
        return null;
    }

    // Code from https://forum.unity.com/threads/generating-sprites-dynamically-from-png-or-jpeg-files-in-c.343735/
    private Sprite convertToSprite(string filePath)
    {
        Texture2D SpriteTexture = LoadTexture(filePath);
        Sprite NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), 100.0f, 0, SpriteMeshType.FullRect);
        return NewSprite;
    }

    private Texture2D LoadTexture(string FilePath)
    {
        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(FilePath))
        {
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);
            if (Tex2D.LoadImage(FileData))
            {
                return Tex2D;
            }
        }
        return null;
    }
}
