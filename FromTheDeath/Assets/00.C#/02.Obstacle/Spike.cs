using UnityEngine;

public class Spike : MonoBehaviour
{
    public ObstacleData obstacleData;
    Rigidbody2D playerRigi;

    // Start is called before the first frame update
    void Start()
    {
        playerRigi = PlayerController.Instant?.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.Instant.PlaySound("impact");
            PlayerGetDmg.Instant.GetDmg(obstacleData.spikeDmg, 0.5f);
            PlayerGetDmg.Instant.Invulnerable();

            playerRigi.velocity = Vector2.zero;
            playerRigi.AddForce((collision.transform.position - this.transform.position).normalized * obstacleData.spikePushForce);
        }
    }

}
