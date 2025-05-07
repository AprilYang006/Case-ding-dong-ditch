using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour
{
    public Transform targetobject;
    public Vector3 cameraoffset;
    // Start is called before the first frame update
    void Start()
    {
        cameraoffset = transform.position - targetobject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newposition = targetobject.transform.position + cameraoffset;
    }
}
