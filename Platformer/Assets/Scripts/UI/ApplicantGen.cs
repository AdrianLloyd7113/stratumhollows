using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicantGen : MonoBehaviour
{

    float time = 3;

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0){
            System.Random r = new System.Random();
            int rand = r.Next(1, 5);

            PlayerPrefs.SetFloat("Applicants", PlayerPrefs.GetFloat("Applicants") + rand);

            if (PlayerPrefs.GetFloat("Applicants") >= (PlayerPrefs.GetFloat("Level") * 100)){
                PlayerPrefs.SetFloat("Applicants", (PlayerPrefs.GetFloat("Level") * 100));
            }

            time = 3;
        }
    }
}
