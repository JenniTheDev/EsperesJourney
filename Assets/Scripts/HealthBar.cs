//Luis
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Slider slider;
    private PlayerController playerControllerScript;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        playerControllerScript = player.GetComponent<PlayerController>();
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