using Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBulletController : Enemies
{
    
    RbMovement _rbMovement;
    float _direction;

    public float Direction { get => _direction; set => _direction = value; }

    private void Awake()
    {
        _hitDamage = GetComponent<Damage>();
        _rbMovement= GetComponent<RbMovement>();
    }
    private void OnEnable()
    {
        _direction = 1;
    }
    private void FixedUpdate()
    {
        _rbMovement.HorizontalMove(_direction);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HitTarget(collision);
        MakeTargetJump(collision);
        Destroy(this.gameObject);
    }
}
