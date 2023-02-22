using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abstracts.Input;
namespace Inputs
{
    public class PcInput : IPlayerInput
    {
        public float HorizontalAxis => Input.GetAxis("Horizontal");
        public bool IsJumpButton => Input.GetButtonDown("Jump");   //buttondown? fallcontrol
        public bool IsDownButton => Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
        public bool IsInteractButton => Input.GetKeyDown(KeyCode.E);
    }

}
