using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myCursor : MonoBehaviour
{
    Animator my_Anim;
    void Start()
    {
        my_Anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            my_Anim.SetTrigger("incline");
        }        
    }
}
