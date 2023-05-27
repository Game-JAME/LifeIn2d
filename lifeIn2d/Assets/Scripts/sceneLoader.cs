using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    [SerializeField] Animator animator;
    public float transitionTime = 1f;
    public void LoadLevel(int buildIndex)
    {
        StartCoroutine(load(buildIndex));
    }
    IEnumerator load(int buildIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(buildIndex);
    }
}
