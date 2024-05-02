using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    public GameObject[] anomalies;

    public float currentAnomaly;
    public float currentLocation;
    public bool isAnomaly;

    int pastObject;

    public void NewAnomaly()
    {
        // Clears last anomaly
        SelfDestruct();

        // Specfiys values from array
        int currentIndex;
        int arrayLength = anomalies.Length;

        // Randomly choses new anomaly from array
        currentIndex = Random.Range(0, arrayLength);
        pastObject = currentIndex;
        anomalies[currentIndex].SetActive(true);

        // Gets script from new anomaly
        Anomaly anomaly = anomalies[currentIndex].GetComponent(typeof(Anomaly)) as Anomaly;

        // Sets current stats as new anomaly stats
        currentLocation = anomaly.locationID;
        currentAnomaly = anomaly.anomalyId;
        isAnomaly = anomaly.noAnomaly;
    }

    public void SelfDestruct()
    {
        // Deletes last anomaly
        anomalies[pastObject].SetActive(false);
    }
}