using Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkProjectileController : Traps
{
    [SerializeField] float _maxLifeTime;
    RbMovement _rbMovement;
    AddableToObjectPool _objectPool;
    float _direction;

    public float Direction { get => _direction; set => _direction = value; }

    private void Awake()
    {
        _hitDamage = GetComponent<Damage>();
        _rbMovement= GetComponent<RbMovement>();
        _objectPool = GetComponent<AddableToObjectPool>();
    }
    private void OnEnable()
    {
        _direction = transform.localScale.x;
        StartCoroutine(SetPoolAfterDelay());
    }
    private void FixedUpdate()
    {
        _rbMovement.HorizontalMove(_direction);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HitTarget(collision);
            MakeTargetJump(collision);
            ObjectPoolManager.Instance.SetPool(_objectPool);
        }
    }
    IEnumerator SetPoolAfterDelay()
    {
        yield return new WaitForSeconds(_maxLifeTime);
        ObjectPoolManager.Instance.SetPool(_objectPool);
    }
}
