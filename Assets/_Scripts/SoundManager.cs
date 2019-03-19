using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public AudioSource efxSource;

    public static AudioClip soldSound;
    [SerializeField] private AudioClip sold;
    public static AudioClip openSound;
    [SerializeField] private AudioClip open;
    public static AudioClip buttonPushSound;
    [SerializeField] private AudioClip buttonPush;
    public static AudioClip incorrectSound;
    [SerializeField] private AudioClip incorrect;
    public static AudioClip angrySound;
    [SerializeField] private AudioClip angry;

    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        // assigning sounds to static audio clips
        soldSound = sold;
        openSound = open;
        buttonPushSound = buttonPush;
        incorrectSound = incorrect;
        angrySound = angry;

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = clip;

        //Play the clip.
        efxSource.Play();
    }
}
