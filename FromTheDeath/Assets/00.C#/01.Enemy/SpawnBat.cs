using UnityEngine;
using System.Collections.Generic;

public class SpawnBat : MonoBehaviour
{
    [SerializeField] int spawnTime;
    float timerSpawn;
    [SerializeField] int maxCount;
    [SerializeField] [Range(1, 100)] int hechmanRate;   // rate to become a hechman

    [SerializeField] Transform spawnPoint;
    public List<GameObject> bats = new List<GameObject>();
    GameObject bat;

    // Start is called before the first frame update
    void Start()
    {
        timerSpawn = spawnTime;
        spawnPoint.parent = PlayerController.Instant.transform;
        spawnPoint.transform.localPosition = new Vector3(7, 4, 0);
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

        bat = ObjectPooling.Instant.GetBat(maxCount, bats);

        if (!bat)
        {
            return;
        }

        bat.transform.parent = this.transform;
        bat.transform.position = spawnPoint.position;

        AfterSpawn();

        Vector2 startMove = PlayerController.Instant.transform.position - spawnPoint.position;
        bat.GetComponent<Rigidbody2D>().AddForce(startMove * 3);

    }

    void AfterSpawn()
    {
        int rate = Random.Range(1, 100);
        if (rate > hechmanRate)
        {
            SetSubdue(bat, false);
            return;
        }

        SetSubdue(bat, true);

    }


    void SetSubdue(GameObject bat2, bool cansubdue)
    {
        bat2.GetComponent<EnemyController>().canSubdue = cansubdue;

        timerSpawn = spawnTime;
        bat2.SetActive(true);

    }
}
