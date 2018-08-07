using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    #region SingleTon
    private static AudioController audioContoller;
    public static AudioController Get_AudioController()
    {
        if (audioContoller == null)
        {
            audioContoller = FindObjectOfType<AudioController>().GetComponent<AudioController>();
            if (audioContoller == null)
            {
                GameObject container = new GameObject();
                container.name = "AudioController";
                audioContoller = container.AddComponent(typeof(AudioController)) as AudioController;
            }
        }
        return audioContoller;
    }
    #endregion

    #region member&method
    //const
    public enum SFX_Code
    {
        Type_t, Type_q, Gun_shot, Gun_shot_heavy, Winchester_reload
    };
    private const float maxVolume = 1f;
    private const float minVolume = 0f; 

    //public member
    public List<AudioClip> bgmClips;
    public List<AudioClip> sfxClips;
    
    //private member
    private AudioSource bgmSource;
    private List<AudioSource> sfxSources;

    //public function
    public void PlayOneShot(SFX_Code input_sfx, float volume)
    {
        if ((int)input_sfx >= 0 && (int)input_sfx < sfxClips.Count)
        {
            bool enough_Container = false;

            foreach (AudioSource sfxSource in sfxSources)
            {                
                if (sfxSource.clip == null || sfxSource.isPlaying == false)
                {
                    enough_Container = true;

                    if (volume < minVolume) volume = minVolume;
                    if (volume > maxVolume) volume = maxVolume;

                    sfxSource.volume = volume;
                    sfxSource.clip = sfxClips[(int)input_sfx];
                    sfxSource.Play();

                    return;
                }
            }

            if (enough_Container == false)
                Debug.LogError("You need more Space in container");
        }
        else
            Debug.LogError("You have to add more sfx cilps");
    }
    
    //private function

    #endregion

    #region monoBehaviour
    private void Start()
    {
        bgmSource = new AudioSource();
        sfxSources = new List<AudioSource>();

        AudioSource newBgmSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        bgmSource = newBgmSource;

        for(int i = 0; i < 20; i++)
        {
            AudioSource newSfxSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
            sfxSources.Add(newSfxSource);
        }
    }

    private void Update()
    {
    }
    #endregion


}
