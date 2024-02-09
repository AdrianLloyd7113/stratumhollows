using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildBtn : MonoBehaviour
{
    Button btn;
    public GameObject canvas1;
    public GameObject canvas2;

    void Start()
    {
        canvas2.SetActive(false);

        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }
}
