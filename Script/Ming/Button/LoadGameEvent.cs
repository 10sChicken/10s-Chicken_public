using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class LoadGameEvent : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    void Start()
    {
        mixer.SetFloat("SoundMixer", Mathf.Log10(Husk.SaveData.instance.playerData.soundVolume) * 20);
    }

}
