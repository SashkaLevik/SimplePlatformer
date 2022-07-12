using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
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
    private float _initialVectorValue = 0;

    private bool _isFacingRight = true;
    private bool _isGrounded;

    private const string OnGround = "onGround";
    private const string IsRun = "isRun";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _currentSpeed = 0;
    }

    private void Update()
    {
        DefineGround();
        Move();
        Reflect();
        Jump();
    }

    private void DefineGround()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _ground);
        _animator.SetBool(OnGround, true);
    }

    private void Move()
    {
        _moveVector.x = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(_moveVector.x * _speed, _rigidbody.velocity.y);

        if (_moveVector.x > _initialVectorValue || _moveVector.x < _initialVectorValue)
        {
            _currentSpeed = _speed;
            _animator.SetBool(IsRun, true);
        }
        else
        {
            _animator.SetBool(IsRun, false);
        }
    }

    private void Jump()
    {
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
            _animator.SetBool(OnGround, false);
        }        
    }

    private void Reflect()
    {
        if ((_moveVector.x < 0 && _isFacingRight) || (_moveVector.x > 0 && !_isFacingRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            _isFacingRight = !_isFacingRight;
        }
    }
}
