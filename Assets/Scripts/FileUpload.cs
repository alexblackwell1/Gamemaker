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
    private Sprite selectedBoard;
    public String buttonName;

    void Start()
    {
        //button = GameObject.Find("Canvas").transform.Find(buttonName).gameObject;
    }

    public void openExplorer()
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
            if (!File.Exists("Assets/Resources/Boards/" + fname))
            {
Debug.Log("File not found, copying");
                //Copy the image into the Boards folder with its name
                File.Copy(filePath, "Assets/Resources/Boards/" + fname);
                
            }
            Sprite selectedBoard = convertToSprite("Assets/Resources/Boards/" + fname);
            button.GetComponent<Image>().sprite = selectedBoard;
            button.GetComponentInChildren<Text>().enabled = false;

            GameInfo.GAMEINFO.setBoard(selectedBoard);
        }
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
