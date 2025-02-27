using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject loseCanvas;
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject optionsCanvas;





    void Start()
    {
        Time.timeScale = 1;
        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            OptionsButton();
        }

    }

    public void OptionsButton()
    {
        if (optionsCanvas.activeInHierarchy) 
        {
             optionsCanvas.SetActive(false);
             Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            optionsCanvas.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;

        }
    }

    public void ResumeButton() 
    {
        optionsCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }

    public void Lose()
    {
        loseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    
    

    public void Win()
    {
        winCanvas.SetActive(true);
        Time.timeScale = 0;
    }

}
