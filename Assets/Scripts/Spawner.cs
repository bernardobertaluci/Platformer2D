using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _parent;

    private Transform[] _spawners;

    private float _delay = 2f;

    private void Start()
    {
        _spawners = new Transform[_parent.childCount];

        for (int i = 0; i < _spawners.Length; i++)
        {
            _spawners[i] = _parent.GetChild(i);
        }

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        for (int i = 0; i < _spawners.Length; i++)
        {
            Instantiate(_template, _spawners[i].position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }   
}
