using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;


namespace Husk
{
    public class TutorialFlow : MonoBehaviour
    {
        // 농부 등장하는 타임라인
        public PlayableDirector FirstFarmer;
        public GameObject cameraManager;
        public int curState = 0;

        [Header("첫 블럭 옮기기")]
        public bool firstBlockTrigger;
        public GameObject firstInfo;

        [Header("두 번째 블럭 옮기기")]
        public bool secondBlockTrigger;
        public GameObject secondInfo;

        [Header("깃발 도착")]
        public TutorialFlag flag;
        public GameObject lastInfo;
        /*
            <curstate>
            0 : 처음 농부 등장, 닭 찾다가 멀리 떠나고 닭 등장
            1 : 타임라인 옮기고 탭 누르면 성공
                - 0이 자동으로 끝나고 이후 
            2 : 닭이 이동 후 멈추면 바로 change 캠 후 안내
            3 : 닭이 도착하면 이렇게 하는 게임이다 하고 마무리
        */

        private void Start() 
        {
            curState = 0;
        }

        private void Update() 
        {
            switch(curState)
            {
                case 0:
                    if(FirstFarmer.state != PlayState.Playing)
                    {
                        curState = 1;
                        cameraManager.SetActive(true);
                    }
                break;

                case 1:
                    if(firstBlockTrigger)
                        curState = 2;
                break;

                case 2:
                    if(flag.isClear)
                        curState = 3;
                break;

                case 3:
                    lastInfo.SetActive(true);
                break;
            }
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("Player"))
            {
                curState = 2;
                firstInfo.SetActive(false);
                secondInfo.SetActive(true);
                cameraManager.GetComponent<CameraManager>().ChangeCam();
            }
        }

        public void MainBtn()
        {
            SceneManager.LoadScene(0);
        }
    }
}

