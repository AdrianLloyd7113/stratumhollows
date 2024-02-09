using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameBtn : MonoBehaviour
{
    Button btn;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        PlayerPrefs.SetString("Scene", "Level1");
        SceneManager.LoadScene("OpeningScene", LoadSceneMode.Single);
    }
}
