using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cagirici : MonoBehaviour
{
    bool isPaused = false;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject MainMenu;
    // Start is called before the first frame update

    void PauseEnable()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the game
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        else
        {
            // Resume the game
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }

    }
    private void Awake()
    {
        PauseMenu.SetActive(false);
    }
    void Start()
    {
        Time.timeScale = 1;
    }
    
    public void ResumeGame()
    {
        PauseEnable();
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

    // Update is called once per frame
    void Update()
    {
       
    }
    public void axxel()
    {
        SceneManager.LoadScene(2);
    }
    public void helia()
    {
        SceneManager.LoadScene(3);
    }
}
