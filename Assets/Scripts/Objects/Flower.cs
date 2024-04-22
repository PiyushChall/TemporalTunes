using Assets.Scripts.Models.Interfaces;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Flower : MonoBehaviour, IAgebl
{
    private Animator animator;

    [SerializeField]
    UnityEvent onFresh = new();

    public UnityEvent OnFresh { get => onFresh; set => onFresh = value; }

    [SerializeField]
    int age = 0;
    [SerializeField]
    int MaxAge = 1;

    public int Age { get => age; private set => age = value; }

    public void AddAge()
    {
        if (age < MaxAge)
            animator.SetInteger("Age", ++age);
    }

    public void SubtractAge()
    {
        if (age > 0)
            animator.SetInteger("Age", --age);
        if (age == 0)
            onFresh.Invoke();
    }


    // Start is called before the first frame update
    void Start()
    {
       animator = GetComponent<Animator>();
       animator.SetInteger("Age", age);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
