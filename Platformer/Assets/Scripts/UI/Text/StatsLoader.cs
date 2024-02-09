using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsLoader : MonoBehaviour
{

    public GameObject gold;
    public GameObject resources;
    public GameObject level;
    public GameObject population;

    void Start()
    {
        gold = GameObject.Find("gold");
        resources = GameObject.Find("resources");
        level = GameObject.Find("level");
        population = GameObject.Find("population");
    }

    void Update()
    {
        gold.GetComponent<Text>().text = "Gold: " + PlayerPrefs.GetFloat("Gold");
        resources.GetComponent<Text>().text = "Resources: " + PlayerPrefs.GetFloat("Resources");
        level.GetComponent<Text>().text = "Faction Level: " + PlayerPrefs.GetFloat("Level");
        population.GetComponent<Text>().text = "Faction Population: " + PlayerPrefs.GetFloat("Population");
    }
}
