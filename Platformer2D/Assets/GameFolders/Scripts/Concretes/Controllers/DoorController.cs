using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator _anim;

    private void Awake()
    {
        _anim= GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) 
        {
            _anim.SetBool("IsOpen", true);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            _anim.SetBool("IsOpen", false);
        }
    }
}
