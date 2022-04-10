using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingUI : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    private void Start()
    {
        float savedVolume = Husk.SaveData.instance.playerData.soundVolume;
        
        GetComponent<Slider>().value = savedVolume;
        mixer.SetFloat("SoundMixer", Mathf.Log10(savedVolume) * 20);
    }
    public void SetVolume(float volume)
    {
        mixer.SetFloat("SoundMixer", Mathf.Log10(volume) * 20);
        Husk.SaveData.instance.playerData.soundVolume = volume;
    }
}
