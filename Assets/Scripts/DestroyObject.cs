// Digx
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {
    [SerializeField] float destroyTimeDelay = 0.0f;
    [SerializeField] bool destroyOnImpactWithAnything = false;
    [SerializeField] bool destroyOnAwake = false;
    [SerializeField] List<string> tagsThatCanDestroyThisObject;
    // Object health? If we want it to destroy with a few hits? 

    public void Awake() {
        if (destroyOnAwake) _Destory();
        Subscribe(); // calls subscribe method to broadcast Object destroy
    }

    public void _Destory() {
        Unsubscibe(); // calls unsubscribe method before object destory
        Destroy(gameObject, destroyTimeDelay);
    }

    public bool canThisObjectDamageMe(Collision2D col) {
        foreach (string _tag in tagsThatCanDestroyThisObject) {
            if (col.gameObject.tag == _tag) return true;
        }
        return false;
    }

    public bool canThisObjectDamageMe_Collider2D(Collider2D col) {
        foreach (string _tag in tagsThatCanDestroyThisObject) {
            if (col.gameObject.tag == _tag) return true;
        }
        return false;
    }

    public void OnCollisionEnter2D(Collision2D col) {
        if (destroyOnImpactWithAnything) _Destory();
        else if (canThisObjectDamageMe(col)) _Destory();
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (destroyOnImpactWithAnything) _Destory();
        else if (canThisObjectDamageMe_Collider2D(col)) _Destory();
    }

    // called when object broadcasts it's destroyed
    public void objectDestroyed() {
        AudioSource objectDestoyedSound = GetComponent<AudioSource>();
        objectDestoyedSound.Play();
        Debug.Log("object destoyed sound");
    }

    public void Subscribe() {
        Unsubscibe();
        EventController.Instance.OnObjectDestroy += objectDestroyed;

    }

    public void Unsubscibe() {
        EventController.Instance.OnObjectDestroy -= objectDestroyed;
    }

}
