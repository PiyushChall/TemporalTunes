using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Note
{
    R = 'r',
    L = 'l',
    U = 'u',
    D = 'd'
}

[Serializable]
public class Skill
{
    [SerializeField]
    public string Name;
    [SerializeField]
    [TextArea(10,20)]
    public string Description;
    //public List<Note> triggerNotes;
    [SerializeField]
    public string triggerNotes;
    //public List<Note> loopNotes;
    [Header("Need support")]
    [SerializeField]
    public bool isLoop = false;
    [SerializeField]
    public string loopNotes;
    [SerializeField]
    public UnityEngine.Events.UnityEvent start = new();
    [SerializeField]
    public UnityEngine.Events.UnityEvent loop = new();
    [SerializeField]
    public UnityEngine.Events.UnityEvent end = new();


}