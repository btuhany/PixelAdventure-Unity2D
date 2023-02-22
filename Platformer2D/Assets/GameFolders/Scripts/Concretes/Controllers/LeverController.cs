using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    [SerializeField] DoorController _door;
    [SerializeField] GameObject _checkMark;
    [SerializeField] GameObject _leverFruits;
    Animator _anim;
    bool IsLeverOn;
    bool CanLeverWork;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    public void LeverInteraction()
    {
        if(!CanLeverWork)
        {
            TryActivateLever();
        }
        else
            TriggerLever();
    }
    private void TryActivateLever()
    {
        if(CheckConditions())
        {
            CanLeverWork = true;
            FruitManager.Instance.DecreaseFruitNumber(_door.DoorFruitType, _door.DoorFruitNumber);
            TriggerLever();
            _checkMark.SetActive(true);
            _leverFruits.SetActive(false);
        }
    }
    private void TriggerLever()
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
    private bool CheckConditions()
    {
        return FruitManager.Instance.AreThereEnoughFruit(_door.DoorFruitType, _door.DoorFruitNumber);
    }
}
