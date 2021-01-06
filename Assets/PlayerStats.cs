// Digx7
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealthPots;
    [SerializeField] private int maxHealthPots;
    [SerializeField] private int currentCoins;

    public void setCurrentHealth(int input){
      currentHealth = input;
    }

    public void setMaxHealth(int input){
      maxHealth = input;
    }

    public void setCurrentHealthPots(int input){
      currentHealthPots = input;
    }

    public void setMaxHealthPots(int input){
      maxHealthPots = input;
    }

    public void setCurrentCoins(int input){
      currentCoins = input;
    }

    public int getCurrentHealth(){
      return currentHealth;
    }

    public int getMaxHealth(){
      return maxHealth;
    }

    public int getCurrentHealthPots(){
      return currentHealthPots;
    }

    public int getMaxHealthPots(){
      return maxHealthPots;
    }

    public int getCurrentCoins(){
      return currentCoins;
    }
}
