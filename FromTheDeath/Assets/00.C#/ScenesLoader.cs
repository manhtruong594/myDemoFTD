using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : Singleton<ScenesLoader>
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    
    
    private void Awake()
    {


    }
    private void Start()
    {
        
    }

    public void StartLoader(int indexAdditive)
    {
        SceneManager.LoadScene(1);
        SceneManager.LoadSceneAsync(indexAdditive, LoadSceneMode.Additive);

    }

    public void LoadGameScene(int sceneLoad, int sceneUnload)
    {
        SceneManager.LoadSceneAsync(sceneLoad, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(sceneUnload);
    }

    public int GetSceneIndex()
    {
        return SceneManager.GetSceneAt(1).buildIndex;
    }


    public void LoadNextScene()
    {
        int currentIndex = SceneManager.GetSceneAt(2).buildIndex;
        Debug.Log(currentIndex);
        //SceneManager.LoadScene(currentIndex + 1);
    }

    public void LoadTutorialScene()
    {
        SceneManager.LoadScene(5);
    }
   
}
