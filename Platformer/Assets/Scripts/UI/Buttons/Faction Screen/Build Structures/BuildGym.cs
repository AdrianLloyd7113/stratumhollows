using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildGym : MonoBehaviour
{
    Button btn;

    void Start()
    {
        if (PlayerPrefs.GetInt("OwnsFitnessCenter") == 1){
            gameObject.SetActive(false);
        }

        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (PlayerPrefs.GetFloat("Resources") >= 350){
            gameObject.SetActive(false);
            PlayerPrefs.SetFloat("Resources", PlayerPrefs.GetFloat("Resources") - 350);
            PlayerPrefs.SetInt("OwnsFitnessCenter", 1);
            GameObject.Find("gymbtn").SetActive(true);
        }
    }
}
