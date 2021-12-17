using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] Transform _rayPosition;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    
    private float _moveHorizontal;
    private float _speed;
    private bool _isGrounded;
    private float _rayDistance;

    private const string Speed = "Speed";
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _speed = 2f;
        _rayDistance = 0.1f;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        _moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(_moveHorizontal, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
        Flip();
        if (_moveHorizontal != 0)
            _animator.SetFloat(Speed, _speed);
        else
            _animator.SetFloat(Speed, 0);
    }

    private void Flip()
    {
        Vector3 playerScale = transform.localScale;
        if (_moveHorizontal < 0)
        {
            playerScale.x = -1;            
        }
        if (_moveHorizontal > 0)
            playerScale.x = 1;
        transform.localScale = playerScale;
    }

    private void Jump()
    {
        var moveUp = Input.GetKeyDown(KeyCode.Space);
        CheckGround();
        if (moveUp && _isGrounded)
        {
            _isGrounded = false;
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rayPosition.position, Vector2.down, _rayDistance);
        if (hit.collider)
            _isGrounded=true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Coin>(out Coin coin))
        {           
            Destroy(collision.gameObject);
        }
    }
}
