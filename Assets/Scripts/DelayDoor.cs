using System.Collections;
using UnityEngine;

public class DelayDoor : Door {
    private float delay = 0.5f;

    protected override void OpenDoor() {
        doorAnimation.Play(0);
        StartCoroutine(OpenAfterAnimation());
    }

    private IEnumerator OpenAfterAnimation() {
        WaitForEndOfFrame pause = new WaitForEndOfFrame();

        while (doorAnimation.GetCurrentAnimatorStateInfo(0).IsName("Entry")) {
            yield return pause;
        }

        EventController.Instance.BroadcastDoorOpen();
        gameObject.SetActive(false);
    }
}