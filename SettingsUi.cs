using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUi : MonoBehaviour
{
    public GameObject CanvasMainMenuUi, CanvasSettinsUi, MainSettingsMenuUi, ChangeSpeedMenuUi, ChangeBackgrondMenuUi, ChangeBackgroundButton, ChangeSpeedButton;

    public void EnableMainSettingsMenu()
    {
        CanvasMainMenuUi.SetActive(false);
        CanvasSettinsUi.SetActive(true);
    }
    public void BackToMainMenu()
    {
        CanvasMainMenuUi.SetActive(true);
        CanvasSettinsUi.SetActive(false);
    }
    public void BackToMainSettingsMenu()
    {
        ChangeSpeedMenuUi.SetActive(false);
        ChangeBackgrondMenuUi.SetActive(false);
        MainSettingsMenuUi.SetActive(true);
    }
    public void ChangeToSpeedSettings()
    {
        MainSettingsMenuUi.SetActive(false);
        ChangeSpeedMenuUi.SetActive(true);
    }
    public void ChangeToBackgroundSettings()
    {
        MainSettingsMenuUi.SetActive(false);
        ChangeBackgrondMenuUi.SetActive(true);
    }
}
