using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _groundDetected;

    private bool _moveRight;

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        RaycastHit2D groundDetected = Physics2D.Raycast(_groundDetected.position, Vector2.down, 1f);
        if (groundDetected.collider == null)
        {
            if (_moveRight == true)
            {
                transform.eulerAngles = new Vector3(0,-180,0);
                _moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                _moveRight = true;
            }               
        }
    }
}
