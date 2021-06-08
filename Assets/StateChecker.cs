// Digx7
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateChecker : MonoBehaviour
{
    [SerializeField] private FSM fsm;
    [SerializeField] private string stateToWatchFor;
    [SerializeField] private UnityEvent conditionMet;

    public void setFSM(FSM input){
      fsm = input;
    }

    public void setStateToWatchFor(string input){
      stateToWatchFor = input;
    }

    public bool isCurrentStateTheOneToWatchFor(){
      if(fsm.getCurrentStateName() == stateToWatchFor) return true;
      else return false;
    }

    public void RunStateChecker(){
      if(isCurrentStateTheOneToWatchFor()) conditionMet.Invoke();
    }
}
