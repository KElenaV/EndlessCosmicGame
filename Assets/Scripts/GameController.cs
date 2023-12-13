using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy[] _enemies;

    [SerializeField] private AudioClip _shoot;
    [SerializeField] private AudioClip _collision;

    private AudioSource _audio;
    private PlayerShoot _playerShoot;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _playerShoot = _player.GetComponent<PlayerShoot>();
    }

    private void OnEnable()
    {
        _player.Collided += OnCollided;
        _player.GameOver += OnGameOver;
        _playerShoot.Shooted += OnShoot;

        foreach (var enemy in _enemies)
        {
            enemy.Killed += OnCollided;
        }
    }

    private void OnDisable()
    {
        _player.Collided -= OnCollided;
        _player.GameOver -= OnGameOver;
        _playerShoot.Shooted -= OnShoot;

        foreach (var enemy in _enemies)
        {
            enemy.Killed -= OnCollided;
        }
    }

    private void OnGameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        OnCollided();
    }

    private void OnShoot()
    {
        _audio.PlayOneShot(_shoot);
    }

    private void OnCollided()
    {
        _audio.PlayOneShot(_collision);
    }
}
