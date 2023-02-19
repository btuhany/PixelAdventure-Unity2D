using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstracts.Input
{
    public interface IPlayerInput
    {
        float HorizontalAxis { get; }
        bool IsJumpButton { get; }
    }
}