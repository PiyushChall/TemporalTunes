using Assets.Scripts.Models.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedDoor : MonoBehaviour, IPausable
{
    [SerializeField]
    Collider2D trigger;
    Animator _anim;

    bool _isOpen = true;
    bool _isPaused = false;

    public bool IsOpen {
        get => _isOpen; 
        private set 
        {
            _isOpen = value; 
            if(_isOpen)
                _anim.SetBool("Open", true);
            else
                _anim.SetBool("Open", false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !_isPaused)
            IsOpen = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !_isPaused)
            IsOpen = true;
    }

    public void Pause()
    {
        Debug.Log(gameObject.name + " paused");
        _isPaused = true;
        //trigger.enabled = false;
    }

    public void Unpause()
    {
        Debug.Log(gameObject.name + " unpaused");
        _isPaused = false;
        trigger.enabled = false; //TODO: Delete this cringe
        trigger.enabled = true;
    }
}
