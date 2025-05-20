using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject levelPanel;

    private void Awake()
    {
        levelPanel.SetActive(false);
    }

    public void play()
    {
        levelPanel.SetActive(true);
    }

    public void back()
    {
        levelPanel.SetActive(false);
    }
}
