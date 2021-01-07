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
    private AudioSource _audio;
    private Animator _anim;

    private void Awake()
    {
        float posX = PlayerPrefs.GetFloat("posX", 0);
        float posY = PlayerPrefs.GetFloat("posY", 0);

        this.transform.position = new Vector2(posX, posY);
    }

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
        if(_anim == null) { Debug.LogError("Animator is missing!"); }
    }

    // Update is called once per frame
    private void Update()
    {
        ProcessInputs();
        Move();
        Animate();
        PlaySound();
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

    private void PlaySound()
    {
        if(_audio == null) { return; }
        if (rb.velocity == Vector2.zero)
        {
            if (_audio.isPlaying) { _audio.Stop(); }
        }
        else
        {
            if (!_audio.isPlaying) { _audio.Play(); }
        }
    }
}
