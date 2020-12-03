// Jenni
using System.Collections;
using UnityEngine;

public class OpenOnlyDoor : MonoBehaviour, ITriggerable {
    [SerializeField] private bool doorStartPosition;
    private float delay = 0.5f;
    // private DoorAnims doorAnims;

    private void Awake() {
        // doorAnims = GetComponent<DoorAnims>();
        gameObject.SetActive(doorStartPosition);
        // doorDidItsJob = false;
        Subscribe();
    }

    public void OpenDoor() {
        // this is not working
        //  WaitASecond(2);
        // doorAnims.OpenDoor();
        EventController.Instance.BroadcastDoorOpen();
        gameObject.SetActive(!doorStartPosition);
        
    }

    public void PlayOpenFailAnim() {
        // doorAnim.PlayOpenFailAnim();
        EventController.Instance.BroadcastKeyComboFail();
        // Debug.Log("door fail sound");
    }

    public void TriggerExecute() {
        Debug.Log(" Trigger execute called");
        OpenDoor();
    }

    public void TriggerRelease() {
    }

    public void Subscribe() {
        Unsubscribe();
        EventController.Instance.OnTriggerUse += TriggerExecute;
    }

    public void Unsubscribe() {
        EventController.Instance.OnTriggerUse -= TriggerExecute;
    }

    
}