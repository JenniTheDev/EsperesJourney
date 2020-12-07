//Luis
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPotCounter : MonoBehaviour
{
    [SerializeField] private Text HPotsTxt;
    [SerializeField] private GameObject player;
    private PlayerController playerControllerScript;

    private void Awake()
    {
        //Subscribe();
        playerControllerScript = player.GetComponent<PlayerController>();
        //playerControllerScript.healthPackGained.AddListener(UpdateHealthPotCounter);
        //playerControllerScript.healthPackUsed.AddListener(UpdateHealthPotCounter);

        HPotsTxt.text = playerControllerScript.getCurrentHealthPacks().ToString();
    }

    public void UpdateHealthPotCounter()
    {
        HPotsTxt.text = playerControllerScript.getCurrentHealthPacks().ToString();
    }
}
