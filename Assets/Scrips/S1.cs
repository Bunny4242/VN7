using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S1 : MonoBehaviour
{
    public TextAsset textFile;
    string[] line = new string[10];
    Text textDisplay;


    void Start()
    {
        string allText = textFile.text;
        line = allText.Split("\n");
        textDisplay = GameObject.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textDisplay.text = line[0];
    }
}
