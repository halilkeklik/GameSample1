using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject boss;
    [SerializeField] private List<GameObject> swapnPoints;
    private GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Update()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        if (gameObjects.Length <= 0)
        {
            boss.SetActive(true);
        }
    }

    void Spawn()
    {
        foreach (GameObject swapnPoint in swapnPoints)
        {
            float randRange = (swapnPoint.transform.localScale.x / 2) - 3f;

            Vector2 whereToSpawn1 = new Vector2(swapnPoint.transform.position.x, swapnPoint.transform.position.y + 0.3f);

            if (swapnPoint.transform.localScale.x < 10)
            {
                Instantiate(enemy, whereToSpawn1, Quaternion.identity);
            }
            else
            {
                for (int i = 0; i <= swapnPoint.transform.localScale.x / 10; i++)
                {
                    float randx = Random.Range(-randRange, randRange);
                    Vector2 whereToSpawn2 = new Vector2(randx, swapnPoint.transform.position.y + 0.3f);
                    Instantiate(enemy, whereToSpawn2, Quaternion.identity);
                }
            }
        }
    }
}
