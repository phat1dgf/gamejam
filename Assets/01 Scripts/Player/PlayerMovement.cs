using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigid;
    [SerializeField] Vector2 _movement;
    [SerializeField] float _speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = this.GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void FixedUpdate()
    {
        _rigid.velocity = _movement.normalized * _speed; 
    }
    private void Movement()
    {
        _movement = Vector2.zero;
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        
        if (_movement.x < 0)
        {
            transform.parent.localScale = new Vector3(-1, 1, 1); 
        }
        else if (_movement.x > 0)
        {
            transform.parent.localScale = new Vector3(1, 1, 1); 
        }
    }
}
