using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;


public class DialogueLine : MonoBehaviour
{
    public Text text;
    public float timeRemaining = 1000;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        text.text = "Burasý neresi?";
        timeRemaining = 15;
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        text.text = "Buradan çýkmam lazým.";
        timeRemaining = 15;
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        text.text = null;
    }
}