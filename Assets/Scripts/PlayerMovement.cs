using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float runSpeed;
    public float crouchSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float c = (Input.GetKey(KeyCode.LeftAlt)) ? crouchSpeed : speed;
        float s = (Input.GetKey(KeyCode.LeftShift)) ? runSpeed : speed;
        float x = Input.GetAxisRaw("Horizontal") * s * Time.fixedDeltaTime;
        float y = Input.GetAxisRaw("Vertical") * s * Time.fixedDeltaTime;

        transform.Translate(new Vector3(x, y));
        //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }
}
