using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private float _destroyPoint = 12f;

    private void Update()
    {
        MoveRight();
        Destroy();
    }

    private void MoveRight() 
        => transform.Translate(Vector2.right * _speed * Time.deltaTime);

    private void Destroy()
    {
        if (transform.position.x > _destroyPoint && gameObject.activeSelf == true)
            gameObject.SetActive(false);
    }
}
