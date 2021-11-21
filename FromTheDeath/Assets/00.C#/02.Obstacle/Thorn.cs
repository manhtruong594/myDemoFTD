using UnityEngine;

public class Thorn : MonoBehaviour
{
    public ObstacleData obstacleData;
    [SerializeField] Vector3 origin;
    [SerializeField] int fallenSpeed;

    [SerializeField] bool isInScene3;

    // Start is called before the first frame update
    void Start()
    {
        origin = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isInScene3)
        {
            return;
        }

        this.transform.position += Vector3.down * Time.fixedDeltaTime * fallenSpeed;
        if (this.transform.position.y <= -3)
        {
            this.transform.position = origin;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.Instant.PlaySound("impact");
            PlayerGetDmg.Instant.GetDmg(obstacleData.thornDmg, 0.5f);
        }
    }


}
