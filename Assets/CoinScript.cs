using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public AudioClip soundCoin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        PlaySound(soundCoin);
        StartCoroutine(waitFor());

    }
    IEnumerator waitFor()
    {
        yield return new WaitForSeconds(.25f);
        Destroy(gameObject);
    }
    void PlaySound(AudioClip soundName)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (!audio.isPlaying || audio.clip != soundName)
        {
            audio.clip = soundName;
            audio.Play();
        }
    }
   
  
}
