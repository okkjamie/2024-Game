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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewAnomaly()
    {
        SelfDestruct(); //clears last anomaly

        int currentIndex;
        int arrayLength = anomalies.Length;

        currentIndex = Random.Range(0, arrayLength);
        pastObject = currentIndex;
        anomalies[currentIndex].SetActive(true);

        Anomaly anomaly = anomalies[currentIndex].GetComponent(typeof(Anomaly)) as Anomaly;
        currentLocation = anomaly.locationID;
        currentAnomaly = anomaly.anomalyId;
        isAnomaly = anomaly.noAnomaly;
    }

    public void SelfDestruct()
    {
        anomalies[pastObject].SetActive(false);
    }
}
