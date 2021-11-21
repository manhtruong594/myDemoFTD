using UnityEngine;
using System.Collections.Generic;

public class SpawnSnake : MonoBehaviour
{
    [SerializeField] int spawnTime;
    float timerSpawn;
    [SerializeField] int maxCount;
    [SerializeField] [Range(1, 100)] int hechmanRate;   // rate to become a hechman

    GameObject snake;
    List<GameObject> snakes = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        timerSpawn = spawnTime;
    }


    private void FixedUpdate()
    {
        SpawnThis();
    }


    public void SpawnThis()
    {
        timerSpawn -= Time.fixedDeltaTime;

        if (timerSpawn > 0)
            return;

        snake = ObjectPooling.Instant.GetSnake(maxCount, snakes);
        if (!snake)
        {
            return;
        }
        snake.transform.parent = this.transform;
        snake.transform.position = this.transform.position;
        
        AfterSpawn();

    }


    void AfterSpawn()
    {
        int rate = Random.Range(1, 100);
        if (rate > hechmanRate)
        {
            SetSubdue(snake, false);
            return;
        }

        SetSubdue(snake, true);

    }


    void SetSubdue(GameObject snake2, bool canSubdue)
    {
        snake2.GetComponent<EnemyController>().canSubdue = canSubdue;

        timerSpawn = spawnTime;
        snake2.SetActive(true);

    }

}
