using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRendererOff : MonoBehaviour
{
    public GameObject Box;

    void Start()
    {
        Box.GetComponent<MeshRenderer>().enabled = false;
    }

    void Update()
    {
        
    }
}
