using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverwingAI : MonoBehaviour
{
    
    public GameObject character;

    void Start()
    {
        character = GameObject.Find("character");
    }

    // Update is called once per frame
    void Update()
    {
        System.Random rnd = new System.Random();
        int dir = rnd.Next(1, 4);
        float x = 0;
        float y = 0;

        if (dir == 1){
            y = 10f;
            x = 0;
        }else if (dir == 2){
            y = 10f;
            x = 0;
        }else if (dir == 3){
            x = 10f;
            y = 0;
        }else if (dir == 4){
            x = 10f;
            y = 0;
        }

        if (transform.position.x > character.transform.position.x + 2 && x > 0){
            x = -x;
        }else if (transform.position.x < character.transform.position.x - 2 && x < 0){
            x = -x;
        }else if (transform.position.y > character.transform.position.y && y > 0){
            y = -y;
        }else if (transform.position.y < character.transform.position.y - 2 && y < 0){
            y = -y;
        }

        transform.position += new Vector3(x, y, 0) * Time.deltaTime;

    }
}
