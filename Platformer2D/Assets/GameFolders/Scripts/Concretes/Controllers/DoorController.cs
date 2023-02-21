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
    public void OpenDoor()
    {
        _anim.SetBool("IsOpen", true);
    }
    public void CloseDoor()
    {
        _anim.SetBool("IsOpen", false);
    }
}
