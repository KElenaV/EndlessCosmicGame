using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private PlayerInput _input;
    private float _xBoard = 10f;
    private float _yBoard = 5f;

    public event UnityAction GameOver;
    public event UnityAction Collided;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            StartCoroutine(Die(enemy));
        }
    }

    private IEnumerator Die(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        Collided?.Invoke();
        yield return new WaitForSeconds(0.2f);
        GameOver?.Invoke();
        Destroy(gameObject);
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
