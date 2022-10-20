using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //public void LoadNextScene()
    //{
    //    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;// Get current scene and create index for it
    //    SceneManager.LoadScene(currentSceneIndex + 1);
    //}
    private void Start()
    {
        Debug.Log("It's me motherfucker!");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Time.timeScale = 1;
        //FindObjectOfType<GameSession>().ResetScore();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
