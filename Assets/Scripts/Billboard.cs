using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    void FixedUpdate()
    {
        transform.LookAt(Camera.main.transform.position);

        //transform.LookAt(transform.position + Camera.main.transform.position);
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        
        //Vector3 bossPos = GetComponentInParent<Transform>().transform.position;
        //Vector3 lifePos = new(Mathf.Abs(bossPos.x / 10), 3.78f, Mathf.Abs(bossPos.z / 10));
        //transform.localPosition = lifePos;

    }
}
