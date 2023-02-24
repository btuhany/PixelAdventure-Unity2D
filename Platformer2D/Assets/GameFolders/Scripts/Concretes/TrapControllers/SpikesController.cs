using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesController : MonoBehaviour
{
    [SerializeField] float _hitJumpForce;
    Rigidbody2D _rb;
    Damage _hitDamage;
    Health _targetHealth;

    private void Awake()
    {
        _hitDamage = GetComponent<Damage>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _targetHealth = collision.gameObject.GetComponent<Health>();
        if(_targetHealth!= null )
            _hitDamage.HitTarget(_targetHealth);

        _rb = collision.attachedRigidbody;
        _rb.velocity = Vector2.zero;
        _rb.AddForce(Vector2.up * _hitJumpForce);
    }
    
}
