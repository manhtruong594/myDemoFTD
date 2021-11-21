using UnityEngine;
using UnityEngine.Events;

public class ClickGameObject : MonoBehaviour
{

    public UnityEvent OnClick = new UnityEvent();
    [SerializeField] GameObject effectParticle;

    private void OnEnable()
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 rayDir = Camera.main.transform.position - mousePos;
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, rayDir);

            //Debug.DrawRay(mousePos, rayDir, Color.yellow,2f);

            foreach (var hit in hits)
            {
                if (hit.collider.gameObject == this.gameObject && Vector2.Distance(mousePos, hit.collider.transform.position) <= 0.5f)
                {
                    //OnClick.Invoke();

                    Instantiate(effectParticle, this.transform.position, Quaternion.identity);

                    GameManager.Instant.IncreaseSoul();

                    gameObject.SetActive(false);

                    
                }
            }

        }

    }

    private void OnMouseDown()
    {

    }

}