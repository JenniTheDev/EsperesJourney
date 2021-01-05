// Digx7
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private bool StartOnAwake = false;
    [SerializeField] private float currentTime;
    [SerializeField] private float targetTime;
    private float timeDifference;

    public enum CountDirection {CountUp, CountDown}

    [SerializeField] private CountDirection countDirection = CountDirection.CountUp;

    [SerializeField] private UnityEvent TimerDone;

    // --- Main Methods -------------------------

    public void Awake(){
      if(StartOnAwake) startTimer();
    }

    public void startTimer(){
      StartCoroutine(timer());
    }

    public void TimerDoneEvent(){
      TimerDone.Invoke();
    }

    // --- Get/Set -----------------------------

    public void setCurrentTime(float input){
      currentTime = input;
    }

    public void setTargetTime(float input){
      currentTime = input;
    }

    public float getCurrentTime(){
      return currentTime;
    }

    public float getTargetTime(){
      return targetTime;
    }

    public float getTimeDifference(){
      if(countDirection == CountDirection.CountUp)
        return targetTime - currentTime;
      else return currentTime - targetTime;
    }

    // --- IEnumerators ---------------------

    private IEnumerator timer(){
      yield return new WaitForSeconds(getTimeDifference());
      TimerDoneEvent();
      yield return null;
    }
}
