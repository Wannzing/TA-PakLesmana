using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUnlock : MonoBehaviour
{

    public GameObject unlockNotificationUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UnlockNewLevel();
        }
    }

    void UnlockNewLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int reachedIndex = PlayerPrefs.GetInt("ReachedIndex", 1);

        if (currentIndex >= reachedIndex)
        {
            int newIndex = currentIndex + 1;
            PlayerPrefs.SetInt("ReachedIndex", newIndex);

            int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
            if (newIndex > unlockedLevel)
            {
                PlayerPrefs.SetInt("UnlockedLevel", newIndex);
            }

            PlayerPrefs.Save();
            Debug.Log("New Stage Unlocked! Now unlocked up to level: " + newIndex);

            if (unlockNotificationUI != null)
            {
                StartCoroutine(ShowUnlockNotification());
            }
        }
    }

    IEnumerator ShowUnlockNotification()
    {
        AudioManager.Instance.PlaySFX("Notification");
        unlockNotificationUI.SetActive(true);

        
        yield return new WaitForSeconds(2.5f); 
        unlockNotificationUI.SetActive(false);
    }

}
