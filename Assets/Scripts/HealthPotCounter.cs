using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPotCounter : MonoBehaviour
{
    [SerializeField] private Text HPotsTxt;
    [SerializeField] private GameObject player;
    private void OnEnable()
    {
        Subscribe();
        HPotsTxt.text = player.GetComponent<PlayerController>().getCurrentHealthPacks().ToString();
    }
    private void OnDisable()
    {
        Unsubscribe();
    }

    private void UpdateHealthPotCounter(int HPots)
    {
        HPotsTxt.text = HPots.ToString();
    }

    public void Subscribe()
    {
        Unsubscribe();
        //subscribe to eventcontroller OnHealthPotsUpdate
        // EventController.Instance.OnCoinUpdate += UpdateCoinCounter;
    }

    public void Unsubscribe()
    {
        //unsubscribe to eventcontroller OnHealthPotsUpdate
        //  EventController.Instance.OnCoinUpdate -= UpdateCoinCounter;
    }
}
