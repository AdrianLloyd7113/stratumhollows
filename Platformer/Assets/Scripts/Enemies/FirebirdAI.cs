using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebirdAI : MonoBehaviour
{

    public float increment;
    public float distance;
    public float height;
    public Vector3 startPos;
    public Vector3 midPos;
    public Vector3 endPos;
    public Vector3 targetPos;
    public int indexPos = 0;

    void Start()
    {
        startPos = transform.position;
        midPos = transform.position - new Vector3(distance/2f, height, 0);
        endPos = transform.position - new Vector3(distance, 0, 0);

        targetPos = midPos;

        Debug.Log(midPos.x + " " + midPos.y);
    }

    void Update()
    {
        
        Debug.Log(transform.position.x + "X, " + transform.position.y + "Y");
        Debug.Log(startPos.x + "STARTX, " + startPos.y + "STARTY");
        Debug.Log(midPos.x + "MIDX, " + midPos.y + "MIDY");
        Debug.Log(endPos.x + "ENDX, " + endPos.y + "ENDY");

        if (transform.position.x < targetPos.x){
            transform.position += new Vector3(increment, 0, 0);
        }else if (transform.position.x > targetPos.x){
            transform.position += new Vector3(-(increment), 0, 0);
        }
        
        if (transform.position.y < targetPos.y){
            transform.position += new Vector3(0, increment, 0);
        }else if (transform.position.y > targetPos.y){
            transform.position += new Vector3(0, -(increment), 0);
        }

        if (transform.position.x < targetPos.x + increment && transform.position.x > targetPos.x - increment && transform.position.y < targetPos.y + increment && transform.position.y > targetPos.y - increment){
            indexPos++;
            if (indexPos == 1){
                targetPos = endPos;
            }else if (indexPos == 2){
                targetPos = midPos;
            }else if (indexPos == 3){
                targetPos = startPos;
            }else{
                indexPos = 0;
                targetPos = midPos;
            }
        }
    }
}
