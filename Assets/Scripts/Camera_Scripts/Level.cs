using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void OnEnable()
    {
        cameraFollow.Instance.Next_Level_Player(player.transform);
        cameraFollow.Instance.Look_Start();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
