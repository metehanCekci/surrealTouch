using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobileControlSwitch : MonoBehaviour
{
    public GameObject computerControlsUI;
    public GameObject mobileControlsUI;

    void Start()
    {
        // Ba�lang��ta bilgisayar kontrollerini g�ster
        ShowComputerControls();
    }

    void Update()
    {
        // Platforma g�re kontrolleri g�ncelle
        if (Application.isMobilePlatform)
        {
            ShowMobileControls();
        }
        else
        {
            ShowComputerControls();
        }
    }

    void ShowComputerControls()
    {
        computerControlsUI.SetActive(true);
        mobileControlsUI.SetActive(false);
    }

    void ShowMobileControls()
    {
        computerControlsUI.SetActive(false);
        mobileControlsUI.SetActive(true);
    }
}
