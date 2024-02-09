using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandCenter : MonoBehaviour
{

    Button btn;
    GameObject canvas;

    void Start()
    {
        canvas = GameObject.Find("CommandCanvas");
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        canvas.SetActive(false);

    }

    void TaskOnClick()
    {
        canvas.SetActive(true);
    }
}
