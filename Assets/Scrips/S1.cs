using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class S1 : MonoBehaviour
{
    public TextAsset textFile;
    string[] line = new string[10];
    string[] names = { "MIRUN", "ROSE" };
    Text textDisplay , textName;
    int currentLine = 0;
    TW_MultiStrings_Regular tw;
    FadeCanvas fadeCanvas;



    void Awake()
    {
        string allText = textFile.text;
        line = allText.Split("\n");
        textDisplay = GameObject.Find("Text").GetComponent<Text>();
        textName = GameObject.Find("TextName").GetComponent<Text>();
        tw = GameObject.Find("Text").GetComponent<TW_MultiStrings_Regular>();
        fadeCanvas = GameObject.Find("Canvas").GetComponent<FadeCanvas>();
        tw.MultiStrings = allText.Split("\n");
        displayName();
    }

    void Start()
    {
        fadeCanvas.ShowUI();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentLine++;
            if (currentLine >= 10)
            {
                if (SceneManager.GetActiveScene().name.CompareTo("S1") == 0)
                {
                    fadeCanvas.HideUI();
                }
            }
            else
            {
                displayName();
                tw.NextString();
            }
        }
    }

    void displayName()
    {
        string[] tmp = new string[2];
        tmp = tw.MultiStrings[currentLine].Split(":");
        tw.MultiStrings[currentLine] = tmp[1];
        int cNumber = int.Parse(tmp[0]);
        textName.text = names[cNumber];
        if (currentLine == 0) textDisplay.text = tmp[1];
        
    }
}
