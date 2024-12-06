using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigid;
    [SerializeField] Collider2D _colli;
    [SerializeField] GameObject player;
    [SerializeField] float _speed;
    [SerializeField] Vector2 _moveDir;

    private void Start()
    {
        _rigid = this.GetComponent<Rigidbody2D>();
        _colli = this.GetComponent<Collider2D>();
        player = GameManager.Instance.Player;
    }

    private void FixedUpdate()
    {
        _moveDir = player.transform.position - this.transform.position;
        _rigid.velocity = _moveDir.normalized * _speed;

        if (_rigid.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (_rigid.velocity.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    
}
