using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCanvas : MonoBehaviour
{
    [SerializeField] GameEndPanel _gameEndPanel;

    private void OnEnable()
    {
        GameManager.Instance.OnGameEnd += HandleOnGameEnd;
    }

    private void HandleOnGameEnd()
    {
        _gameEndPanel.gameObject.SetActive(true);
    }
}
