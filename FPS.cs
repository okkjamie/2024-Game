using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FPS : MonoBehaviour
{
    public int avgFrameRate;
     public TMP_Text m_TextComponent;
 
    public void Update ()
    {
        float current = 0;
        current = Time.frameCount / Time.time;
        avgFrameRate = (int)current;
        m_TextComponent.text = avgFrameRate.ToString() + " FPS";
    }
}
