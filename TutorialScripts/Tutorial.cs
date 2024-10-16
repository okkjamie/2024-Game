using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public int IsFirst; 


    void Start()
    {
        

        IsFirst = PlayerPrefs.GetInt("IsFirst");
        if (IsFirst == 0) 
        {
            Debug.Log("you smell why do u play my game!");
            StartCoroutine(EndFirst());
            
        } else { 
            //Do stuff other times
            Debug.Log("welcome again!");
        }

        DontDestroyOnLoad(this.gameObject);
    }

     IEnumerator EndFirst()
    {
        yield return new WaitForSeconds(30f);
        PlayerPrefs.SetInt("IsFirst", 1);
    }
}
