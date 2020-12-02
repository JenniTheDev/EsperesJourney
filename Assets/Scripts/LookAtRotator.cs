// Digx7
using UnityEngine;

public class LookAtRotator : MonoBehaviour {

    [Header("Main")]
    [SerializeField] private GameObject objectToLookAt;

    [SerializeField] private Vector2 directionOfObject;
    [SerializeField] private Vector3 distanceOfObject;

    [Header("Auto Set Up")]
    [SerializeField] private string tagOfGameObjectToLookFor = "Player";

    [SerializeField] private bool lookForGameObjectOnAwake = true;

    // --- Updates ---------------------------
    public void Awake() {
        if (lookForGameObjectOnAwake) findGameObjectWithTag();
    }

    public void FixedUpdate() {
        LookAtObject();
    }

    // --- Main ------------------------------
    public void LookAtObject() {
        // get direction of object
        distanceOfObject = gameObject.transform.position - objectToLookAt.transform.position;
        distanceOfObject = Vector3.Normalize(distanceOfObject);
        directionOfObject = distanceOfObject;

        // rotate object
        float angle = Mathf.Atan2(directionOfObject.y, directionOfObject.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public bool isObjectToLookAtSet() {
        if (objectToLookAt == null) return false;
        else return true;
    }

    // --- Get/Find --------------------------
    public GameObject getObjectToLookAt() {
        return objectToLookAt;
    }

    public void findGameObjectWithTag() {
        GameObject[] _object = GameObject.FindGameObjectsWithTag(tagOfGameObjectToLookFor);

        int i = 1;
        if (i == _object.Length) {
            objectToLookAt = _object[0];
        }
    }
}