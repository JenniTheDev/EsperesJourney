//Luis
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //[SerializeField] private GameObject player;
    [SerializeField] private GameObject PlayerStatsObject;
    private Slider slider;
    private PlayerStats playerControllerScript;
    //private PlayerController playerControllerScript;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        playerControllerScript = PlayerStatsObject.GetComponent<PlayerStats>();
        if (playerControllerScript = null) { Debug.LogError("Player Controller Script not found."); }
    }

    // UpdateHealthbar is called when player events for healthincrease and healthdecrease are invoked
    public void UpdateHealthBar()
    {

        int currValue = playerControllerScript.getCurrentHealth();
        Debug.Log("current health is " + slider.value);
        slider.value = currValue;
        Debug.Log("New value is " + slider.value);
    }
}
