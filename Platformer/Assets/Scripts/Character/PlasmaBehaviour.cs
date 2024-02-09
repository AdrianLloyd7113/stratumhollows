using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBehaviour : MonoBehaviour
{

    public GameObject[] objectList;

    void Start()
    {
        objectList = GameObject.FindGameObjectsWithTag("enemy");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(15f, 0, 0) * Time.deltaTime;

        for (int i = 0; i < objectList.Length; i++){
            if (transform.position.x >= objectList[i].transform.position.x && transform.position.y < (objectList[i].transform.position.y + 1) && transform.position.y >= (objectList[i].transform.position.y - 1)){
                Destroy(objectList[i]);
                Destroy(this);
                Destroy(gameObject);
            }
        }

    }
}
