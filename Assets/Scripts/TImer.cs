using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    bool isTimerRunning = true;
    private Animator timer;
    private bool stoppingSoundPlayed = false;
    private void Awake()
    {
        timer = GetComponent<Animator>();
    }
    void OnEnable()
    {
        timer.SetBool("StartTimer", true);
        AudioManager.Instance.PlaySound("Timer_Start");
    }
    void TimerStopped()
    {
        timer.SetBool("StartTimer", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0){
            isTimerRunning = true;
        }
        else{
            isTimerRunning = false;
        }

        if (isTimerRunning)
        {

            time -= Time.deltaTime;
        }
        else
        {
            
            timer.SetBool("StartTimer", false);
            AudioManager.Instance.StopSound("Timer_Start");
            if(stoppingSoundPlayed == false)
            {
                AudioManager.Instance.PlaySound("Timer_Stop");
                stoppingSoundPlayed = true;
            }
        }
    }
}
