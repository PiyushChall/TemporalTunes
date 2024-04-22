using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Singleton<PlayerController>
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        Camera.main.GetComponent<CameraFollow>().followTarget = gameObject.transform;
        DontDestroyOnLoad(gameObject);
    }

    public void InitCamera()
    {
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        Camera.main.GetComponent<CameraFollow>().followTarget = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
