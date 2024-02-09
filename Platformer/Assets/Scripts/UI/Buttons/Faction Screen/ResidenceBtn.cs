using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResidenceBtn : MonoBehaviour
{
    Button btn;
    void Start()
    {
        if (PlayerPrefs.GetInt("OwnsResidence") == 1){
            gameObject.SetActive(true);
        }else{
            gameObject.SetActive(false);
        }

        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        
    }
}
