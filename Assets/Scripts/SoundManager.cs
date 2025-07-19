using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;

    public AudioClip deathSFX;
    public AudioClip buttonSFX;

    public AudioClip jumpSFX;

    public AudioClip coinSFX;

    public AudioClip cherrySFX;
    public AudioClip bananaSFX;

    public AudioClip killSFX;
    public AudioClip winSFX;
    private AudioSource audioPlayer;
    public AudioClip menuMusic;
    public  AudioClip music;
    public bool isPlayingMenu;



    void Awake()
    {
        //makes sure that there's only one sound manager
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        isPlayingMenu = true;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlayDeath()
    {
        audioPlayer.PlayOneShot(deathSFX);

    }

    public void PlayWin()
    {
        audioPlayer.PlayOneShot(winSFX);

    }

    public void PlayKill()
    {
        audioPlayer.PlayOneShot(killSFX);

    }
    
    public void PlayButton()
    {
        audioPlayer.PlayOneShot(buttonSFX);

    }

    public void PlayJump()
    {
        audioPlayer.PlayOneShot(jumpSFX);

    }

    public void PlayCoin()
    {
        audioPlayer.PlayOneShot(coinSFX);
    }

    public void PlayCherry()
    {
        audioPlayer.PlayOneShot(cherrySFX);
    }

    public void PlayBanana()
    {
        audioPlayer.PlayOneShot(bananaSFX);
    }


    public void PlayMusic()
    {
        audioPlayer.clip = music;
        audioPlayer.Play();
    }

    public void StopMusic()
    {
        audioPlayer.Stop();
    }

    public void PlayMenuMusic()
    {
        audioPlayer.clip = menuMusic;
        audioPlayer.Play();
        isPlayingMenu = true;
    }

    public void StopMenuMusic()
    {
        audioPlayer.Stop();
        isPlayingMenu = false;
    }

}

