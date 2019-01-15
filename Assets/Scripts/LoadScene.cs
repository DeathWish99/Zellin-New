using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/*
 * Modified by Abia P.H.
 * 5 November 2018
 */

public class LoadScene : UnityEngine.MonoBehaviour {
    public int index = 3;
	
    public void ChangeScene(int index) { 
           SceneManager.LoadScene(index);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(LevelData.CurrLevelIndex);
    }

    public void MainMenu()
    {
        LevelData.ResetLevel();
        SceneManager.LoadScene("MainMenu");
    }
}
