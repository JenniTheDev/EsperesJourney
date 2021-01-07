//Luis
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private Text CoinsTxt;
    //[SerializeField] private GameObject player;
    private void OnEnable()
    {
        Subscribe();
        //CoinsTxt.text = ;
    }

    private void OnDisable() {
        Unsubscribe();
    }

    private void UpdateCoinCounter(int coins) {
        //coinsTxt.text = coins.ToString();
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
