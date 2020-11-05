using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private void OnEnable()
    {
        slider = gameObject.GetComponent<Slider>();
        //subscribe to eventcontroller OnHealthPotsUpdate
        EventController.Instance.OnHealthUpdate += UpdateHealthBar;
    }
    private void OnDisable()
    {
        //unsubscribe to eventcontroller OnHealthPotsUpdate
        EventController.Instance.OnHealthUpdate -= UpdateHealthBar;
    }

    // UpdateHPCounter is called when OnHealthUpdate is broadcasted
    private void UpdateHealthBar(int hp)
    {
        slider.value = hp;
    }
}
