using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
struct NoteSprite
{
    public char note;
    public Sprite sprite;
}

public class NextNoteHUDBeh : MonoBehaviour
{
    [SerializeField]
    List<NoteSprite> notes = new();
    Dictionary<char, Sprite> sprites = new();
    OrganBehaviour organ;
    Image img;
    // Start is called before the first frame update
    void Start()
    {
        organ = OrganBehaviour.Instance;
        img = GetComponent<Image>();
        sprites = notes.ToDictionary(x => x.note, x => x.sprite);
    }

    // Update is called once per frame
    void Update()
    {
        if (!organ.IsSupporting && img.enabled)
            img.enabled = false;

        if(organ.IsSupporting) {
            img.enabled = true;
            img.sprite = sprites[organ.NextNote];
        }
    }
}
