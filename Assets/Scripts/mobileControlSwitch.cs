using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobileControlSwitch : MonoBehaviour
{
    public GameObject computerControl;
    public GameObject computerControlsUI;
    public GameObject mobileControlsUI;

    void Start()
    {
        // Ba�lang��ta bilgisayar kontrollerini g�ster
        ShowComputerControls();
    }

    void Update()
    {
        // Platforma g�re kontrolleri g�ncelle, sonra da kendini yok et,
        // not: sorun kontrollerin tekrar tekrar g�ncellenmesinden kaynaklan�yormu�
        StartCoroutine(setControl());
    }

    void ShowComputerControls()
    {
        
        computerControlsUI.SetActive(true);
        mobileControlsUI.SetActive(false);
    }

    void ShowMobileControls()
    {
        Destroy(computerControl);
        computerControlsUI.SetActive(false);
        mobileControlsUI.SetActive(true);
    }

    IEnumerator setControl() 
    {
        if (Application.isMobilePlatform)
        {
            ShowMobileControls();
        }
        else
        {
            ShowComputerControls();
            
        }
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
        
    }
}
