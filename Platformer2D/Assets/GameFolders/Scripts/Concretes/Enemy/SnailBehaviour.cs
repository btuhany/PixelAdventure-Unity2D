using Movements;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace EnemyAI
{
    public class SnailBehaviour : Enemies
    {

        float _horizontalAxisDirection;
        RbMovement _rbMovement;
        Flip _flip;
        Animator _anim;
        WallCheck _wallCheck;

        private void Awake()
        {
            _hitDamage = GetComponent<Damage>();
            _flip = GetComponent<Flip>();
            _rbMovement = GetComponent<RbMovement>();
            _anim = GetComponent<Animator>();
            _wallCheck = GetComponent<WallCheck>();
        }
        private void Start()
        {
            GetRandomHorizontalAxis();
        }
        void Update()
        {
            
            if (_wallCheck.IsThereWall)
            {
                _horizontalAxisDirection = -_horizontalAxisDirection;
            }
            if (_horizontalAxisDirection != 0)
            {
                _anim.SetBool("IsMoving", true);
            }
            else
            {
                _anim.SetBool("IsMoving", false);
            }
            _flip.FlipCharacter(_horizontalAxisDirection);
        }
        private void FixedUpdate()
        {
            _rbMovement.HorizontalMove(_horizontalAxisDirection);
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            MakeTargetJump(collision);
            HitTarget(collision);
        }
        void GetRandomHorizontalAxis()
        {
            _horizontalAxisDirection = Random.Range(1, 3);
            if (_horizontalAxisDirection == 2) _horizontalAxisDirection = -1;
        }
    }
}

