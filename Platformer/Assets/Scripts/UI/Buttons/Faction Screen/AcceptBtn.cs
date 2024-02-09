using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcceptBtn : MonoBehaviour
{
    Button btn;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {

        if (PlayerPrefs.GetInt("OwnsResidence") == 1){
            PlayerPrefs.SetFloat("Population", PlayerPrefs.GetFloat("Population") + PlayerPrefs.GetFloat("Applicants"));
            PlayerPrefs.SetFloat("Applicants", 0);
        }
    }
}
