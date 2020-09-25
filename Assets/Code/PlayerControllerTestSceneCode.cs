// Digx7
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTestSceneCode : MonoBehaviour
{
    // THIS CODE WAS BUILT FOR THE SPECIFIC DEV SCENE "PLAYER CONTROLLER" AND IS
    // NOT MEANT TO BE USED IN THE FINAL PRODUCT

    // This code shows what needs to happen for the player to respawn
    // 1. a new player prefab needs to be Instantiated
    // 2. the PlayerInput.Rebind() function needs to be run in order to bind the inputs to the new player prefab

    public Spawner playerSpawner;
    public PlayerInput codeHolder;

    public void Update()
    {
      if(Input.GetKeyDown(KeyCode.R)){
        playerSpawner.spawnObject();
        codeHolder.Rebind();
      }
    }
}
