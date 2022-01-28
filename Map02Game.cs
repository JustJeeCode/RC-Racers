using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Map02Game : MonoBehaviour
{

    // Variables
    public Text StartRaceText;
    public GameObject StartRaceTextBG;
    public GameObject StartRaceTextBGBorder;
    public GameObject Player;
    public GameObject PauseGamePanel;
    public GameObject GameEndPanel;
    public GameObject PauseButton;
    public GameObject Minimap;
    public GameObject MinimapBorder;
    public GameObject TimeText;
    public Text Timer;
    public Text LapCount;
    public GameObject LapText;
    public bool gameOn = true;
    public PlayerCollision PlayerCollision;
    public GameObject FailedLevelText;
    public GameObject SuccededLevelText;
    public float timerCount = 0f;
    public Text FinishedTime;
    public bool gamePaused = false;
    public SceneLoader SceneLoader;
    public GameObject DollarSign;
    public Text CashText;

    void Awake()
    {
        StartCoroutine(RaceStart());
    }

    // Hide GUIs
    private void HideGuis()
    {
        PauseGamePanel.SetActive(false);
        GameEndPanel.SetActive(false);
        PauseButton.SetActive(false);
        Minimap.SetActive(false);
        MinimapBorder.SetActive(false);
        TimeText.SetActive(false);
        LapText.SetActive(false);
        StartRaceTextBG.SetActive(false);
        StartRaceTextBGBorder.SetActive(false);
        DollarSign.SetActive(false);
        StartRaceText.text = "";
        Timer.text = "";
        LapCount.text = "";
        CashText.text = "";
    }

    // Show GUIs
    private void ShowGuis()
    {
        PauseButton.SetActive(true);
        Minimap.SetActive(true);
        MinimapBorder.SetActive(true);
        TimeText.SetActive(true);
        LapText.SetActive(true);
        DollarSign.SetActive(true);
        LapCount.text = "1";
    }

    // When race starts
    private IEnumerator RaceStart ()
    {
        HideGuis();
        StartRaceTextBG.SetActive(true);
        StartRaceTextBGBorder.SetActive(true);
        Player.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(2);
        StartRaceText.text = "ON YOUR MARKS...";
        yield return new WaitForSeconds(2);
        StartRaceText.text = "GET SET...";
        yield return new WaitForSeconds(2);
        StartRaceText.text = "GO!!!";
        Player.GetComponent<PlayerMovement>().enabled = true;
        ShowGuis();
        StartCoroutine(TimerStart());
        yield return new WaitForSeconds(2);
        StartRaceText.text = "";
        StartRaceTextBG.SetActive(false);
        StartRaceTextBGBorder.SetActive(false);
    }

    // Timer start
    private IEnumerator TimerStart()
    {
        while (gameOn == true)
        {
            if (gamePaused == false)
            {
                yield return new WaitForSeconds(.01f);
                timerCount = timerCount + .01f;
                Timer.text = "";
                Timer.text = timerCount.ToString("#.00");
                CashText.text = SceneLoader.Cash.ToString();
            } else
            {
                yield return new WaitForSeconds(.01f);
            }
        }
    }

    // When a new lap happens
    public void NewLap()
    {
        if (PlayerCollision.lapCount == 1)
        {
            LapCount.text = "1";
        }   else if (PlayerCollision.lapCount == 2)
        {
            LapCount.text = "2";
        }   else if (PlayerCollision.lapCount == 3)
        {
            LapCount.text = "3";
        }
    }

    // When game ends
    public void GameEnd()
    {
        FinishedTime.text = timerCount.ToString("#.00");

        if (timerCount < 90f)
        {
            SuccededLevelText.SetActive(true);
            FailedLevelText.SetActive(false);
            SceneLoader.level02Completed = true;
            print(SceneLoader.level02Completed);
        }   else
        {
            SuccededLevelText.SetActive(false);
            FailedLevelText.SetActive(true);
        }

        Player.GetComponent<PlayerMovement>().enabled = false;
        GameEndPanel.SetActive(true);
    }

    // Buttons
    public void RetryLevelButton()
    {
        SceneManager.LoadScene("Map02");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GamePause()
    {
        if (gamePaused == false)
        {
            gamePaused = true;
            Player.GetComponent<PlayerMovement>().enabled = false;
            PauseGamePanel.SetActive(true);
        }   else
        {
            gamePaused = false;
            Player.GetComponent<PlayerMovement>().enabled = true;
            PauseGamePanel.SetActive(false);
        }
    }
}
