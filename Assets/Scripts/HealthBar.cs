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
    }

    // UpdateHealthbar is called when player events for healthincrease and healthdecrease are invoked
    public void UpdateHealthBar()
    {
        if (playerControllerScript != null) { Debug.Log("1"); }
        else { Debug.Log("0"); }

        int currValue = playerControllerScript.getCurrentHealth();
        Debug.Log("current health is " + slider.value);
        slider.value = currValue;
        Debug.Log("New value is " + slider.value);
    }
}
