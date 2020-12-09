// Jenni
using System.Collections;
using UnityEngine;

public class OpenOnlyDoor : MonoBehaviour, ITriggerable {
    [SerializeField] private bool doorStartPosition;
    private float delay = 0.5f;
    [SerializeField]private Animator doorAnims;

    private void Awake() {
        // doorAnims = GetComponent<DoorAnims>();
        gameObject.SetActive(doorStartPosition);
        // doorDidItsJob = false;
       
    }

    public void OpenDoor() {
        
        
        gameObject.SetActive(!doorStartPosition);
        doorAnims.SetTrigger("DoorOpen");
        EventController.Instance.BroadcastOnDoorClose();
       // StartCoroutine(OpenAfterAnimation());

    }

      

    //private IEnumerator OpenAfterAnimation() {
        

    //    yield return new WaitForSeconds(delay);
    //    EventController.Instance.BroadcastOnDoorClose();



    //}

    public void TriggerExecute() {
        Debug.Log(" Trigger execute called");
        OpenDoor();
    }

    public void TriggerRelease() {
    }

   

    
}