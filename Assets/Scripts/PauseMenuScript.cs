using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject ctrlButtons;
    bool isPaused = false;

    // Start is called before the first frame update

    private void Awake()
    {
        PauseMenu.SetActive(false);
    }

    void Start()
    {
        Time.timeScale = 1;
    }

    
   
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseEnable()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the game
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            ctrlButtons.SetActive(false);
        }
        else
        {
            // Resume the game
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
            ctrlButtons.SetActive(true);
        }

    }

    

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

    }

    public void QuitGame() 
    {
        PauseMenu.SetActive(false);
        SceneManager.LoadScene(0);
    }

    

    
}
