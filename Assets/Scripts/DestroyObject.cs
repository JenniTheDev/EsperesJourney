// Digx
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] float destroyTimeDelay = 0.0f;
    [SerializeField] bool destroyOnImpactWithAnything = false;
    [SerializeField] bool destroyOnAwake = false;
    [SerializeField] List<string> tagsThatCanDestroyThisObject;

    public void Awake(){
      if(destroyOnAwake) _Destory();
    }

    public void _Destory(){
      Destroy(gameObject, destroyTimeDelay);
    }

    public bool canThisObjectDamageMe(Collision2D col){
      foreach(string _tag in tagsThatCanDestroyThisObject)
      {
        if(col.gameObject.tag == _tag) return true;
      }
      return false;
    }

    public bool canThisObjectDamageMe_Collider2D (Collider2D col){
      foreach(string _tag in tagsThatCanDestroyThisObject)
      {
        if(col.gameObject.tag == _tag) return true;
      }
      return false;
    }

    public void OnCollisionEnter2D (Collision2D col){
      if(destroyOnImpactWithAnything) _Destory();
      else if (canThisObjectDamageMe(col)) _Destory();
    }

    public void OnTriggerEnter2D (Collider2D col){
      if(destroyOnImpactWithAnything) _Destory();
      else if (canThisObjectDamageMe_Collider2D(col)) _Destory();
    }
}
