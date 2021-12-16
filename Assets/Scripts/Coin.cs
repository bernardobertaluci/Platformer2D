using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private PlayerMovement _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>();
    }
    private void OnEnable()
    {
        _player.CoinRaised += OnCoinRaised;
    }

    private void OnDisable()
    {
        _player.CoinRaised -= OnCoinRaised;
    }

    private void OnCoinRaised()
    {
        Debug.Log(_player.CoinCount + 1);
    }
}
