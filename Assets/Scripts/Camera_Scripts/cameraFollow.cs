using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraFollow : MonoBehaviour
{
    public CinemachineVirtualCamera cameram;
    public CinemachineVirtualCamera finish_cameram;
    public static cameraFollow Instance;

    private void Awake()
    {
        SingletonThisGameObject();
    }
    private void SingletonThisGameObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Next_Level_Player(Transform player)
    {
        cameram.Follow = player;
        finish_cameram.Follow = player;

    }

    public void Look_Finish()
    {
        cameram.Priority = 5;
        finish_cameram.Priority = 10;
    }
    public void Look_Start()
    {

        cameram.Priority = 10;
        finish_cameram.Priority = 5;
    }

}
