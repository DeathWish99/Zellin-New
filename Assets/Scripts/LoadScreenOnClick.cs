using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadScreenOnClick : MonoBehaviour {
    public int lastscene;
    public int currScene;
    private int count=1;
    //SceneManager.GetActiveScene().buildIndex;
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private LoadScreenOnClick ()
    {

    }
    public void Loadbycurr ()
    {
        currScene = lastscene;
        //SceneManager.LoadScene(currScene);

        if (currScene>1 && currScene != 6)
        {
            SceneManager.LoadScene(currScene+=count);
            lastscene = currScene;
            
            count++;
            
        }
        else
        {
            SceneManager.LoadScene(currScene+=count+1);
            lastscene = currScene;
            count++;
           
        }
    }
}
