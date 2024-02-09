using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseBuildCanvas : MonoBehaviour
{

    Button btn;
    GameObject canvas;
    GameObject prevCanvas;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        canvas = GameObject.Find("BuildCanvas");
        prevCanvas = GameObject.Find("CommandCanvas");
    }

    void TaskOnClick()
    {
        canvas.SetActive(false);
        prevCanvas.SetActive(true);
    }
}
