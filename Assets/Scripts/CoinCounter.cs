using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private Text coinsTxt;
    private void OnEnable()
    {
        Subscribe();
    }
    private void OnDisable()
    {
        Unsubscribe();  
    }

    private void UpdateCoinCounter(int coins) {
        coinsTxt.text = coins.ToString();
    }

    public void Subscribe() {
        Unsubscribe();
        //subscribe to eventcontroller OnHealthPotsUpdate
       // EventController.Instance.OnCoinUpdate += UpdateCoinCounter;
    }

    public void Unsubscribe() {
        //unsubscribe to eventcontroller OnHealthPotsUpdate
      //  EventController.Instance.OnCoinUpdate -= UpdateCoinCounter;
    }



}
