// Digx7
// Replaces Spawner.
// Will us the Spawn class to Instantiate or spawn in what ever you want where you want it
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    /* Description --
     *  this script will handel reading a Spawn Class and spawning that item
     */

    public Spawn spawn;

    // this function will run on the start of the scene
    public void Awake (){

        // starts corouting spawning
       if (spawn.startOnAwake)
        {
            StartCoroutine("spawning");
        }
    }

    // this function will start the Coroutine spawning
    public void startSpawning (){
        StartCoroutine("spawning");
    }

    // this function will stop the Coroutine spawning
    public void stopSpawning (){
        StopCoroutine("spawning");
    }

    // this function will handel reading the spawn class and spawning the item
    IEnumerator spawning (){
        int x = 0;
        float rate;
        Vector3 location;

        // will run until has hit max rate
        while(x < spawn.maxSpawn)
        {
            //find spawn rate
            rate = UnityEngine.Random.Range(spawn.spawnRateRange.x, spawn.spawnRateRange.y);
            yield return new WaitForSeconds(rate);

            //increment spawned
            if(!spawn.spawnInfinitly)x++;

            //find spawn location
            if (spawn.spawnMode == Spawn.mode.UseCordinates){
              location = new Vector3(
                  UnityEngine.Random.Range(spawn.spawnLocationXRange.x, spawn.spawnLocationXRange.y),
                  UnityEngine.Random.Range(spawn.spawnLocationYRange.x, spawn.spawnLocationYRange.y),
                  UnityEngine.Random.Range(spawn.spawnLocationZRange.x, spawn.spawnLocationZRange.y)
                  );
              location += spawn.spawnLocation;
              if (spawn.spawnRelitiveToThisGameObject)
              {
                  location += gameObject.transform.position;
              }
            }
            else{
              location = spawn.spawnLocationGameObject.transform.position;
            }

            //spawn object
            GameObject g = Instantiate(spawn.spawnableObject, location, Quaternion.identity);
        }
    }


}
