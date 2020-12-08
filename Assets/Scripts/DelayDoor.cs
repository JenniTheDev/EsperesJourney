using System.Collections;
using UnityEngine;

public class DelayDoor : Door {
    private float delay = 0.75f;

    protected override void OpenDoor() {
        doorAnimation.SetTrigger("DoorOpen");  // calls variable in the animation parameters 
        StartCoroutine(OpenAfterAnimation());
    }

    private IEnumerator OpenAfterAnimation() {
        // WaitForEndOfFrame pause = new WaitForEndOfFrame();

        // while (doorAnimation.GetCurrentAnimatorStateInfo(0).IsName("2 Tile Door Open")) {
        //     yield return pause;
        //  }
        
        yield return new WaitForSeconds(delay);


        EventController.Instance.BroadcastDoorOpen();
        gameObject.SetActive(false);
    }
}