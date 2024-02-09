using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    bool counting = false;
    bool falling = false;
    float startTime;
    float timeLeft = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (counting){
            Debug.Log(timeLeft);
            timeLeft -= (startTime - Time.deltaTime);
            if (timeLeft <= 0){
                falling = true;
            }
        }

        if (falling){
            transform.position += new Vector3(0, -6, 0) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("collision");
        counting = true;
        startTime = Time.deltaTime;
    }
}
