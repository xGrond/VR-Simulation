using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIControl : MonoBehaviour {

    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject warningText;

    public void ShowWarning() {
        warningText.SetActive(true);
    }

    public void HideWarning() {
        warningText.SetActive(false);
    }

    public void ShowMission() {
        gameOverText.SetActive(true);
    }

    public void HideMission() {
        gameOverText.SetActive(false);
    }


}
