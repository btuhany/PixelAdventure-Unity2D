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
    private void OnCollisionStay2D(Collision2D collision)
    {
        _targetHealth = collision.gameObject.GetComponent<Health>();
        _hitDamage.HitTarget(_targetHealth);
        _rb = collision.gameObject.GetComponent<Rigidbody2D>();
        _rb.AddForce(Vector2.up * _hitJumpForce);
    }
    
}
