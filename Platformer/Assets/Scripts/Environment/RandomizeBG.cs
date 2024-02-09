using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeBG : MonoBehaviour
{

    public Sprite[] options;

    void Start()
    {
        System.Random r = new System.Random();
        int i = r.Next(0, (options.Length - 1));

        GetComponent<SpriteRenderer>().sprite = options[i];

        if (i != 0){
            transform.localScale += new Vector3(2.5f, 2.5f, 0);
        }else{
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
