using Animations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _maxHealth;
    [SerializeField] bool _IsCooldownAfterHit;
    [SerializeField] float _cooldownTimeAfterHit;
    bool _isInvulnerable;
    public int _currentHealth;
    public bool IsDead => _currentHealth <= 0;
    public event System.Action OnDead;      //////////////////////////////////////
    CharacterAnimation _anim;

    private void Awake()
    {
        _anim = GetComponent<CharacterAnimation>();
        _currentHealth = _maxHealth;
    }
    public void TakeHit(Damage damage)
    {
        if (IsDead || _isInvulnerable) 
        { 
            return; 
        }
        
        _currentHealth -= damage.HitDamage;
        StartCoroutine(HitCooldown());
        


    }
    IEnumerator HitCooldown()
    {
        _isInvulnerable= true;
        _anim.TakeHitAnim(true);
        yield return new WaitForSeconds(_cooldownTimeAfterHit);
        _isInvulnerable = false;
        _anim.TakeHitAnim(false);

    }

}
