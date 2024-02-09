using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{

    char index = '1';
    GameObject marker;

    void Start()
    {
        marker = GameObject.Find("marker");

        if (PlayerPrefs.GetString("Scene").Contains("Level")){
            char[] chars = PlayerPrefs.GetString("Scene").ToCharArray();
            index = chars[chars.Length - 1];
        }

        if (index == '1'){
            marker.transform.position = new Vector3(-5.2f, 2.92f, 0);
        }else if (index == '2'){
            marker.transform.position = new Vector3(-2.56f, 0.95f, 0);
        }else if (index == '3'){
            marker.transform.position = new Vector3(0.25f, 2.97f, 0);
        }else if (index == '4'){
            marker.transform.position = new Vector3(2.77f, 0.81f, 0);
        }else if (index == '5'){
            marker.transform.position = new Vector3(6.06f, 2.06f, 0);
        }else if (index == '6'){
            marker.transform.position = new Vector3(6.11f, -1.59f, 0);
        }else if (index == '7'){
            marker.transform.position = new Vector3(2.99f, -2.58f, 0);
        }else if (index == '8'){
            marker.transform.position = new Vector3(0.08f, -1.62f, 0);
        }else if (index == '9'){
            marker.transform.position = new Vector3(-2.83f, -2.25f, 0);
        }else if (index == '0'){
            marker.transform.position = new Vector3(-5.67f, -1.6f, 0);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return)){
            SceneManager.LoadScene(PlayerPrefs.GetString("Scene"), LoadSceneMode.Single);
        }
    }
}
