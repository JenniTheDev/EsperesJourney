// Digx7
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Tooltip ("Object you want to spawn")]
    [SerializeField] private GameObject objectToSpawn;
    [Tooltip ("Where you want to spawn that object")]
    [SerializeField] private Vector3 locationToSpawn;

    public void spawnObject(){
      Instantiate(objectToSpawn, locationToSpawn, Quaternion.identity);
    }
}
