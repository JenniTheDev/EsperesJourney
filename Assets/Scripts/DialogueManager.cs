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
    private GameObject CharacterPortraitBG;
    private GameObject CharacterImage;
    private Image Portrait;
    private Image Image;
    private GameObject ContButton;
    private Text ContButtonTxt;
    private bool DialogueHidden = true;

    [SerializeField] private UnityEvent DialogueStart;
    [SerializeField] private UnityEvent DialogueEnd;

    //text cue for interactable object
    private Text InteractableCueTxt;
    //If true, player is inside an interactable's collider
    [Tooltip("If true, player is inside an interactable's collider.")]
    [SerializeField] public bool interactable = false;
    //[HideInInspector]
    [SerializeField] public Dialogue DialogueContainer;

    //initialize in inspector if needed---
    [Tooltip("Answer buttons for choices to make if the dialogue is a question.")]
    private GameObject[] AButtons = new GameObject[3];
    private Text[] AButtonTxt = new Text[3];
    //---------------------------

    private Queue<string> sentences;

    //private bool Typing = false;

    private bool isQuestion;
    private List<string> answers;
    private string correctAnswer;
    private string isCorrect;
    public bool Correct = false;
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

        CharacterPortraitBG = GetChildWithName(DialogueCanvas, "CharacterPortraitBG");
        CharacterImage = GetChildWithName(CharacterPortraitBG, "CharacterImage");
        if (CharacterPortraitBG == null) { Debug.LogError("Character Portrait BG is missing."); }
        else if (CharacterImage == null) { Debug.LogError("Character Portrait Image is missing."); }
        Portrait = CharacterPortraitBG.GetComponent<Image>();
        Image = CharacterImage.GetComponent<Image>();

        ContButton = GetChildWithName(DialogueBox, "ContinueButton");
        if (ContButton == null) { Debug.LogError("ContinueButton gameobject in DialogueBox was not found."); }
        ContButtonTxt = GetChildWithName(ContButton, "Text").GetComponent<Text>();
        if (ContButtonTxt == null) { Debug.LogError("ContinueButtonTxt gameobject in ContinueButton was not found."); }

        InteractableCueTxt = GetChildWithName(DialogueCanvas, "Interactable Cue").GetComponent<Text>();
        if (InteractableCueTxt == null) { Debug.LogError("InteractableCue gameobject in DialogueBox was not found."); }


        for (int i = 0; i < 3; i++)
        {
            AButtons[i] = GetChildWithName(DialogueCanvas, "Answer" + (i + 1).ToString());
            AButtonTxt[i] = GetChildWithName(AButtons[i], "Text").GetComponent<Text>();
            if (AButtonTxt[i] == null) { Debug.LogError("gameobject in AnswerButton was not found."); }
            if (AButtons[i] == null) { Debug.LogError("AnswerButton was not found."); }
        }

        //hide dialogue pop up
        HidePopUp();
        //hide answer buttons
        HideAButtons();
    }
    
    //Dialogue event functions -----
    public void DialogueEndEvent()
    {
        DialogueEnd.Invoke();
    }

    public void DialogueStartEvent()
    {
        DialogueStart.Invoke();
    }

    //--------------------------------

    //called when interact event is triggered 
    public void ETriggerDialogue()
    {   //if the player entered an active interactable gameobject's collider, and dialogue container is not empty, start dialogue.
        if (interactable && (DialogueContainer != null))
        {
            DialogueStartEvent();
            StartDialogue(DialogueContainer);
        }
        
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        DialogueStartEvent();
        StartDialogue(dialogue);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversations with " + dialogue.name + ".");
        sentences.Clear();
        answers.Clear();
        Correct = false;
        UnhidePopUp();

        //load character portrait
        Image.sprite = dialogue.portrait;

        isQuestion = dialogue.isQuestion;

        //Load sentences and answers
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        if (isQuestion)
        {
            Debug.Log("Answers---- answerslength is " + dialogue.answers.Length);
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

    public void DisplayNextSentence()
    {
        //if question was answered correctly, end the dialogue
        if (Correct) { 
            EndDialogue();
            return;
        }

        /*Display choices if sentence queue is empty and the dialogue is a question.
        If not a question, end dialogue once queue is empty.*/
        if (isQuestion)
        {
            if (sentences.Count == 0)
            {
                DisplayChoices();
                return;
            }
        }
        else
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));      
    }

    public void EndDialogue()
    {
        Debug.Log("End of dialogue.");
        HidePopUp();
        HideAButtons();
        DialogueEndEvent();
    }

    //Types the dialogue into the pop up box character by character.
    IEnumerator TypeSentence (string sentence)
    {
        DialogueTxt.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            DialogueTxt.text += letter;
            yield return new WaitForSeconds(0.025f); ;

        }
    }

    public static GameObject GetChildWithName(GameObject obj, string name)
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

    #region QuestionMethods
    public void DisplayChoices()
    {
        HidePopUp();
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
        HideAButtons();
        UnhidePopUp();

        if (chosen.text == correctAnswer)
        {
            StopAllCoroutines();
            StartCoroutine(TypeSentence(isCorrect));
            Correct = true;
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(TypeSentence(isIncorrect));
            Correct = false;
        }
    }

    #endregion

    #region Hide&UnhideMethods
    private void HidePopUp()
    {
        //Debug.Log("Hide pop up dialogue box.");
        CharacterPortraitBG.SetActive(false);
        DialogueBox.SetActive(false);
        DialogueHidden = true;
    }

    private void UnhidePopUp()
    {
        //Debug.Log("Unhide pop up dialogue box.");
        CharacterPortraitBG.SetActive(true);
        DialogueBox.SetActive(true);
        InteractableCueTxt.enabled = false;
        DialogueHidden = false;
    }

    private void HideAButtons()
    {
        //Debug.Log("Hide answer buttons.");
        foreach (GameObject button in AButtons)
        {
            button.SetActive(false);
            button.GetComponent<Button>().interactable = false;
        }

        foreach (Text buttonTxt in AButtonTxt)
        {
            buttonTxt.GetComponent<Text>().enabled = false;
        }
        DialogueHidden = true;
    }

    private void UnhideAButtons()
    {
        //Debug.Log("Unhide answer buttons");
        foreach (GameObject button in AButtons)
        {
            button.SetActive(true);
            button.GetComponent<Button>().interactable = true;
        }

        foreach (Text buttonTxt in AButtonTxt)
        {
            buttonTxt.GetComponent<Text>().enabled = true;
        }
        DialogueHidden = false;
    }
    #endregion

    void Update()
    {
        if (interactable && DialogueHidden)
        { InteractableCueTxt.enabled = true;} 
        else { InteractableCueTxt.enabled = false;}
    }
}