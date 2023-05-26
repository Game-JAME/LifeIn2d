using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBase
    {
        [SerializeField] string input;
        [SerializeField] TextMeshProUGUI textHolder;
        [SerializeField] float delay;
        private void Awake()
        {
            textHolder = GetComponent<TextMeshProUGUI>();

            
        }
        void Start()
        {
            StartCoroutine(writeText(input,textHolder,delay));
        }
    }

}
