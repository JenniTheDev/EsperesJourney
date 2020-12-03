// Jenni
using UnityEngine;

public class TriggerWithSound : Trigger {

    [SerializeField]
    private AudioSource audioToPlay;

    [SerializeField]
    private AudioClip clip;

    protected override void FireTrigger() {
        base.FireTrigger();
        audioToPlay.clip = clip;
        audioToPlay.Play();
    }
}