using UnityEngine;
using System.IO;
using System.Collections;


public class SaveLoad : MonoBehaviour
{
    GameData gameData = new GameData();
    string json;
    [SerializeField] EasyTween LoaderAnim;
    [SerializeField] EasyTween settingPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameData.playerPosition = Vector3.zero;
    }

   

    public void SaveGame()
    {
        gameData.playerPosition = PlayerController.Instant.transform.position;
        gameData.coins = GameManager.Instant.coinCount;
        gameData.souls = GameManager.Instant.soulCount;
        gameData.sceneIndex = ScenesLoader.Instant.GetSceneIndex();

        json = JsonUtility.ToJson(gameData);
        Debug.Log("Game Saved !");
        Debug.Log(gameData.playerPosition);


        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);

    }



    public void LoadGame()
    {
        json = File.ReadAllText(Application.persistentDataPath + "/saveFile.json");
        Debug.Log(json);

        gameData = JsonUtility.FromJson<GameData>(json);

        LoaderAnim.OpenCloseObjectAnimation();
        settingPanel.OpenCloseObjectAnimation();

        ScenesLoader.Instant.LoadGameScene(gameData.sceneIndex, ScenesLoader.Instant.GetSceneIndex());
        StartCoroutine(SetData());

    }

    IEnumerator SetData()
    {
        yield return new WaitForSecondsRealtime(1);

        GameManager.Instant.ResumeGame();
        PlayerController.Instant.transform.position = gameData.playerPosition;
        GameManager.Instant.coinCount = gameData.coins;
        GameManager.Instant.soulCount = gameData.souls;

        LoaderAnim.OpenCloseObjectAnimation();
        Debug.Log("Game Loaded !");
    }


}
