using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 2f;
        [SerializeField] private float _jumpForce = 5f;
        bool _isJumped;


        Animator _anim;
        Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _anim= GetComponent<Animator>();
        }
        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            _anim.SetFloat("moveSpeed", Mathf.Abs(horizontal));
            transform.Translate(Vector2.right * horizontal * _moveSpeed * Time.deltaTime);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _isJumped = true;
                
            }
            if (horizontal != 0)
            {
                transform.localScale = new Vector3(Mathf.Sign(horizontal),transform.localScale.y, transform.localScale.z);
            }
        }
        private void FixedUpdate()
        {
            if(_isJumped)
            {
                
                _rb.AddForce(Vector2.up * _jumpForce );
                _isJumped = false;
            }
        }
    }

}
