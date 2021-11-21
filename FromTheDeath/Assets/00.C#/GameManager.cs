using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject gameoverTxt;
    [SerializeField] GameObject restartBtn;
    [SerializeField] Text coinTxt;
    public int coinCount;
    [SerializeField] Text soulTxt;
    public int soulCount;
    [SerializeField] EasyTween winGameTxt;
    [SerializeField] GameObject fireworks;
    [SerializeField] GameObject gameSettingBtn;
    [SerializeField] GameObject mainMenuBtn;

    public void RestartGame()
    {
        ScenesLoader.Instant.StartLoader(2);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameoverTxt.SetActive(true);
        restartBtn.SetActive(true);
        gameSettingBtn.SetActive(false);
        mainMenuBtn.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void IncreaseCoin(int coinGain)
    {
        coinCount += coinGain;
        coinTxt.text = coinCount.ToString();
    }

    public void DecreaseCoin(int coinReduce)
    {
        coinCount -= coinReduce;
        coinTxt.text = coinCount.ToString();
    }


    public void IncreaseSoul()
    {
        soulCount += 1;
        soulTxt.text = soulCount.ToString();
    }

    public void DecreaseSoul(int soulReduce)
    {
        soulCount -= soulReduce;
        soulTxt.text = soulCount.ToString();
    }


    public void MusicOnOff()
    {
        SoundManager.Instant.isMute = !SoundManager.Instant.isMute;
        if (SoundManager.Instant.music.volume == 0)
        {
            SoundManager.Instant.music.volume = 0.5f;
            return;
        }

        SoundManager.Instant.music.volume = 0;

        
    }

    public void GameFinish()
    {
        winGameTxt.OpenCloseObjectAnimation();
        PauseGame();
        restartBtn.SetActive(true);
        fireworks.SetActive(true);
        mainMenuBtn.SetActive(true);

    }


}
