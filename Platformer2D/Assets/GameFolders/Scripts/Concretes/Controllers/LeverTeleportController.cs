using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class LeverTeleportController : MonoBehaviour
    {
        [SerializeField] Transform _teleportPos;
        PlayerController _player;
        Animator _anim;
        bool IsLeverOn;
  
        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }
        public void LeverInteraction()
        {
                TriggerLever();

        }

        private void TriggerLever()
        {
            if (IsLeverOn)
                LeverOff();
            else
                LeverOn();

        }
        private void LeverOn()
        {
            IsLeverOn = true;
            _anim.SetBool("IsActive", true);
            _player.transform.position = _teleportPos.position;

        }
        private void LeverOff()
        {
            IsLeverOn = false;
            _anim.SetBool("IsActive", false);

        }
        private void OnTriggerStay2D(Collider2D collision) 
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                _player = collision.gameObject.GetComponent<PlayerController>();
            }
        }

    }

}
