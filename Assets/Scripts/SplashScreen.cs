using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashScreen : MonoBehaviour {
    public Image splashImage;
    public Text splashText;


    void FadeIn()
    {
        splashImage.CrossFadeAlpha(1.0f, 0.5f, false);

    }
    void FadeOut()
    {
        splashImage.CrossFadeAlpha(0.0f, 1.5f, false);

    }

    IEnumerator Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);


        FadeIn();
        yield return new WaitForSeconds(1.5f);
        FadeOut();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }
    
   
	
}
