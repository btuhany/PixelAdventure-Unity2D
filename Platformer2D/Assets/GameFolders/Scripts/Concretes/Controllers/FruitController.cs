using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class FruitController : MonoBehaviour
{
    [SerializeField] Fruits _fruitType;
    Animator _anim;
    private void Awake()
    {
        _anim= GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FruitManager.Instance.IncreaseFruitNumber(_fruitType);
            _anim.Play("Collected");
            Destroy(this.gameObject,0.5f);
        }
    }
}
