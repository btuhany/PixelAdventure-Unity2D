using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 2f;
        Animator _anim;
        private void Awake()
        {
            _anim= GetComponent<Animator>();
        }
        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            _anim.SetFloat("moveSpeed", Mathf.Abs(horizontal));
            transform.Translate(Vector2.right * horizontal * _moveSpeed * Time.deltaTime);
            if(horizontal != 0)
            {
                transform.localScale = new Vector3(Mathf.Sign(horizontal),transform.localScale.y, transform.localScale.z);
            }
        }
    }

}
