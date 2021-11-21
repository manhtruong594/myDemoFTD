using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    public Slider playerHealth;

    public GameObject shopNoticeTxt;

    [SerializeField] Text playerParam;
    [SerializeField] GameObject panelPlayerParam;

    [SerializeField]
    bool _jumping, _attacking;
    public bool jumping => _jumping;
    public bool attacking => _attacking;


    public void SetJumping(bool jump)
    {
        _jumping = jump;
    }

    public void SetAttacking(bool attack)
    {
        _attacking = attack;
    }


    // Start is called before the first frame update
    void Start()
    {
        GetReference();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerHealth.value = PlayerController.Instant.HP;
    }

    private void GetReference()
    {
        shopNoticeTxt.SetActive(false);
        playerHealth.maxValue = PlayerController.Instant.maxHP;
        playerHealth.minValue = 0f;
    }

    public void SetPlayerParam()
    {
        playerParam.text = $"HP: {PlayerController.Instant.HP}/ {PlayerController.Instant.maxHP} \nDmg: {PlayerController.Instant.damage}";
        panelPlayerParam.SetActive(true);
        Invoke("inactivePanel", 1f);

    }

    void inactivePanel()
    {
        panelPlayerParam.SetActive(false);
    }

}
