using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private void Update()
    {
        MoveLeft();
    }

    private void MoveLeft() 
        => transform.Translate(Vector2.left * _speed * Time.deltaTime);
}
