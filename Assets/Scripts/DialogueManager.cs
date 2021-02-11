//Luis
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script handles the dialogue pop up
public class DialogueManager : MonoBehaviour
{
    //initialize in inspector ---
    public GameObject DialogueBox;
    public GameObject Dialogue;
    public Text DialogueTxt;
    public GameObject ContButton;
    public Text ContButtonTxt;
    private bool DialogueHidden = true;

    //text cue for interactable object
    public Text InteractableCueTxt;
    //If true, player is inside an interactable's collider
    public bool interactable = false;
    public Dialogue DialogueContainer;

    public GameObject[] AButtons = new GameObject[3];
    public Text[] AButtonTxt = new Text[3];
    //---------------------------

    private bool isQuestion;
    private Queue<string> sentences;
    private List<string> answers;
    private string correctAnswer;
    private string isCorrect;
    private string isIncorrect;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        answers = new List<string>();

        DialogueTxt = Dialogue.GetComponent<Text>();



        //hide dialogue pop up
        HidePopUp();

        //hide answer buttons
        HideAButtons();

    }

    //called when interact event is triggered 
    public void ETriggerDialogue()
    {   //if the player entered an active interactable gameobject's collider, and dialogue container is not empty, start dialogue.
        if (interactable && (DialogueContainer != null))
        {
            StartDialogue(DialogueContainer);
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversations with " + dialogue.name + ".");
        sentences.Clear();
        //Unhide pop up
        UnhidePopUp();

        isQuestion = dialogue.isQuestion;

        //Load sentences and answers
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        if (isQuestion)
        {
            for (int i = 0; i < dialogue.answers.Length; i++)
            {
                answers.Add(dialogue.answers[i]);
            }
            correctAnswer = dialogue.correctAnswer;
            isCorrect = dialogue.correctResponse;
            isIncorrect = dialogue.incorrectResponse;
        }
        

        DisplayNextSentence();
    }

    public void EndDialogue()
    {
        Debug.Log("End of dialogue.");
        //hide pop up
        HidePopUp();
    }

    public void DisplayNextSentence()
    {
        //if dialogue sentence queue is empty and the answers have not already been displayed (and are supposed to), do it.
        if (sentences.Count == 0 && answers.Count != 0 && isQuestion) 
        {
            EndDialogue();
            DisplayChoices();
            return;
        }
        else if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //DialogueTxt.text = sentence;
        
    }

    //Types the dialogue into the pop up box character by character.
    IEnumerator TypeSentence (string sentence)
    {
        DialogueTxt.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            DialogueTxt.text += letter;
            yield return null;
        }
    }

    public void DisplayChoices()
    {
        //unhide answer buttons
        UnhideAButtons();

        //randomize answers on buttons
        for (int i = 0; i < 3; i++)
        {
            int r = Random.Range(0, answers.Count - 1);
            AButtonTxt[i].text = answers[r];
            answers.RemoveAt(r);
        }
    }

    //OnClick function for answer buttons---
    public void CheckAnswer(Text chosen)
    {
        //hide answer buttons
        HideAButtons();

        //Unhide pop up
        UnhidePopUp();

        if (chosen.text == correctAnswer)
        {
            DialogueTxt.text = isCorrect;
        }
        else
        {
            DialogueTxt.text = isIncorrect;
        }
    }
    #region Hide&UnhideMethods
    private void HidePopUp()
    {
        DialogueHidden = true;
        Debug.Log("Hide pop up dialogue box.");
        DialogueBox.GetComponent<Image>().canvasRenderer.SetAlpha(0f);
        Dialogue.GetComponent<Text>().canvasRenderer.SetAlpha(0f);
        ContButton.GetComponent<Button>().interactable = false;
        ContButton.GetComponent<Image>().canvasRenderer.SetAlpha(0f);
        ContButtonTxt.canvasRenderer.SetAlpha(0f);
    }

    private void UnhidePopUp()
    {
        DialogueHidden = false;
        Debug.Log("Unhide pop up dialogue box.");
        DialogueBox.GetComponent<Image>().canvasRenderer.SetAlpha(127f);
        Dialogue.GetComponent<Text>().canvasRenderer.SetAlpha(255f);
        ContButton.GetComponent<Button>().interactable = true;
        ContButton.GetComponent<Image>().canvasRenderer.SetAlpha(255f);
        ContButtonTxt.canvasRenderer.SetAlpha(255f);
        InteractableCueTxt.enabled = false;
    }

    private void HideAButtons()
    {
        Debug.Log("Hide answer buttons.");
        foreach (GameObject button in AButtons)
        {
            button.GetComponent<Image>().canvasRenderer.SetAlpha(0f);
            button.GetComponent<Button>().interactable = false;
        }

        foreach (Text buttonTxt in AButtonTxt)
        {
            buttonTxt.GetComponent<Text>().canvasRenderer.SetAlpha(0f);
        }
    }

    private void UnhideAButtons()
    {
        Debug.Log("Unhide answer buttons");
        foreach (GameObject button in AButtons)
        {
            button.GetComponent<Image>().canvasRenderer.SetAlpha(127f);
            button.GetComponent<Button>().interactable = true;
        }

        foreach (Text buttonTxt in AButtonTxt)
        {
            buttonTxt.GetComponent<Text>().canvasRenderer.SetAlpha(127f);
        }
    }
    #endregion

    void Update()
    {
        if (interactable && DialogueHidden)
        { InteractableCueTxt.enabled = true;}
        else { InteractableCueTxt.enabled = false; }
    }
}

