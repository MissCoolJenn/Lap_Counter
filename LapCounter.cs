using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LapCounter : MonoBehaviour
{
    string r;
    int lapCountNow, w;
    float lapTime, lastLapTime;
    bool canMathf = false, y, pause;
    public TextMeshProUGUI lapCountLeftUi, lapTimeUi, lastTimeLapUi, nextLapUi, nextLapTextUi;
    public Button nextLapButton;

    void Start()
    {
        buttonNextLapText(true);
    }
    void Update()
    {
        if (canMathf)
        {
            lapTime += Time.deltaTime;
            lapTimeUi.text = lapTime.ToString("F2");
        }
    }
    public void Counter(int w)
    {
        lapCountNow = w;
        if (lapCountNow > 1)
        {
            lapCountLeftUi.text = lapCountNow.ToString();
        }
        else if (lapCountNow == 1)
        {
            lapCountLeftUi.text = "Last Lap";
        }

    }
    void SaveLapTime()
    {
        lastLapTime = lapTime;
        lapTime = 0;
        lastTimeLapUi.text = lastLapTime.ToString("F2");
    }
    public void RecountLap()
    {
        if (lapCountNow > 2 && !pause)
        {
            lapCountNow--;
            Counter(lapCountNow);
            SaveLapTime();
        }
        else if (lapCountNow == 2 && !pause)
        {
            lapCountNow--;
            Counter(lapCountNow);
            SaveLapTime();
            buttonNextLapText(false);
        }
        else if (lapCountNow == 1 && !pause)
        {
            SaveLapTime();
            TimeScalePause(true);
            nextLapButtonUi(false);
        }
    }
    public void nextLapButtonUi(bool q)
    {
        nextLapButton.gameObject.SetActive(q);
        buttonNextLapText(q);
    }
    public void buttonNextLapText(bool e)
    {
        if (e)
        {
            nextLapTextUi.text = "Next Lap";
        }
        else if (!e)
        {
            nextLapTextUi.text = "Save Lap";
        }
    }
    public void nowCanMathfLapTime(bool t)
    {
        lapTime = 0f;
        lastLapTime = 0f;
        y = t;
        StartCoroutine(WaitSomeTime());
    }
    IEnumerator WaitSomeTime()
    {
        yield return new WaitForSeconds(0.1f);
        canMathf = y;
    }
    public void TimeScalePause(bool y)
    {
        if (y)
        {
            pause = true;
            Time.timeScale = 0f;
        }
        else if (!y)
        {
            pause = false;
            Time.timeScale = 1f;
        }
    }
}
