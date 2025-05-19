using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugReset : MonoBehaviour
{


    public void ResetStages()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Stage progress reset.");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
