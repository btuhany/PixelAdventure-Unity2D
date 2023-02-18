using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        Animator _anim;
        private void Awake()
        {
            _anim= GetComponent<Animator>();
        }
        public void HorizontalAnim(float horizontal)
        {
            float mathfValue = Mathf.Abs(horizontal);
            if (_anim.GetFloat("moveSpeed") == mathfValue) return;
            _anim.SetFloat("moveSpeed", mathfValue);
        }
        public void JumpAnFallAnim(bool isOnGround, float yVelocity)
        {
            _anim.SetBool("IsInAir", !isOnGround);
            if (!isOnGround)
            {
                _anim.SetFloat("yVelocity", yVelocity);
            }
        }
    }

}
