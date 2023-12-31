using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class healthTracker : MonoBehaviour
{

    public movementScript mv;
    public TMP_Text tp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tp.text = mv.hp.ToString();
    }
}
