using Movements;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrunkBehaviour : Enemies
{
    [SerializeField] float _maxChangeDirectionTime;
    [SerializeField] float _maxAttackTime;
    float _horizontalDirection;
    float _currentTime;
    bool _isPlayerFound;
    Flip _flip;
    WallCheck _playerCheck;
    RbMovement _rbMovement;
    Animator _anim;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _hitDamage = GetComponent<Damage>();
        _playerCheck = GetComponent<WallCheck>();
        _rbMovement= GetComponent<RbMovement>();
        _flip = GetComponent<Flip>();
    }
    private void Start()
    {
        GetRandomHorizontalAxis();
    }
    private void Update()
    {
        if (!_isPlayerFound)
            ChangeDirectionWithTime();
        else
            SendProjectilesWithTime();

        PlayerCheck();
        _flip.FlipCharacter(_horizontalDirection);
       _rbMovement.HorizontalDirection= _horizontalDirection;
        
    }
    void GetRandomHorizontalAxis()
    {
        _horizontalDirection = Random.Range(1, 3);
        if (_horizontalDirection == 2) _horizontalDirection = -1;
    }
    void ChangeDirectionWithTime()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > _maxChangeDirectionTime)
        {
            _horizontalDirection = -_horizontalDirection;
            _currentTime = 0;
        }
    }
    void SendProjectilesWithTime()
    {
        
        _currentTime += Time.deltaTime;
        if (_currentTime > _maxAttackTime)
        {
            _anim.SetTrigger("IsAttack");
            _currentTime = 0;
        }
    }
    private void PlayerCheck()
    {
        if (_playerCheck.IsThereWall)
        {
            _isPlayerFound = true;
            
        }
        else
        {
            _isPlayerFound = false;
           
        }
    }
}