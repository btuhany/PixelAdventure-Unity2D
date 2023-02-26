using Movements;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace EnemyAI
{
    public class SnailBehaviour : Enemies
    {

        RbMovement _rbMovement;
        Flip _flip;
        Animator _anim;
        float _horizontalAxisDirection;


        //WallCheck
        [SerializeField] Transform _rayOrigins;
        [SerializeField] float _maxRayLength = 0.5f;
        [SerializeField] LayerMask _layerMask;
        bool _isThereWall;
        private void Awake()
        {
            _hitDamage = GetComponent<Damage>();
            _flip = GetComponent<Flip>();
            _rbMovement = GetComponent<RbMovement>();
            _anim = GetComponent<Animator>();
        }
        private void Start()
        {
            _horizontalAxisDirection = Random.Range(1, 3);
            if (_horizontalAxisDirection == 2) _horizontalAxisDirection = -1;
        }
        void Update()
        {
            CheckWalls();
            if (_isThereWall)
            {
                _horizontalAxisDirection = -_horizontalAxisDirection;
            }
            _flip.FlipCharacter(_horizontalAxisDirection);
            if (_horizontalAxisDirection != 0)
            {
                _anim.SetBool("IsMoving", true);
            }
            else
            {
                _anim.SetBool("IsMoving", false);
            }
        }
        private void FixedUpdate()
        {
            _rbMovement.HorizontalMove(_horizontalAxisDirection);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            MakeTargetJump(collision);
            HitTarget(collision);
        }
        void CheckWalls()
        {
            RaycastHit2D hit = Physics2D.Raycast(_rayOrigins.position, Vector2.right * _horizontalAxisDirection, _maxRayLength, _layerMask);
           // Debug.DrawRay(_rayOrigins.position, Vector2.right * _horizontalAxisDirection * _maxRayLength, Color.red);
            if (hit.collider != null)
            {

                _isThereWall = true;
            }

            else
                _isThereWall = false;

        }
    }
}

