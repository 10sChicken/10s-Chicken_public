using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Text;

namespace Husk
{
    
    public class InGameUI : MonoBehaviour
    {
        public event Action TabPressEvent;
        public event Action ResetButtonEvent;
        int langNo;

        [Header("UI Panels")]
        [SerializeField] GameObject stageClearPanel;
        [SerializeField] GameObject inGameUIPanel;
        [SerializeField] GameObject timelineUIPanel;

        [Header("Text")]
        [SerializeField] TextMeshProUGUI inGameTimerText;
        [SerializeField] TextMeshProUGUI stageText;

        [Header("Button")]
        [SerializeField] Button InGameTabBtn;
        string[] timerPrefix = {"시간", "Time"};
        string[] stagePrefix = {"스테이지", "Stage"};
        string[] becomeChickenText = {"치킨은 순살로...", "You became KFC..."};
        private void Start() 
        {
            if(FindObjectOfType<ChickenMove>() == true)
            {
                ResetButtonEvent += FindObjectOfType<ChickenMove>().PlayerDead;
            }

            langNo = SaveData.instance.playerData.langNo;

            int stage = SceneManager.GetActiveScene().buildIndex - 1;

            if(stage + 2 == SceneManager.sceneCountInBuildSettings)
            {
                string text = (langNo == 0) ? "튜토리얼" : "Tutorial";
                stageText.SetText(text);
                return;
            }

            stageText.SetText($"{stagePrefix[langNo].ToString()} {(stage / 10 + 1).ToString()} - {(stage % 10 + 1).ToString()}");
            // stageText.SetText(stagePrefix[langNo] + (stage / 10 + 1) + "-" + (stage % 10 + 1));
        }

        private void Update() 
        {
            if(!Timer.instance.isTimerOn)   return;
            
            if(!Timer.instance.gameOver)
            {   
                inGameTimerText.SetText($"{timerPrefix[langNo]} : {Timer.instance.curTime.ToString("N2")}");
            }
            else
            {
                inGameTimerText.SetText($"becomeChickenText[langNo]");
            }
        }

        public void MainBtn()
        {
            SceneManager.LoadScene(0);
        }


        public void TabBtn(bool isInGame)
        {
            if(!Timer.instance.canTab || Timer.instance.isCleared)
                return;

            // if(TabPressEvent != null)
            // {
            //     TabPressEvent();
            // }
            TabPressEvent?.Invoke();

            if(isInGame)
                InGameTabBtn.interactable = false;
        }

        public void ResetGameBtn()
        {
            // if(ResetButtonEvent != null)
            //     ResetButtonEvent();
            ResetButtonEvent?.Invoke();
        }

        public void StageClearPanelActive()
        {
            stageClearPanel.SetActive(true);
        }

        public void UIChange(bool isInGame, bool isSame)
        {
            inGameUIPanel.SetActive(isInGame);

            if(isSame)
            {
                timelineUIPanel.SetActive(isInGame);
                return;
            }
            timelineUIPanel.SetActive(!isInGame);
        }
    }

}

