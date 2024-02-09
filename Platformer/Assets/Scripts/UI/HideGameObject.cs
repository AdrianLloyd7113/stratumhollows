using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideGameObject : MonoBehaviour
{
    public GameObject thing;

    void Start()
    {
        thing.SetActive(false);
    }

}
