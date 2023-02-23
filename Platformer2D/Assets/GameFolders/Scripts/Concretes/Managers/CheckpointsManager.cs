using Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckpointsManager : MonoBehaviour
{
    [SerializeField] Health _playerHealth;
    CheckpointController[] _checkpoints;

    private void Awake()
    {
        _checkpoints = GetComponentsInChildren<CheckpointController>();
    }
    private void OnEnable()
    {
        _playerHealth.OnDead += HandleOnDead;
    }
    public void HandleOnDead()
    {
        _playerHealth.transform.position = _checkpoints.LastOrDefault(x=>x.IsChecked).transform.position;
    }

}
