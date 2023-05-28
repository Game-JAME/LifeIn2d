using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    PlayerMovement player;
    // Start is called before the first frame update
    [SerializeField] AudioSource audio;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        audio = GetComponent<AudioSource>();
        // remove coin by default after 2 sec
        Destroy(gameObject,2f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // if collided with player
        if(col.CompareTag("Player"))
        {
            player.UpdateCoinCount(1);
            StartCoroutine(PlayAudio());
        }
    }
    IEnumerator PlayAudio()
    {
        audio.Play();
        while (audio.isPlaying)
        {
            yield return null;
        }
        Destroy(gameObject);
    }
}
