using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigi;
    [SerializeField] Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        Observer.AddListeners(CONSTANTS.Attack_ACTION, onAttack);
        _animator = this.GetComponent<Animator>();
    }

    private void onAttack(object[] obj)
    {
        
        _animator.SetBool("IDLE", false);
        _animator.SetBool("RUN", false);
        _animator.SetBool("ATTACK", true);
    }

    private void OnDestroy()
    {
        Observer.RemoveListeners(CONSTANTS.Attack_ACTION, onAttack);
    }
    // Update is called once per frame
    void Update()
    {
        if (_rigi.velocity == Vector2.zero)
        {
            _animator.SetBool("IDLE",true);
            _animator.SetBool("ATTACK", false);
            _animator.SetBool("RUN", false);
        } 
        if (_rigi.velocity != Vector2.zero)
        {
            _animator.SetBool("IDLE", false);
            _animator.SetBool("ATTACK", false);
            _animator.SetBool("RUN", true);
        }
        
    }
}
