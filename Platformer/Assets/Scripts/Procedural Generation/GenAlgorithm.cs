using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenAlgorithm : MonoBehaviour
{

    System.Random r = new System.Random();
    GameObject platform;

    public GameObject character;
    public GameObject portal;
    public GameObject bird;
    public GameObject redBird;
    public GameObject[] platforms;

    float prevX = 0;
    float prevY = 0;

    public Vector3 defaultPos;

    public float startX;
    public float startY;
    public float currentX;
    public float currentY;

    public int i = 0;
    public int reps = 10;

    void Start()
    {
        character = GameObject.Find("character");
        defaultPos = character.transform.position;

        startX = character.transform.position.x;
        startY = character.transform.position.y;
        currentX = startX + 1;
        currentY = startY;

        int index = r.Next(0, platforms.Length);
        platform = platforms[index];
    }

    void Update()
    {
        if (i < reps){
            GenerateNext(0);
            i++;
        }else if (i == reps){
            GenerateNext(1);
            i++;
        }
    }

    void GenerateNext(int code){

        platform.transform.localScale = new Vector3(1,1,1);

        float posX = 0;
        float posY = 0;
         
        float minX = 5;
        float maxX = 1 + minX;
        float minY = -4.5f;
        float maxY = 3.75f;

        float addY = 0;
        float addX = 0;

        posX = (float)(r.NextDouble()*(maxX - minX) + minX);
        posY = (float)(r.NextDouble()*(maxY - minY) + minY);

        addY = currentY + posY;
        addX = currentX + posX;

        if (addY < defaultPos.y){
            addY = defaultPos.y;
            currentY = defaultPos.y;
        }

        float platformWidth = platform.GetComponent<Collider2D>().bounds.size.x;

        if (code == 0){

            int flip = r.Next(0, 4);
            if (flip == 1){
                float widthFactor = (float)(r.NextDouble()* 0.8);
                platform.transform.localScale -= new Vector3(widthFactor, 0, 0);
            }else if (flip == 2){
                float widthFactor = (float)(r.NextDouble()*8);
                platform.transform.localScale -= new Vector3(widthFactor, 0, 0);

                currentX += widthFactor;
            }

            Instantiate(platform, new Vector3(addX, addY, 0), Quaternion.identity);

            int rand = r.Next(0, 6);
            if (rand == 2 && i != 0){
                Instantiate(bird, new Vector3(addX, addY + 2, 0), Quaternion.identity);
            }else if (rand == 4 && i != 0){
                Instantiate(redBird, new Vector3(addX, addY + 2, 0), Quaternion.identity);
            }

            currentX += posX + platformWidth;
            currentY += posY;

        }else{
            Instantiate(portal, new Vector3(addX, addY, 0), Quaternion.identity);
        }

    }
}
