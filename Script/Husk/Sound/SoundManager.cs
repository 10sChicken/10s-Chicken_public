using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace Husk
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource BGsound;
        public AudioClip[] stagesBGsound;
        int curStageBGIndex = -1;
        public GameObject SFXPlayer;

        private void Awake() 
        {
            var obj = FindObjectsOfType<SoundManager>();

            if(obj.Length > 1)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            int curStage = (SceneManager.GetActiveScene().buildIndex-1) / 10 + 1;
            
            if(SceneManager.GetActiveScene().buildIndex == 0)    curStage = 0;

            if(curStageBGIndex == curStage)
                return;
            else 
            {
                BackGroundSoundPlay(stagesBGsound[curStage]);
                curStageBGIndex = curStage;
            }

        }
        void BackGroundSoundPlay(AudioClip inputClip)
        {
            BGsound.clip = inputClip;
            BGsound.loop = true;
            // BGsound.volume = 0.5f;
            BGsound.Play();
        }

        public void SFXPlay(AudioClip clip)
        {   
            AudioSource audioSource = SFXPlayer.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.Play();

            Destroy(SFXPlayer.GetComponent<AudioSource>(), clip.length);
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}