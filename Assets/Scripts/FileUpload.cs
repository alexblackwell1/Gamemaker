using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class FileUpload : MonoBehaviour
{
    public static void openExplorer() {
        //Open file explorer and look for jpg/png file types
        string filePath = EditorUtility.OpenFilePanel("Game Board", "", "jpg,png");
        //If file path exists
        if (filePath.Length != 0) {
            Debug.Log(filePath);
            string[] splitF = filePath.Split('/');
            string fname = splitF[splitF.Length-1];
            //Copy the image into the Boards folder with its old name
            System.IO.File.Copy(filePath, Path.Combine("Assets/Boards/", fname));
        }
    }   

}
