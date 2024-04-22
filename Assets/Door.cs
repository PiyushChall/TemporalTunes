using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    Animator _anim;

    [SerializeField]
    bool _isOpen = true;

    public bool IsOpen
    {
        get => _isOpen;
        private set
        {
            _isOpen = value;
            if (_isOpen)
                _anim.SetBool("Open", true);
            else
                _anim.SetBool("Open", false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        IsOpen = _isOpen;
    }

    public void Open()
    {
        IsOpen = true;
    }

    public void Close()
    {
        IsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
