//Luis
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//This script handles the dialogue pop up
public class DialogueManager : MonoBehaviour
{
    private GameObject DialogueCanvas;
    private GameObject DialogueBox;
    private GameObject Dialogue;
    private Text DialogueTxt;
    private GameObject ContButton;
    private Text ContButtonTxt;
    private bool DialogueHidden = true;

    [SerializeField] private UnityEvent DialogueEnd;

    //text cue for interactable object
    private Text InteractableCueTxt;
    //If true, player is inside an interactable's collider
    [HideInInspector]
    public bool interactable = false;
    [HideInInspector]
    public Dialogue DialogueContainer;

    //initialize in inspector if needed---
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


        DialogueCanvas = GameObject.Find("Dialogue Canvas");
        if (DialogueCanvas == null) { Debug.LogError("Dialogue canvas was not found."); }

        DialogueBox = GetChildWithName(DialogueCanvas, "DialogueBox");
        if (DialogueBox == null) { Debug.LogError("DialogueBox gameobject in DialogueCanvas was not found."); }

        Dialogue = GetChildWithName(DialogueBox, "Dialogue");
        if (Dialogue == null) { Debug.LogError("Dialogue gameobject in DialogueBox was not found."); }
        DialogueTxt = Dialogue.GetComponent<Text>();

        ContButton = GetChildWithName(DialogueBox, "ContinueButton");
        if (ContButton == null) { Debug.LogError("ContinueButton gameobject in DialogueBox was not found."); }
        ContButtonTxt = GetChildWithName(ContButton, "Text").GetComponent<Text>();
        if (ContButtonTxt == null) { Debug.LogError("ContinueButtonTxt gameobject in ContinueButton was not found."); }

        InteractableCueTxt = GetChildWithName(DialogueCanvas, "Interactable Cue").GetComponent<Text>();
        if (InteractableCueTxt == null) { Debug.LogError("InteractableCue gameobject in DialogueBox was not found."); }

        //hide dialogue pop up
        HidePopUp();

        //hide answer buttons
        HideAButtons();

    }

    public void DialogueEndEvent()
    {
        Debug.Log("hhee hee hoo hoo ");
        DialogueEnd.Invoke();
    }

    //called when interact event is triggered 
    public void ETriggerDialogue()
    {   //if the player entered an active interactable gameobject's collider, and dialogue container is not empty, start dialogue.
        if (interactable && (DialogueContainer != null))
        {
            StartDialogue(DialogueContainer);
        }
        
    }

    public GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
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
        DialogueEndEvent();
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
        Debug.Log("Hide pop up dialogue box.");
        DialogueBox.GetComponent<Image>().canvasRenderer.SetAlpha(0f);
        Dialogue.GetComponent<Text>().canvasRenderer.SetAlpha(0f);
        ContButton.GetComponent<Button>().interactable = false;
        ContButton.GetComponent<Image>().canvasRenderer.SetAlpha(0f);
        ContButtonTxt.canvasRenderer.SetAlpha(0f);
        DialogueHidden = true;
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

