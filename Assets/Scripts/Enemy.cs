using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private ParticleSystem _explosion;

    private float _destroyPoint = -12.5f;

    private void Update()
    {
        MoveLeft();
        DestroyIfUnbound();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Projectile projectile))
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
            _explosion.Play();
            projectile.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void MoveLeft() 
        => transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);

    private void DestroyIfUnbound()
    {
        if (transform.position.x < _destroyPoint && gameObject.activeSelf == true)
            gameObject.SetActive(false);
    }
}
