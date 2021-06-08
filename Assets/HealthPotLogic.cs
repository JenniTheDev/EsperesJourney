using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthPotLogic : MonoBehaviour
{
    [SerializeField] private Counter healthPotCounter;
    [SerializeField] private UnityEvent CanUseHealthPot;
    [SerializeField] private UnityEvent CantUseHealthPot;

    public void tryToUseHealthPot(){
      if(healthPotCounter.getCurrentCount() != 0)
        CanUseHealthPot.Invoke();
      else CantUseHealthPot.Invoke();
    }
}
