using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bashi_SoundEffect : MonoBehaviour {

    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    private AudioSource audioSource;

    private int MochiAttackCount;
    public Text MochiText;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
        MochiAttackCount = 0;


    }

    private void Update()
    {
        MochiText.text = "" + MochiAttackCount.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.Play();
        MochiAttackCount++;
    }

}
