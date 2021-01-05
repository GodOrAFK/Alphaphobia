using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    public float Speed;

    private void Update()
    {
        float s = Speed * Time.deltaTime;
        Camera.main.transform.Translate(new Vector3(s, 0.0f));
    }
}
