using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{
    public class DialogueBase : MonoBehaviour
    {
        public bool finished {get;private set;}
        protected IEnumerator writeText(string input,TextMeshProUGUI textHolder,float delay)
        {
            for (int i= 0;i<input.Length;i++)
            {
                textHolder.text += input[i];
                yield return new WaitForSeconds(0.05f);
            }
            //yield return new WaitForSeconds(delay);
            yield return new WaitUntil(()=> Input.GetMouseButton(0));
            finished = true;
        }
    
    }

}
