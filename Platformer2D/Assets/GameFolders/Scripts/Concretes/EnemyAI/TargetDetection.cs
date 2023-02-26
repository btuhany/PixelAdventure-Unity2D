using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetDetection : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _detectRange;
    float _maxDistance;
    bool _isTargetInRange;
    public bool IsTargetJustOut;

    public bool IsTargetInRange { get => _isTargetInRange; }
    public bool IsTargetOnLeft => _target.position.x < transform.position.x;
    public bool IsTargetOnRight => _target.position.x > transform.position.x;

    private void Update()
    {
        _maxDistance = Vector2.Distance(transform.position, _target.position);
        if (_maxDistance < _detectRange)
        {
            _isTargetInRange = true;
        }
        else if(_isTargetInRange)
        {
            IsTargetJustOut = true;   // making it false in Behaviour (with coroutine), delay before idle state (could be written better?)
            _isTargetInRange = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _detectRange);
    }
}
