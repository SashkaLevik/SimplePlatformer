using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _checkRadius;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _ground;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _moveVector;
    private float _currentSpeed;
    public bool _isFacingRight = true;
    public bool _isGrounded;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _currentSpeed = 0;
    }

    private void Update()
    {
        CheckingGround();
        Move();
        Reflect();
        Jump();
    }

    private void CheckingGround()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _ground);
        _animator.SetBool("onGround", true);
    }

    private void Move()
    {
        _moveVector.x = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(_moveVector.x * _speed, _rigidbody.velocity.y);

        if (_moveVector.x > 0 || _moveVector.x < 0)
        {
            _currentSpeed = _speed;
            _animator.SetBool("isRun", true);
        }
        else
        {
            _animator.SetBool("isRun", false);
        }
    }

    private void Jump()
    {
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
            _animator.SetBool("onGround", false);
        }        
    }

    private void Reflect()
    {
        if ((_moveVector.x < 0 && !_isFacingRight) || (_moveVector.x > 0 && _isFacingRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            _isFacingRight = !_isFacingRight;
        }
    }
}
