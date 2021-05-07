//Luis
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue {
    public string name = "";
    public Sprite portrait;
    [Tooltip("Will choices (Answers/Responses) be displayed after the dialogue?")]
    public bool isQuestion;

    [Space]
    [Header("Sentence Queue -------")]
        [Tooltip("Sentence Queue.")]
        [TextArea(3, 10)]
        public string[] sentences;

    

    [Space]
    //[HideInInspector]
    [Header("Answers List ----------")]
        [Tooltip("Answers list.")]
        [TextArea(3, 10)]
        public string[] answers;
    //[HideInInspector]
    [Header("Responses ------------")]
    [TextArea(3, 10)]
        public string correctAnswer;
    //[HideInInspector]
        [TextArea(3, 10)]
        public string correctResponse;
    //[HideInInspector]
        [TextArea(3, 10)]
        public string incorrectResponse;


}
