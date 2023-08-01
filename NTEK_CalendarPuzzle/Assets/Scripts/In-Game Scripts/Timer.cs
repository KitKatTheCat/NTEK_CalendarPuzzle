using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timeText;
    public float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
            currentTime = currentTime + Time.deltaTime;

            TimeSpan time = TimeSpan.FromSeconds(currentTime);

            timeText.text = time.ToString(@"mm\:ss");
            PlayerPrefs.SetFloat("CurrentTime", currentTime);
    }
}
