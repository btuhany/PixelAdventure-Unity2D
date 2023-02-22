using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class FruitController : MonoBehaviour
{
    [SerializeField] Fruits _fruitType;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FruitManager.Instance.IncreaseFruitNumber(_fruitType);
            Destroy(this.gameObject);
        }
    }
}
