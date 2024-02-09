using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseBorder : MonoBehaviour
{
    Button btn;
    GameObject canvas;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        canvas = GameObject.Find("BorderCanvas");
    }

    void TaskOnClick()
    {
        canvas.SetActive(false);
    }
}
