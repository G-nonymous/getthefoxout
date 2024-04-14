using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private float time;
    public float curTime;
    private int minute;
    private int second;

    private void Awake()
    {
        time = 60;
        curTime = time;
        _ = StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        curTime = time;
        while (curTime > 0)
        {
            curTime -= Time.deltaTime;
            minute = (int)curTime / 60;
            second = (int)curTime % 60;
            timeText.text = minute.ToString("00") + ":" + second.ToString("00");
            yield return null;

            if (curTime <= 0)
            {
                curTime = 0;
                timeText.text = "You have made it through!";
                yield return new WaitForSeconds(3);
                if (SceneManager.GetActiveScene().buildIndex == 5)
                {
                    SceneManager.LoadScene(7);
                }
                else SceneManager.LoadScene(6);
                yield break;
            }
        }
    }
}
