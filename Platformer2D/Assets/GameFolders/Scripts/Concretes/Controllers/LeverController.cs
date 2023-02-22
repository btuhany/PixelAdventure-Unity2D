using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    [SerializeField] DoorController _door; 
    Animator _anim;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            LeverOn();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            LeverOff();
        }
    }
    public void LeverOn()
    {
        _anim.SetBool("IsActive", true);
        _door.OpenDoor();
    }
    public void LeverOff()
    {
        _anim.SetBool("IsActive", false);
        _door.CloseDoor();
    }
}
