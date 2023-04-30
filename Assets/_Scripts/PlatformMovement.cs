using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 15;
    [SerializeField] private float _jumpHeight = 5f;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _groundCheckDistance = .6f;
    private bool _grounded;
    private float _verticalJumpForce;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _verticalJumpForce = Mathf.Sqrt(-2 * _jumpHeight * Physics2D.gravity.y);
    }

    private void Update()
    {
        JumpCheck();
    }

    private void JumpCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _verticalJumpForce);
            _grounded = false;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        CheckGround();
    }

    private void CheckGround()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, _groundCheckDistance, _whatIsGround) && _rigidbody.velocity.y <= 0)
        {
            _grounded = true;
        }
    }

    private void MovePlayer()
    {
        Vector2 movementInput = GetMovementInput();
        Vector2 newVelocity = movementInput * _speed;
        newVelocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = newVelocity;
    }

    private static Vector2 GetMovementInput()
    {
        float x = 0;
        if (Input.GetKey(KeyCode.D)) x += 1;
        if (Input.GetKey(KeyCode.A)) x -= 1;
        return new Vector2(x, 0).normalized;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, Vector3.down * _groundCheckDistance);
    }
}