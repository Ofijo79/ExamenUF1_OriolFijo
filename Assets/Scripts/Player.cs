using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float _horizontal;
    [SerializeField]float _playerSpeed = 5;
    [SerializeField]float _jumpHeight = 7;
    Rigidbody2D _rbody;
    Animator _animations;
    
    // Start is called before the first frame update
    void Awake()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _animations = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Movimiento();

        if(Input.GetButtonDown("Jump")  && GroundSensor._isGrounded)
        {
            Jump();
        }
        _animations.SetBool("IsJumping", !GroundSensor._isGrounded);
    }
    
    void FixedUpdate()
    {
        _rbody.velocity = new Vector2(_horizontal * _playerSpeed, _rbody.velocity.y);
    }
    
    // Update is called once per frame
    

    void Movimiento()
    {
        _horizontal = Input.GetAxis("Horizontal");

        if(_horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animations.SetBool("IsRunning", true);
        }
        else if(_horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animations.SetBool("IsRunning", true);
        }
        else
        {
            _animations.SetBool("IsRunning", false);
        }
    }

    void Jump()
    {
        _rbody.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Impulse);
    }
}
/*
░░░░░░███████ ]▄▄▄▄▄▄▄▄▃
▂▄▅█████████▅▄▃▂
I███████████████████].
◥⊙▲⊙▲⊙▲⊙▲⊙▲⊙▲⊙◤
*/
