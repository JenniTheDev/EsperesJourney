// Digx7
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private int currentCount = 0;
    [SerializeField] private int maxCount = 10;
    [SerializeField] private int minCount = 0;
    [SerializeField] private bool canGoBeyondMaxAndMins = false;

    [SerializeField] private UnityEvent countIncreased;
    [SerializeField] private UnityEvent countDecreased;

    [SerializeField] private UnityEvent countIsFull;
    [SerializeField] private UnityEvent countIsEmpty;

    // --- Updates ---------------------------------------

    public void updateCurrentCount(int input){
      currentCount += input;
      if(!canGoBeyondMaxAndMins && currentCount > maxCount) {
        currentCount = maxCount;
        countIsFull.Invoke();
        return;
      }
      if(!canGoBeyondMaxAndMins && currentCount < minCount) {
        currentCount = minCount;
        countIsEmpty.Invoke();
        return;
      }
      if(currentCount - input < currentCount){
        countIncreased.Invoke();
        return;
      }
      if(currentCount - input > currentCount){
        countDecreased.Invoke();
        return;
      }
    }

    // --- Get/Set ----------------------------------------

    public void setCurrentCount(int input){
      currentCount = input;
    }

    public void setMaxCount(int input){
      maxCount = input;
    }

    public void setMinCount(int input){
      minCount = input;
    }

    public int getCurrentCount(){
      return currentCount;
    }

    public int getMaxCount(){
      return maxCount;
    }

    public int getMinCount(){
      return minCount;
    }
}
