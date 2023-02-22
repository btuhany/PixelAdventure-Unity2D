using Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrambolineController : MonoBehaviour
{

    Rigidbody2D _rb;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       _rb = collision.gameObject.GetComponent<Rigidbody2D>();
       _rb.AddForce(new Vector2(0,500));
        this.gameObject.GetComponent<Animator>().SetTrigger("IsJumped");
    }

}
