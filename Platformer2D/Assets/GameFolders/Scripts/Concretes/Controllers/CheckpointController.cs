using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    bool _isChecked;

    Animator _anim;

    public bool IsChecked { get => _isChecked; }

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isChecked = true;
        _anim.SetBool("FlagOut", true);
    }
}
