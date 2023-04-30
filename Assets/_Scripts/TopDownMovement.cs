using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 15;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 movementInput = GetMovementInput();
        Vector2 velocity = movementInput * _speed;
        Vector2 movement = velocity * Time.deltaTime;
        Vector2 newPosition = _rigidbody.position + movement;
        _rigidbody.MovePosition(newPosition);
    }

    private static Vector2 GetMovementInput()
    {
        float x = 0;
        float y = 0;
        if (Input.GetKey(KeyCode.W)) y += 1;
        if (Input.GetKey(KeyCode.S)) y -= 1;
        if (Input.GetKey(KeyCode.D)) x += 1;
        if (Input.GetKey(KeyCode.A)) x -= 1;
        return new Vector2(x, y).normalized;
    }
}