using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Projectile[] _projectiles;

    private PlayerInput _input;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();

        foreach (var projectile in _projectiles)
        {
            projectile.gameObject.SetActive(false);
        }
    }

    private void OnEnable() => _input.Shoot += OnShoot;

    private void OnDisable() => _input.Shoot -= OnShoot;

    private void OnShoot()
    {
        var projectile = _projectiles.FirstOrDefault(p => p.gameObject.activeSelf == false);
        
        if (projectile)
        {
            projectile.gameObject.SetActive(true);
            projectile.transform.position = _shootPoint.position;
        }
    }
}
