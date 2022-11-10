using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUi : MonoBehaviour
{
    public GameObject MainMenuUi, SettingsUi, ChooseLapsUi, TimeCounterUi, MenuButtonUi, StartButton, PauseButton, NextLapButton;

    public void ChangeToMainMenu()
    {
        MainMenuUi.SetActive(true);
        MenuButtonUi.SetActive(false);
        ChooseLapsUi.SetActive(false);
        TimeCounterUi.SetActive(false);
        gameObject.GetComponent<LapCounter>().TimeScalePause(false);
    }
    public void ChangeToChooseLaps()
    {
        MainMenuUi.SetActive(false);
        ChooseLapsUi.SetActive(true);
        MenuButtonUi.SetActive(true);
    }
    public void ChangeToTimeCounter(int q)
    {
        ChooseLapsUi.SetActive(false);
        TimeCounterUi.SetActive(true);
        gameObject.GetComponent<LapCounter>().Counter(q);
        gameObject.GetComponent<LapCounter>().TimeScalePause(true);
        StartButton.SetActive(true);
        PauseButton.SetActive(false);
        NextLapButton.SetActive(true);
        gameObject.GetComponent<LapCounter>().buttonNextLapText(true);
        gameObject.GetComponent<LapCounter>().nowCanMathfLapTime(true);
    }
    public void QuitApp()
    {
        Application.Quit();
    }
    public void ChangePauseNow(bool e)
    {
        if (!e)
        {
            PauseButton.SetActive(true);
            StartButton.SetActive(false);
            gameObject.GetComponent<LapCounter>().TimeScalePause(false);
        }
        else if (e)
        {
            PauseButton.SetActive(false);
            StartButton.SetActive(true);
            gameObject.GetComponent<LapCounter>().TimeScalePause(true);
        }
    }
}
