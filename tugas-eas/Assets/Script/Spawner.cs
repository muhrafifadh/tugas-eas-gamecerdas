using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public int xPos;
    public int zPos;
    public int enemyCount;

    // Update is called once per frame
    void Update()
    {
        CheckEnemyCount();
    }

    void CheckEnemyCount()
    {
        if (enemyCount < 50)
        {
            xPos = Random.Range(-132, 132);
            zPos = Random.Range(-75, 75);
            Instantiate(Enemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            enemyCount += 1;
        }
    }
}