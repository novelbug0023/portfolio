using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CameraFlow : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(target.transform.position);
        transform.LookAt(target.transform);
        Vector3 TargetPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z - 2);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 20.0f);

    }
}
