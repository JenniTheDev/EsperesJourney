//Luis
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    //initialize in inspector ---
    public GameObject DialogueBox;
    public GameObject Dialogue;
    public Text DialogueTxt;
    public GameObject ContButton;
    public Text ContButtonTxt;

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
        //if dialogue sentence queue is empty and the answers have not already been displayed
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
        DialogueTxt.text = sentence;
        Debug.Log(sentence);
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

    //used for buttons---
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
    }

    private void UnhidePopUp()
    {
        Debug.Log("Unhide pop up dialogue box.");
        DialogueBox.GetComponent<Image>().canvasRenderer.SetAlpha(127f);
        Dialogue.GetComponent<Text>().canvasRenderer.SetAlpha(255f);
        ContButton.GetComponent<Button>().interactable = true;
        ContButton.GetComponent<Image>().canvasRenderer.SetAlpha(255f);
        ContButtonTxt.canvasRenderer.SetAlpha(255f);
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
}
