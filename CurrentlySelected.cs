using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CurrentlySelected : MonoBehaviour
{   
    [Header("Debug")]
    // These are debug to know what you've selected 
    public string currentlySelectedPlace = null;
    public string currentlySelectedAnomaly = null;

    [Header("GUI")]
    // The GUI where you chose where the anomaly is
    public GameObject whereAnomalyGUI;
    // The GUI where you chose the type of anomaly
    public GameObject pickAnomalyGUI;
    
    [Header("Models")]
    // The laptop model
    public GameObject laptop;
    // The alarm clock model
    public GameObject alarm;
    // The computer model
    public GameObject comp;

    // ID numbers for entered place and anomaly
    int enteredPlace;
    int enteredAnomaly;

    // When selecting the anomalys location, store info
    public void OnClickedPlace(Button button)
    {
        currentlySelectedPlace = button.name;
        int.TryParse(currentlySelectedPlace, out enteredPlace);
    }

    // When selecting the anomaly type, store info
    public void OnClickedAnomaly(Button button)
    {
        currentlySelectedAnomaly = button.name;
        int.TryParse(currentlySelectedAnomaly, out enteredAnomaly);
    }

    // When opening next GUI, pass info through to manager
    public void EnteredNext()
    {
        // Gets the time manager
        TimeManager time = alarm.GetComponent(typeof(TimeManager)) as TimeManager; 
        // Passes info to manager
        time.enteredAnomaly = enteredAnomaly;

        // Close current GUI, opens next GUI
        whereAnomalyGUI.SetActive(true);
        pickAnomalyGUI.SetActive(false);
    }

    // When closing GUI, pass info through to manager
    public void Close()
    {
        // Gets the time manager
        TimeManager time = alarm.GetComponent(typeof(TimeManager)) as TimeManager;
        // Passes info to manager
        time.enteredPlace = enteredPlace;

        // Close current GUI, opens first GUI for when the computer is next used
        whereAnomalyGUI.SetActive(false);
        pickAnomalyGUI.SetActive(true);

        // Changes computer screen
        laptop.SetActive(false);

        // Gets the time Computer Script
        Computer computer = comp.GetComponent(typeof(Computer)) as Computer;
        computer.Close();
    }
}