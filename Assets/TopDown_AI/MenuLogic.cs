using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuLogic : MonoBehaviour
{
    public GameObject pauseCanvas, player_go;
    private bool firstLaunch = true;

    // Use this for initialization
	// void Start () {
    //     if(firstLaunch){
    //         firstLaunch = false;
    //         pauseCanvas.SetActive(false); 
    //     }
	// }
    public void launchGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void resumeGame()
    {
        Debug.Log("Resume Game");
        pauseCanvas.SetActive(false);

        Time.timeScale = 1;
        player_go.SetActive(true);
    }
}
