using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildResidences : MonoBehaviour
{
    Button btn;

    void Start()
    {
        if (PlayerPrefs.GetInt("OwnsResidence") == 1){
            gameObject.SetActive(false);
        }

        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (PlayerPrefs.GetFloat("Resources") >= 100){
            gameObject.SetActive(false);
            PlayerPrefs.SetFloat("Resources", PlayerPrefs.GetFloat("Resources") - 100);
            PlayerPrefs.SetInt("OwnsResidence", 1);
            GameObject.Find("resbtn").SetActive(true);
        }
    }
}
