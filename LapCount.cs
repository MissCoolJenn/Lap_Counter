using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapCount : MonoBehaviour
{
    string r;
    int lapCountNow, w;
    float lapTime, lastLapTime;
    bool canMathf = false, y;
    public TextMeshProUGUI lapCountLeftUi, lapTimeUi, lastTimeLapUi;

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
        lapCountNow--;
        Counter(lapCountNow);
        SaveLapTime();
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
    public void QuitApp()
    {
        Application.Quit();
    }
    public void TimeScalePause(bool y)
    {
        if (y)
        {
            Time.timeScale = 0f;
        }
        else if (!y)
        {
            Time.timeScale = 1f;
        }
    }
}
