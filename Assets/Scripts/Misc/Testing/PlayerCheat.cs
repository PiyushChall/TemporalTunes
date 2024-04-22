using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCheat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var player = OrganBehaviour.Instance;
        player.AddSkill(Skills.Age);
        player.AddSkill(Skills.Unage);
        player.AddSkill(Skills.Pause);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
