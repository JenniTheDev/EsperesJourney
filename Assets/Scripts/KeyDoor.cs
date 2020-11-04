using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour {

    [SerializeField] private Key.KeyType keyType;

    // private DoorAnims doorAnims;

    private void Awake() {
       // doorAnims = GetComponent<DoorAnims>();
    }

    public Key.KeyType GetKeyType() {
        return keyType;
    }

    public void OpenDoor() {
        //  doorAnims.OpenDoor();
        // hides door when key is used - could also destroy object ? 
        gameObject.SetActive(false);
    }

    public void PlayOpenFailAnim() {
        // doorAnim.PlayOpenFailAnim();
        // AudioSource doorFailSound = GetComponent<AudioSource>();
        // doorFailSound.Play();
        // Debug.Log("door fail sound");
    }
}
