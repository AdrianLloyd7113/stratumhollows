using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnOnEnter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return)){
            SceneManager.LoadScene(PlayerPrefs.GetString("Scene"), LoadSceneMode.Single);
        } else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
            if (PlayerPrefs.GetString("Scene").Contains("Level")){
                SceneManager.LoadScene("Map", LoadSceneMode.Single);   
            }else{
                SceneManager.LoadScene("Faction", LoadSceneMode.Single);
            }
        }
    }
}
