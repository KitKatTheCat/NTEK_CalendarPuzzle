using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PersonalBest : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text PBTimerText;
    [SerializeField] private TMPro.TMP_Text CurrentTimerText;
    private float currentTime;
    // Start is called before the first frame update
    private void Start()
    {
        currentTime = PlayerPrefs.GetFloat("CurrentTime");
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        CurrentTimerText.text = time.ToString(@"mm\:ss");

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (currentTime > bestTime)
        {
            bestTime = currentTime;
            PlayerPrefs.SetFloat("BestTime", currentTime);
        }

        TimeSpan bestTimer = TimeSpan.FromSeconds(bestTime);
        PBTimerText.text = bestTimer.ToString(@"mm\:ss");

    }
}
