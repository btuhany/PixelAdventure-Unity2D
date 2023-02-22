using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    [SerializeField] DoorController _door; 
    Animator _anim;
    bool IsLeverOn;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    public void TriggerLever()
    {
        if(IsLeverOn) 
            LeverOff(); 
        else
            LeverOn();
    }
    private void LeverOn()
    {
        IsLeverOn = true;
        _anim.SetBool("IsActive", true);
        _door.OpenDoor();
    }
    private void LeverOff()
    {
        IsLeverOn = false;
        _anim.SetBool("IsActive", false);
        _door.CloseDoor();
    }
}
