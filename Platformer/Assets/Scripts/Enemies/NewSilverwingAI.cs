using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSilverwingAI : MonoBehaviour
{
    
    public GameObject character;
    public float speed;
    public float diff;

    void Start()
    {
        character = GameObject.Find("character");
        diff = transform.position.y - character.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0;
        float y = 0;

        if (transform.position.x < character.transform.position.x){
            x = speed;
        }

        if (transform.position.y < character.transform.position.y + diff){
            y = speed;
        }else if (transform.position.y > character.transform.position.y + diff){
            y = -speed;
        }

        transform.position += new Vector3(x, y, 0) * Time.deltaTime;

        if (transform.position.x < character.transform.position.x - 10){
            transform.position += new Vector3((character.transform.position.x - transform.position.x) - 10, 0, 0);
        }
    }
}
