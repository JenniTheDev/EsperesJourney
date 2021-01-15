//Luis
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //This script is attached to any interactable gameobject such as an NPC
    public bool active;
    //public BoxCollider2D Dtrigger;
    public Dialogue dialogue;
    
    // Start is called before the first frame update
    void Start()
    {
        //active = true;
        //Dtrigger = gameObject.GetComponent<BoxCollider2D>();
        
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //add E interact action
        if (collision.tag == "Player" && active)
        {
            //freeze player();
            TriggerDialogue();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
