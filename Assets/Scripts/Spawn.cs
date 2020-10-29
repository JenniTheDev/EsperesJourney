// Digx7
// This class is used by the SpawnerScript
﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

[System.Serializable]
public class Spawn
{
    /* Description --
     *  this script will store all the needed data for a Spawn class
     */
    public string objectName;
    public GameObject spawnableObject;
    public bool startOnAwake = true;
    public Vector2 spawnRateRange = new Vector2(1.0f, 3.0f);
    public int maxSpawn = 10;
    public enum mode {UseCordinates, UseObject};
    public mode spawnMode = mode.UseObject;
    public GameObject spawnLocationGameObject;
    public Vector3 spawnLocation;
    public bool spawnRelitiveToThisGameObject = true;
    public Vector2 spawnLocationXRange = new Vector2(-1.0f,1.0f);
    public Vector2 spawnLocationYRange = new Vector2(-1.0f, 1.0f);
    public Vector2 spawnLocationZRange = new Vector2(-1.0f, 1.0f);



    public Spawn ()
    {

    }




}
