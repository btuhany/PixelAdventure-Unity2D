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
            _anim.SetFloat("moveSpeed", horizontal);
            transform.Translate(Vector3.right * horizontal * _moveSpeed * Time.deltaTime);
        }
    }

}
