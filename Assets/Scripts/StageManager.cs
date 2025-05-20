using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;

            // Try to find "Locked" text in each button
            TextMeshProUGUI lockedText = buttons[i].GetComponentInChildren<TextMeshProUGUI>(true);
            if (lockedText != null)
            {
                lockedText.gameObject.SetActive(true);
            }
        }

        for (int i = 0; i < unlockedLevel && i < buttons.Length; i++)
        {
            buttons[i].interactable = true;

            // Disable the "Locked" text for unlocked stages
            TextMeshProUGUI lockedText = buttons[i].GetComponentInChildren<TextMeshProUGUI>(true);
            if (lockedText != null)
            {
                lockedText.gameObject.SetActive(false);
            }
        }
    }
}
