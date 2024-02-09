using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningSceneText : MonoBehaviour
{
    
    public GameObject[] texts;
    int i = 0;

    void Start(){
        for (int f = 1; f < 5; f++){
            texts[f].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return)){
            i++;

            if (i == 5){
                SceneManager.LoadScene("Map", LoadSceneMode.Single);
            }else{
                texts[i-1].SetActive(false);
                texts[i].SetActive(true);
            }
        }
    }
}
