//Luis
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPotCounter : MonoBehaviour
{
    [SerializeField] private Text HPotsTxt;
    //[SerializeField] private GameObject player;
    //private PlayerController playerControllerScript;
    [SerializeField] private GameObject PlayerStatsObject;
    private PlayerStats playerControllerScript;

    private void Start()
    {
        //Subscribe();
        playerControllerScript = PlayerStatsObject.GetComponent<PlayerStats>();
        //playerControllerScript.healthPackGained.AddListener(UpdateHealthPotCounter);
        //playerControllerScript.healthPackUsed.AddListener(UpdateHealthPotCounter);

        HPotsTxt.text = playerControllerScript.getCurrentHealthPots().ToString();
        Debug.Log(playerControllerScript.getCurrentHealthPots());
    }

    public void UpdateHealthPotCounter()
    {
        HPotsTxt.text = "" + playerControllerScript.getCurrentHealthPots();
    }
}
