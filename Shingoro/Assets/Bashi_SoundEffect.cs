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

    SpriteRenderer MainSpriteRenderer;

    // publicで宣言し、inspectorで設定可能にする
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
        MochiAttackCount = 0;

        // このobjectのSpriteRendererを取得
        MainSpriteRenderer = transform.root.gameObject.GetComponent<SpriteRenderer>();
        MainSpriteRenderer.sprite = Sprite1;


    }

    private void Update()
    {
        MochiText.text = "" + MochiAttackCount.ToString();

        if (MochiAttackCount > 200){
            MainSpriteRenderer.sprite = Sprite3;
        } else if (MochiAttackCount > 100){
            MainSpriteRenderer.sprite = Sprite2;
        } else {
            MainSpriteRenderer.sprite = Sprite1;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //audioSource.Play();
		AkSoundEngine.PostEvent("hit", gameObject);

        MochiAttackCount++;
    }

    int GetMochiCount()
    {
        return MochiAttackCount;
    }
}
