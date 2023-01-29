using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private List<GameObject> swapnPoints;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
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
