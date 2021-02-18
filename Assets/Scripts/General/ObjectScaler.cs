// Digx7
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectScaler : MonoBehaviour
{
    public Vector3Event objectScale;

    [SerializeField] private GameObject objectToScale;
    public enum ScaleMode {increasing, decreasing};
    [SerializeField] private ScaleMode _scaleMode = ScaleMode.increasing;
    [SerializeField] private bool startOnAwake = false;
    [Space]
    [Header ("General")]
    [SerializeField] private Vector3 startingSize;
    [SerializeField] private Vector3 scaleRate;

    public void Awake(){
      if(objectToScale == null) objectToScale = this.gameObject;
      if(startingSize == new Vector3(0,0,0)) startingSize = objectToScale.transform.localScale;

      if(startOnAwake) StartScaling();
    }

    public void StartScaling(){
      StartCoroutine(Scaling());
    }

    public void StopScaling(){
      StopCoroutine(Scaling());
    }

    public void ResetScale(){
      objectToScale.transform.localScale = startingSize;
    }

    public void SetScaleModeToDecreasing(){
      _scaleMode = ScaleMode.decreasing;
    }

    public void SetScaleModeToIncreasing(){
      _scaleMode = ScaleMode.increasing;
    }

    public void setScaleRate (Vector3 input){
      scaleRate = input;
    }

    private IEnumerator Scaling(){
      bool i = true;
      while (i){
        yield return null;
        UpdateObjectScale();
      }
    }

    private void UpdateObjectScale(){
      if(_scaleMode == ScaleMode.increasing)objectToScale.transform.localScale += scaleRate;
      else objectToScale.transform.localScale -= scaleRate;
      objectScale.Invoke(objectToScale.transform.localScale);
    }
}
