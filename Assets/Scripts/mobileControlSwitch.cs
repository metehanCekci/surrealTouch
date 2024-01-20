using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobileControlSwitch : MonoBehaviour
{
    public GameObject computerControlsUI;
    public GameObject mobileControlsUI;

    void Start()
    {
        // Baþlangýçta bilgisayar kontrollerini göster
        ShowComputerControls();
    }

    void Update()
    {
        // Platforma göre kontrolleri güncelle
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
