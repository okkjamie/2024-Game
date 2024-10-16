using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;


public class GlobalVolumeManager : MonoBehaviour
{
    public GameObject[] globalVolumes;
    
    public Volume volume; // Reference to the Volume component
    private Exposure exposure;


    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeLevel(int current)
    {
        globalVolumes[0].SetActive(false);
        globalVolumes[1].SetActive(false);
        globalVolumes[2].SetActive(false);

        globalVolumes[current].SetActive(true);
    }

    public void ChangeBrightness(float value)
    {
        value = value * -1;
        if (volume.profile.TryGet(out exposure))
        {
            exposure.fixedExposure.value = value;
        }
    }

}
