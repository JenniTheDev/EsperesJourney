//Luis
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is attached to any interactable gameobject such as an NPC.
public class DialogueTrigger : MonoBehaviour
{
    public bool active;
    public Dialogue dialogue;
    private DialogueManager DManager;
 
    
    // Start is called before the first frame update
    void Start()
    {
        DManager = FindObjectOfType<DialogueManager>();   
        if(DManager == null) { Debug.LogError("Dialogue Manager was not found in the scene."); }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Player" || collision.transform.gameObject.name == "SensorCube") && active)
        {
            Debug.Log("Player has entered " + dialogue.name + "'s collider.");
            DManager.interactable = true;
            DManager.DialogueContainer = dialogue;
        }
    }

    //public void OnCollisionStay2D(Collider2D collision)
    //{
    //    Debug.Log("Player has entered an interactable object's collider.");
    //    if (collision.tag == "Player" && active)
    //    {
    //        DManager.interactable = true;
    //        DManager.DialogueContainer = dialogue;
    //    }
    //}

    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Player has exited an interactable object's collider.");
        DManager.interactable = false;
        DManager.DialogueContainer = null;
    }
}
