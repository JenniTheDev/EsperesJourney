using UnityEngine;

public class CollisionSound : MonoBehaviour {

    [SerializeField]
    private AudioSource audioToPlay;

    [SerializeField]
    private AudioClip clip;

    private void OnCollisionEnter2D(Collision2D collision) {
        audioToPlay.clip = clip;

        audioToPlay.Play();
    }

    private void OnCollisionExit2D(Collision2D collision) {
        audioToPlay.Stop();
    }
}