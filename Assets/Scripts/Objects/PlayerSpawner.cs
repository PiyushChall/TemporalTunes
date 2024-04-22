using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    static bool isPlayerExist = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!isPlayerExist)
        {
            Instantiate(Resources.Load("Player/Player"), new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            isPlayerExist = true;
        }
        else
        {
            PlayerController.Instance.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y);
            PlayerController.Instance.InitCamera();

        }
    }
}
