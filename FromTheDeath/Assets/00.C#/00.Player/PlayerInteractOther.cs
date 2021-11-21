using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerInteractOther : Singleton<PlayerInteractOther>
{

    [SerializeField] EasyTween loaderAnim;

    [SerializeField] GameObject shopBtn;
    [SerializeField] GameObject shopPanel;

    [SerializeField] Vector3 startScene2;
    [SerializeField] Vector3 endScene1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == GameStrings.rightDoor1)
        {
            loaderAnim.OpenCloseObjectAnimation();
            GameManager.Instant.PauseGame();
            StartCoroutine(WaitForLoadingBlock(LoadScene2));
        }

        else if (collision.gameObject.name == GameStrings.leftDoor2)
        {
            loaderAnim.OpenCloseObjectAnimation();
            GameManager.Instant.PauseGame();
            StartCoroutine(WaitForLoadingBlock(LoadScene1));
        }

        else if (collision.gameObject.name == GameStrings.rightDoor2)
        {
            loaderAnim.OpenCloseObjectAnimation();
            GameManager.Instant.PauseGame();
            StartCoroutine(WaitForLoadingBlock(LoadScene3));
        }

        else if (collision.CompareTag( GameStrings.HPbottle))
        {
            PlayerBuff.Instant.HPRegen(100);
            collision.gameObject.SetActive(false);
        }

    }

    IEnumerator WaitForLoadingBlock(UnityAction loadScene)
    {
        yield return new WaitForSecondsRealtime(1);
        loadScene();
        loaderAnim.OpenCloseObjectAnimation();
        GameManager.Instant.ResumeGame();
    }


    void LoadScene1()
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(3);
        this.transform.position = endScene1;
        Camera.main.transform.position = new Vector3(endScene1.x, endScene1.y, -10);
    }

    void LoadScene2()
    {
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(2);
        this.transform.position = startScene2;
        Camera.main.transform.position = new Vector3(0, 0, -10);

    }

    void LoadScene3()
    {
        SceneManager.LoadSceneAsync(4, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(3);
        this.transform.position = endScene1;
        Camera.main.transform.position = new Vector3(endScene1.x, endScene1.y, -10);
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(GameStrings.shop))
        {
            shopBtn.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(GameStrings.shop))
        {
            shopBtn.SetActive(false);
            shopPanel.SetActive(false);
        }
    }



}
