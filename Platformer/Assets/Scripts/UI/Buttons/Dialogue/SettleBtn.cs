using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettleBtn : MonoBehaviour
{
    Button btn;
    InputField input;
    void Start()
    {
        input = GameObject.Find("faction").GetComponent<InputField>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        PlayerPrefs.SetString("FactionName", input.text);
        PlayerPrefs.SetFloat("Gold", 100);
        PlayerPrefs.SetFloat("Resources", 100);
        PlayerPrefs.SetFloat("Population", 1);
        PlayerPrefs.SetFloat("Level", 1);
        PlayerPrefs.SetFloat("JumpHeight", 4);
        PlayerPrefs.SetFloat("Applicants", 0);
        PlayerPrefs.SetFloat("OwnsResidence", 0);
        PlayerPrefs.SetFloat("OwnsFitnessCenter", 0);

        Debug.Log(PlayerPrefs.GetString("FactionName"));
        SceneManager.LoadScene("Faction", LoadSceneMode.Single);
    }
}
