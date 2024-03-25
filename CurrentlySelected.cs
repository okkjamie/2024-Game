using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CurrentlySelected : MonoBehaviour
{
    public string currentlySelectedPlace = null;
    public string currentlySelectedAnomoly = null;

    public GameObject whereAnomolyGUI;
    public GameObject pickAnomolyGUI;
    public GameObject laptop;
    public GameObject Alarm;
    public GameObject comp;
    
    int enteredPlace;
    int enteredAnomoly;

    public void Start()
    {
        
    }
    
 
    public void OnClicked(Button button)
    {
        currentlySelectedPlace = button.name;
        int.TryParse(currentlySelectedPlace, out enteredPlace);
    }

    public void OnClicked2(Button button)
    {
        currentlySelectedAnomoly = button.name;
        int.TryParse(currentlySelectedAnomoly, out enteredAnomoly);
    }


    public void EnteredNext()
    {
       TimeManager time = Alarm.GetComponent(typeof(TimeManager)) as TimeManager;
        time.enteredAnomoly = enteredAnomoly;
        whereAnomolyGUI.SetActive(true);
        pickAnomolyGUI.SetActive(false);
    }

    public void Close()
    {
        TimeManager time = Alarm.GetComponent(typeof(TimeManager)) as TimeManager;
        time.enteredPlace = enteredPlace;
        whereAnomolyGUI.SetActive(false);
        pickAnomolyGUI.SetActive(true);
        laptop.SetActive(false);
        Computer computer = comp.GetComponent(typeof(Computer)) as Computer;
        computer.Close();
    }
}