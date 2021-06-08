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

    [SerializeField] private IntEvent countIncreased;
    [SerializeField] private IntEvent countDecreased;

    [SerializeField] private IntEvent countIsFull;
    [SerializeField] private IntEvent countIsEmpty;

    [SerializeField] private IntEvent _maxCount;
    [SerializeField] private IntEvent _currentCount;

    // --- Updates ---------------------------------------

    public void Awake(){
      _maxCount.Invoke(maxCount);
      _currentCount.Invoke(currentCount);
    }

    public void updateCurrentCount(int input){
      currentCount += input;
      if(!canGoBeyondMaxAndMins && currentCount > maxCount) {
        currentCount = maxCount;
        countIsFull.Invoke(currentCount);
        return;
      }
      if(!canGoBeyondMaxAndMins && currentCount < minCount) {
        currentCount = minCount;
        countIsEmpty.Invoke(currentCount);
        return;
      }
      if(currentCount - input < currentCount){
        countIncreased.Invoke(currentCount);
        return;
      }
      if(currentCount - input > currentCount){
        countDecreased.Invoke(currentCount);
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
