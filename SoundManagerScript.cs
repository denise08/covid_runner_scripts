using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound, itemCollectSound, enemyHitSound, levelCompleteSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jump");
        itemCollectSound = Resources.Load<AudioClip>("collectItem");
        enemyHitSound = Resources.Load<AudioClip>("enemyHit");

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip) {
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "collectItem":
                audioSrc.PlayOneShot(itemCollectSound);
                break;
            case "enemyHit":
                audioSrc.PlayOneShot(enemyHitSound);
                break;
        }

    }
}
