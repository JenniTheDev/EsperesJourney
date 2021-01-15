//Luis
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {
    public string name = "";
    [Tooltip("Will choices (Answers/Responses) be displayed after the dialogue?")]
    public bool isQuestion;

    [Space]
    [Header("Dialogue")]
        [TextArea(3, 10)]
        public string[] sentences;

    

    [Space]
    //[HideInInspector]
    [Header("Answers/Responses")]
        [Tooltip("Answers list.")]
        [TextArea(3, 10)]
        public string[] answers;
    //[HideInInspector]
        [TextArea(3, 10)]
        public string correctAnswer;
    //[HideInInspector]
        [TextArea(3, 10)]
        public string correctResponse;
    //[HideInInspector]
        [TextArea(3, 10)]
        public string incorrectResponse;


}
