using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLose : MonoBehaviour
{
    [SerializeField] GameOverManager _gameOverCanvas;
    [SerializeField] Collider2D _colli;
    private void Start()
    {
        _colli = this.GetComponent<Collider2D>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(CONSTANTS.ENEMY_LAYER) )
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        Time.timeScale = 0;
        _gameOverCanvas.GameOver();
    }
}
