using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private float _delay = 0.5f;

    private float _yBound = 4.5f;
    private WaitForSeconds _waitForSecond;

    private void Start()
    {
        _waitForSecond = new WaitForSeconds(_delay);

        foreach (var enemy in _enemies)
        {
            enemy.gameObject.SetActive(false);
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return _waitForSecond;

            var enemy = _enemies.FirstOrDefault(e => e.gameObject.activeSelf == false);

            if (enemy)
            {
                enemy.gameObject.SetActive(true);
                enemy.transform.position = new Vector3(transform.position.x, Random.Range(-_yBound, _yBound));
            }
        }
    }
}
