using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private PlayerInput _input;
    private float _xBoard = 10f;
    private float _yBoard = 5f;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_input.Direction * Time.deltaTime * _speed, Space.World);

        transform.position = new Vector2(
            SetBoard(transform.position.x, _xBoard),
            SetBoard(transform.position.y, _yBoard));
    }

    private float SetBoard(float axis, float board) 
        => Mathf.Clamp(axis, -board, board);
}
