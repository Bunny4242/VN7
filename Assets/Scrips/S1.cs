using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class S1 : MonoBehaviour
{
    public TextAsset textFile;
    string[] line = new string[10];
    string[] names = {" ","MIRUN"};
    Text textDisplay;
    int currentLine = 0;
    TW_MultiStrings_Regular tw;



    void Awake()
    {
        string allText = textFile.text;
        textDisplay = GameObject.Find("Text").GetComponent<Text>();
        //textDisplay.text = line[currentLine];
        tw = GameObject.Find("Text").GetComponent<TW_MultiStrings_Regular>();
        tw.MultiStrings = allText.Split("\n");
        textDisplay.text = tw.MultiStrings[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentLine++;
            if (currentLine >= 12)
            {
                if (SceneManager.GetActiveScene().name.CompareTo("S1") == 0)
                {
                    SceneManager.LoadScene("S2");
                }
                
            }
            else tw.NextString();
            
        }
        
    }
    void displayText()
    {
        string[] tmp = new string[2];
        tmp = line[currentLine].Split("//");
        int cNumber = int.Parse(tmp[0]);
        string txt = "";
        if (cNumber > 0) txt = names[cNumber] + " : " + tmp[1];
        else txt = tmp[1];
        textDisplay.text = txt;
    }
}
