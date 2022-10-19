using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice: MonoBehaviour {
    private AudioSource head;
    private AudioSource tail;
    //public AudioClip sound01, sound02;
    public AudioClip[] pcmDataHeads, pcmDataTails;
    private int nHeads, nTails;

    public float overlapTime = 0.2f;



    void Awake(){
        nHeads = pcmDataHeads.Length;
        nTails = pcmDataTails.Length;
        head = gameObject.AddComponent<AudioSource>();        
        tail = gameObject.AddComponent<AudioSource>();        
    }

    void Start(){
        head = pcmDataHeads[Random.Range(0, pcmDataHeads.Length)].GetData();
        tail = pcmDataHeads[Random.Range(0, pcmDataHeads.Length)].GetData();
    }

    void FadeIn(AudioClip clip)
    {

    }

    void FadeOut(AudioClip clip)
    {

    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            int h = Random.Range(0, nHeads), t = Random.Range(0, nTails);
            head.clip = pcmDataHeads[h];
            tail.clip = pcmDataTails[t];
            
            double clipLength = (head.clip.samples / head.pitch);
            Debug.Log($"head {h} length {clipLength}  p tail {t}");
            head.Play();
            tail.PlayScheduled(AudioSettings.dspTime+clipLength/44100);
        }
    }
}
