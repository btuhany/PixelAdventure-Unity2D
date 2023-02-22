using Abstracts.Input;
using Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;
using Animations;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        bool _isJumped;
        float _horizontalAxis;
        IPlayerInput _input;
        CharacterAnimation _anim;
        RbMovement _rb;
        Flip _flip;
        GroundCheck _groundCheck;
        PlatformHandler _platform;
        InteractHandler _interact;
        private void Awake()
        {
            _rb= GetComponent<RbMovement>();
            _anim= GetComponent<CharacterAnimation>();
            _flip = GetComponent<Flip>();
            _groundCheck = GetComponent<GroundCheck>();
            _platform = GetComponent<PlatformHandler>();
            _interact = GetComponent<InteractHandler>();
            _input = new PcInput();
        }
        private void Update()
        {
            _horizontalAxis = _input.HorizontalAxis;
            if (_input.IsJumpButton && _groundCheck.IsOnGround)
            {
                _isJumped = true;               
            }
            if(_input.IsDownButton)
                _platform.DisableCollider();
            if(_input.IsInteractButton)
            {
                _interact.Interact();
            }
           
            _anim.JumpAnFallAnim(_groundCheck.IsOnGround, _rb.VelocityY);
            _anim.HorizontalAnim(_horizontalAxis);
            _flip.FlipCharacter(_horizontalAxis);
        }
        private void FixedUpdate()
        {
            _rb.HorizontalMove(_horizontalAxis);  //if a gameObject has rb, dont use transform for movement
            if (_isJumped )
            {
                _rb.Jump();
                _isJumped = false;
            }
        }

    }

}
