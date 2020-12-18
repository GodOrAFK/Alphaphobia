using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character settings:")]
    public float speed;
    public float runSpeed;
    public float crouchSpeed;
    public float movementMagnitude;

    [Space]
    [Header("Character statistics:")]
    public Vector2 movementDirection;
    public float movementSpeed;

    [Header("References:")]
    public Rigidbody2D rb;
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if(_anim == null) { Debug.LogError("Animator is missing!"); }
    }

    // Update is called once per frame
    private void Update()
    {
        ProcessInputs();
        Move();
        Animate();
    }

    private void Move()
    {
        rb.velocity = movementDirection * (movementSpeed * movementMagnitude);
    }

    private void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }

    private void Animate()
    {
        if(movementDirection != Vector2.zero)
        {
            _anim.SetFloat("Horizontal", movementDirection.x);
            _anim.SetFloat("Vertical", movementDirection.y);
        }
        _anim.SetFloat("Speed", movementSpeed);
    }
}
