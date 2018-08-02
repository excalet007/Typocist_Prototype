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

    public List<AudioSource> sfxSources;
    public List<AudioClip> sfxClips;

    private void Start()
    {
        AudioSource nAudio = this.gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        sfxSources.Add(nAudio);
        sfxSources[0].clip = sfxClips[0];

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha2)) sfxSources[0].Play();
    }

}
