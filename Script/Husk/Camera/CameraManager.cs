using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

namespace Husk
{
    public class CameraManager : MonoBehaviour
    {
        public event Action<bool, bool> UIChangeEvent;
        public bool startGame;
        public bool isDelaying;
        [SerializeField] CinemachineVirtualCamera InGameCam;
        [SerializeField] CinemachineVirtualCamera TimelineCam;

        private bool tabbed; // Only once can tab
        
        void Awake()
        {
            startGame = false;
            tabbed = false;
            isDelaying = false;
        }

        # region 시작시 스테이지 보고 플레이어가 타임라인 조작하게 하기


        private void Start() 
        {
            if(FindObjectOfType<InGameUI>() == true)
            {
                FindObjectOfType<InGameUI>().TabPressEvent += ChangeCam;
                UIChangeEvent += FindObjectOfType<InGameUI>().UIChange;
            }
            StartCoroutine(StartScene());
        }

        IEnumerator StartScene()
        {
            yield return new WaitForSeconds(2f);

            // camera move
            TimelineCam.gameObject.SetActive(true);
            InGameCam.gameObject.SetActive(false);

            // if(UIChangeEvent != null)
            //     UIChangeEvent(false, true);
            UIChangeEvent?.Invoke(false, true);

            yield return new WaitForSeconds(0.5f);

            // if(UIChangeEvent != null)
            //     UIChangeEvent(false, false);
            UIChangeEvent?.Invoke(false, false);
            
            startGame = true;
            Timer.instance.canTab = true;

        }



        #endregion
        public void ChangeCam()
        {
            if(isDelaying)
                return;
            
            if(Timer.instance.isTimerOn && !tabbed)
            {
                // Pause Game
                Timer.instance.isTimerOn = false;
                tabbed = true;
                isDelaying = true;

                // if(UIChangeEvent != null)
                //     UIChangeEvent(false, true); 
                UIChangeEvent?.Invoke(false, true);

                TimelineCam.gameObject.SetActive(true);
                InGameCam.gameObject.SetActive(false);
                
                
                StartCoroutine(DelayGame(0.5f, false));
            }
            else
            {
                // ReStartGame;
                isDelaying = true;

                // if(UIChangeEvent != null)
                //     UIChangeEvent(false, true);
                UIChangeEvent?.Invoke(false, true);

                InGameCam.gameObject.SetActive(true);
                TimelineCam.gameObject.SetActive(false);

                
                StartCoroutine(DelayGame(0.5f, true));
            }
        }
        IEnumerator DelayGame(float sec, bool isInGame)
        {
            yield return new WaitForSeconds(0.5f);

            // if(UIChangeEvent != null)
            //     UIChangeEvent(isInGame, false);
            UIChangeEvent?.Invoke(isInGame, false);

            yield return new WaitForSeconds(sec);
            Timer.instance.isTimerOn = isInGame;

            yield return new WaitForSeconds(sec);

            isDelaying = false;
        }
    }
}