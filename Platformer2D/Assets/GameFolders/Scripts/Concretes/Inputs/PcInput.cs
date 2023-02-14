using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abstracts.Input;
namespace Inputs
{
    public class PcInput : IPlayerInput
    {
        public float HorizontalAxis => Input.GetAxis("Horizontal");
        public bool IsJumpButton => Input.GetKey(KeyCode.Space);
    }

}
