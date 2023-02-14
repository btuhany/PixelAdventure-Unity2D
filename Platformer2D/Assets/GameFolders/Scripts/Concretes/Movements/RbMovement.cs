using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

namespace Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RbMovement: MonoBehaviour
    {
        [SerializeField] float _jumpForce=10f;
        [SerializeField] float _horizontalSpeed=10f;
        Rigidbody2D _rb;
        private void Awake()
        {
            _rb= GetComponent<Rigidbody2D>();
        }
        public void Jump()
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 0f);
            _rb.AddForce(Vector2.up * _jumpForce);
        }
        public void HorizontalMove(float direction)
        {
            
            _rb.position += Vector2.right * direction * _horizontalSpeed * Time.deltaTime;
        }
    }
}
