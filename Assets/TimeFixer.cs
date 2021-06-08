using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFixer : MonoBehaviour
{
    void Awake(){
      Time.timeScale = 1.0f;
    }
}
