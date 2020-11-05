using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private Text coinsTxt;
    private void OnEnable()
    {
        //subscribe to eventcontroller OnHealthPotsUpdate
        EventController.Instance.OnCoinUpdate += UpdateCoinCounter;
    }
    private void OnDisable()
    {
        //unsubscribe to eventcontroller OnHealthPotsUpdate
        EventController.Instance.OnCoinUpdate -= UpdateCoinCounter;
    }

    private void UpdateCoinCounter(int coins) {
        coinsTxt.text = coins.ToString();
    }
}
