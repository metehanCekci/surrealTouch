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
        // Baþlangýçta bilgisayar kontrollerini göster
        ShowComputerControls();
    }

    void Update()
    {
        // Platforma göre kontrolleri güncelle, sonra da kendini yok et,
        // not: sorun kontrollerin tekrar tekrar güncellenmesinden kaynaklanýyormuþ
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
