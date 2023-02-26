using Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EnemyAI
{
    public class ChickenBehaviour : MonoBehaviour
    {
        
        [SerializeField] Transform _rayOrigin2;
        
        [SerializeField] float _maxRayLength2;
        
        
        bool _isOnGround;

        [SerializeField] float _inRangeSpeed;
        RbMovement _rbMovement;
        Animator _anim;
        Flip _flip;
        WallCheck _wallCheck;
        TargetDetection _targetDetection;
        float _horizontalAxisDirection;
        
     
       
        private bool _chaseState;

        private void Awake()
        {
            _wallCheck = GetComponent<WallCheck>();
            _anim = GetComponent<Animator>();
            _flip = GetComponent<Flip>();
            _rbMovement = GetComponent<RbMovement>();  
            _targetDetection = GetComponent<TargetDetection>();
        }
        private void Start()
        {
            _horizontalAxisDirection = Random.Range(1, 3);
            if (_horizontalAxisDirection == 2) _horizontalAxisDirection = -1;
        }
        private void Update()
        {
            _flip.FlipCharacter(_horizontalAxisDirection);

            if(_targetDetection.IsTargetJustOut)
                    StartCoroutine(OutOfRange());
            
            if(_targetDetection.IsTargetInRange)
            {
                _anim.SetBool("IsRunning", true);
                if (_targetDetection.IsTargetOnLeft)
                {
                    _horizontalAxisDirection = -_inRangeSpeed;  
                }
                else if(_targetDetection.IsTargetOnRight)
                {
                    _horizontalAxisDirection = _inRangeSpeed; 
                }
                else 
                {
                    _horizontalAxisDirection = 0; 
                }
            }

            
           
            //CheckGround();


        }
        private void FixedUpdate()
        {
            _rbMovement.HorizontalMove(_horizontalAxisDirection);
            if (_wallCheck.IsThereWall && _isOnGround)
            {
                _rbMovement.Jump();
            }
        }
        IEnumerator OutOfRange()
        {
            _targetDetection.IsTargetJustOut = false;
            _horizontalAxisDirection = 0;
            _anim.SetBool("IsRunning", false);
            yield return new WaitForSeconds(2f);
            _horizontalAxisDirection = Random.Range(1, 3);
            if (_horizontalAxisDirection == 2) _horizontalAxisDirection = -1;
        }


        //void CheckGround()  // write with GroundCheck
        //{
        //    RaycastHit2D hit = Physics2D.Raycast(_rayOrigin2.position, Vector2.down, _maxRayLength2, _layerMask);
        //    Debug.DrawRay(_rayOrigin2.position, Vector2.down * _maxRayLength2, Color.red);
        //    if (hit.collider != null)
        //    {
        //        _isOnGround = true;
        //    }
        //    else
        //        _isOnGround = false;
        //}
    }

}
