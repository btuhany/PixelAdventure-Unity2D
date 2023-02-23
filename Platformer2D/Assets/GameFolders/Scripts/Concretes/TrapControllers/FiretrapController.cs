using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiretrapController : MonoBehaviour
{
    [SerializeField] float _hitJumpForce;
    Rigidbody2D _rb;
    Damage _hitDamage;
    Health _targetHealth;
    Animator _anim;
    BoxCollider2D _collider;
    float _currentTime;
    
    [SerializeField] float _maxTime;
    [SerializeField] float _startDelay;
    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _collider.enabled = false;
        _hitDamage = GetComponent<Damage>();
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _targetHealth = collision.gameObject.GetComponent<Health>();
        _hitDamage.HitTarget(_targetHealth);

        _rb = collision.gameObject.GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.zero;
        _rb.AddForce(Vector2.up * _hitJumpForce);
    }
    private void Update()
    {
        
        if (Time.time < _startDelay) return;
        _currentTime += Time.deltaTime;
        if (_currentTime > _maxTime)
        {
            _anim.SetBool("IsFire", true);
            _anim.SetBool("PreFire", false);
            _collider.enabled = true;
            _currentTime = 0f;
        }
        else if (_currentTime > _maxTime / 1.18)
        {
            _anim.SetBool("PreFire", true);
        }
        else if(_currentTime >_maxTime/3)
        {
            _anim.SetBool("IsFire", false);
            _collider.enabled = false;
        }
        
        
    }

}
