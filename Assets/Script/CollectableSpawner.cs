using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _foodPrefab;
    [SerializeField] private GameObject _Coin;

    [SerializeField]
    private float
        _maxLocationX = 30f,
        _minLocationX = -30f,
        _foodSpawnMinTime = 3f,
        _foodSpawnMaxTime = 10f,
        _coinSpawnMinTime = 5f,
        _coinSpawnMaxTime = 15;

    private Vector3 _locationSpawn;

    private void Start()
    {
        StartCoroutine(foodSpawn());
        StartCoroutine(CoinSpawn());
    }

    public IEnumerator foodSpawn()
    {
        while (true)
        {
            _locationSpawn = new Vector3(Random.Range(_minLocationX, _maxLocationX), transform.position.y, transform.position.z);
            yield return new WaitForSeconds(Random.Range(_foodSpawnMinTime, _foodSpawnMaxTime));
            Instantiate(_foodPrefab, _locationSpawn, Quaternion.identity);
        }
        
    }

    private IEnumerator CoinSpawn()
    {
        while (true)
        {
            _locationSpawn = new Vector3(Random.Range(_minLocationX, _maxLocationX), transform.position.y, transform.position.z);
            yield return new WaitForSeconds(Random.Range(_coinSpawnMinTime, _coinSpawnMaxTime));
            Instantiate(_Coin, _locationSpawn, Quaternion.identity);
        }
    }
}
