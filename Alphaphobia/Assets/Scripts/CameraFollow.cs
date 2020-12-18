using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraOffset;
    public float camSpeed = 0.1f;

    private Camera _myCam;
    // Start is called before the first frame update
    void Start()
    {
        _myCam = GetComponent<Camera>();
        //transform.position = target.position + cameraOffset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _myCam.orthographicSize = (Screen.height / 100f);

        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, camSpeed) + new Vector3(0, 0, -10);
        }
    }
}
