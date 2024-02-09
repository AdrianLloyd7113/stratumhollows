using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorderStatsLoader : MonoBehaviour
{
    public GameObject app;
    public GameObject pop;

    void Start()
    {
        app = GameObject.Find("applicants");
        pop = GameObject.Find("borderpopulation");
    }

    void Update()
    {
        app.GetComponent<Text>().text = "Applicants: " + PlayerPrefs.GetFloat("Applicants");
        pop.GetComponent<Text>().text = "Population: " + PlayerPrefs.GetFloat("Population");
    }
}
