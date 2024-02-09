using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CloseBtn : MonoBehaviour
{
    Button btn;
    GameObject canvas;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        canvas = GameObject.Find("CommandCanvas");
    }

    void TaskOnClick()
    {
        canvas.SetActive(false);
    }
}
