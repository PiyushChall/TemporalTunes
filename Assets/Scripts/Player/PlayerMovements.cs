using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    private float speed;

    public Rigidbody2D rb;

    private Animator _animator;
    private SpriteRenderer _sr;
    private AudioSource _stepsAudio;
    private bool _isWalking = false;



    Vector2 Movement;

    public bool IsWalking { get => _isWalking; private set => _isWalking = value; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
        _stepsAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        if (Movement.y < 0)
            _animator.SetBool("Front", true);
        if (Movement.y > 0)
            _animator.SetBool("Front", false);

        IsWalking = Movement.magnitude > 0;
        _animator.SetBool("Walk", IsWalking);
        _stepsAudio.mute = !IsWalking;

        if(Movement.x > 0)
            _sr.flipX  = false;
        if (Movement.x < 0)
            _sr.flipX = true;


    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Movement.normalized * speed * Time.fixedDeltaTime);
    }
    
}
