using UnityEngine;
using UnityEngine.UI;

public class HechmanUI : Singleton<HechmanUI>
{
    [SerializeField] GameObject hechmanSnake;
    [SerializeField] GameObject hechmanBat;

    public GameObject CallBatButton;
    public GameObject CallSnakeButton;
    public Slider healthBar;


    // Start is called before the first frame update
    void Start()
    {
        hechmanSnake = Resources.Load<GameObject>("00.Prefabs/Snake Hechman");
        hechmanBat = Resources.Load<GameObject>("00.Prefabs/Bat Hechman");

    }

    // Update is called once per frame
    void Update()
    {
        if (!healthBar.gameObject.activeSelf)
            return;
        this.healthBar.value = HechmanController.Instant.HP;
    }


    public void LoadHechmanBat()
    {
        CallBatButton.SetActive(true);
    }



    public void CallHechmanSnake()
    {
        if (!hechmanSnake)
            return;

        GameObject h = Instantiate(hechmanSnake, PlayerController.Instant.transform.position, Quaternion.identity);

        CallSnakeButton.SetActive(false);
        healthBar.gameObject.SetActive(true);
        this.healthBar.maxValue = HechmanController.Instant.maxHP;
        this.healthBar.minValue = 0f;
    }

    public void CallHechmanBat()
    {
        if (!hechmanBat)
            return;

        GameObject h = Instantiate(hechmanBat, PlayerController.Instant.transform.position, Quaternion.identity);

        CallBatButton.SetActive(false);
        healthBar.gameObject.SetActive(true);
        this.healthBar.maxValue = HechmanController.Instant.maxHP;
        this.healthBar.minValue = 0f;
    }

}
