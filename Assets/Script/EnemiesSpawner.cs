using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public GameObject[] enemie;
    public Transform leftSpawner;
    public Transform rightSpawner;

    GameObject newEnemie;

    EnemieController newScipt;

    void Start()
    {
        StartCoroutine(spawner()) ;
    }

    public IEnumerator spawner() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(3, 5));

            int enemieType = Random.Range(0,enemie.Length);
            int Location = Random.Range(0,2);

            newEnemie = Instantiate(enemie[enemieType]);
            newScipt = newEnemie.GetComponent<EnemieController>();

            

            if (Location == 0)
            {
                newEnemie.transform.position = leftSpawner.position;
                newScipt.EnemieMoveSpeed = 5f;
                newEnemie.transform.localScale = new Vector3(1,1,1);
            }
            else
            {
                newEnemie.transform.position = rightSpawner.position;
                newScipt.EnemieMoveSpeed = -5f;
                newEnemie.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}
