using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthPotions : MonoBehaviour
{

    public Image[] potions;
    public Sprite potion;

    private void OnEnable()
    {
        //subscribe to eventcontroller OnHealthPotsUpdate
        EventController.Instance.OnHealthPotsUpdate += UpdateCounter;
    }
    private void OnDisable()
    {
        //unsubscribe to eventcontroller OnHealthPotsUpdate
        EventController.Instance.OnHealthPotsUpdate -= UpdateCounter;
    }

    //UpdateCounter is called when OnHealthPotsUpdate is broadcasted
    void UpdateCounter(int numOfPotions, int maxPotions)
    {
        //do something about max health potions; currently uses maxpotions var but not hooked up to actual image array size; locked at 3
        for (int i = 0; i < maxPotions; i++)
        {
            if (i < numOfPotions)
            {
                potions[i].enabled = true;
            }
            else
            {
                potions[i].enabled = false;
            }
        }
    }
}
