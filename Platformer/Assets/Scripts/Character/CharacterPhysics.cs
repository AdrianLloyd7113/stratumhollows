using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPhysics : MonoBehaviour
{
    void Start()
    {
        
    }

    void FixedUpdate()
    {

        float gravityForce = -0.1f;

        if (this.GetComponent<Movement>().comingDown && !this.GetComponent<Movement>().jumping){
            
            if (gravityForce > -1.5f){
                gravityForce -= 0.2f;
            }

            transform.position += new Vector3(0, gravityForce, 0);
        }else{
            gravityForce = -0.1f;
        }
    }
    
}
