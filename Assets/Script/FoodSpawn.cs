using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _foodPrefab;

    private void Start()
    {
        StartCoroutine(foodSpawn());
    }

    public IEnumerator foodSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f,10f));
            Instantiate(_foodPrefab, new Vector3(Random.Range(-30f,30f), transform.position.y, transform.position.z), Quaternion.identity);
        }
        
    }
}
