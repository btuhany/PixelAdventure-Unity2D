using Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBulletController : Enemies
{
    [SerializeField] RbMovement _trunkRb;
    RbMovement _rbMovement;
    float _direction;

    private void Awake()
    {
        _hitDamage = GetComponent<Damage>();
        _rbMovement= GetComponent<RbMovement>();
    }
    private void OnEnable()
    {
        _direction = _trunkRb.HorizontalDirection;
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
