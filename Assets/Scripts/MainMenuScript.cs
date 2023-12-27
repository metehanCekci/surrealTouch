using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject mainMenu;


    private void Awake()
    {
        openMain();
    }
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void axxel()
    {

    }
    public void closeMain() 
    {
        SceneManager.LoadScene(1);
    }

    public void openMain() 
    {
        mainMenu.SetActive(true);
    }
}
