using Assets.Scripts.Models.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgebleWall : MonoBehaviour, IAgebl
{
    [SerializeField]
    int MaxAge = 1;
    [SerializeField]
    bool destroyOnLast;
    [SerializeField]
    int age = 0;
    private Animator animator;

    

    public int Age { get => age; private set => age = value; }

    public void AddAge()
    {
        if (age < MaxAge)
            animator.SetInteger("Age", ++age);
        if (destroyOnLast && age == MaxAge)
            Destroy(this);
    }

    public void SubtractAge()
    {
        if (age > 0)
            animator.SetInteger("Age", --age);

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
