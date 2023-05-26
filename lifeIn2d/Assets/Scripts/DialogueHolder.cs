using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        private void Awake()
        {
            StartCoroutine(DialogueSequence());
        }
        private IEnumerator DialogueSequence()
        {
            for (int i = 0; i < transform.childCount;i++)
            {
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(()=>transform.GetChild(i).GetComponent<DialogueLine>().finished);
            }
            // all dialogue over so go to next scene
        }
        private void Deactivate()
        {
            for (int i = 0; i < transform.childCount;i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    
    }


}
