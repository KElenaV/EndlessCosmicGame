using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreDisplay;
    [SerializeField] private Enemy[] _enemies;

    private int _score;

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Killed += OnEnemyKilled;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Killed -= OnEnemyKilled;
        }
    }

    private void OnEnemyKilled()
    {
        _score++;
        _scoreDisplay.text = $"Score: {_score}";
    }
}
