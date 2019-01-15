using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScreenOnClick : MonoBehaviour {
    public int currScene = SceneManager.GetActiveScene().buildIndex;
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void LoadBycurr(int indexscene)
    {
        //SceneManager.LoadScene(currScene);
        if (currScene != 6)
        {
            SceneManager.LoadScene(currScene=currScene + 1);
            
        }
        else
        {
            SceneManager.LoadScene(currScene=currScene + 2);
        }
    }
}
