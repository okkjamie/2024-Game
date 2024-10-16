using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class SplashScreen : MonoBehaviour 
{

    public string NextScene;
    public float TimeTillFadeOut;
    public float TimeTillNextScene;
 
    IEnumerator Start()
    {
        yield return new WaitForSeconds(TimeTillFadeOut);
        yield return new WaitForSeconds(TimeTillNextScene);
        SceneManager.LoadScene(NextScene);
    }
}

