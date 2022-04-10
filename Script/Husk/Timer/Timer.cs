using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Husk
{
    public class Timer : MonoBehaviour
    {
        public static Timer instance;
        public bool isTimerOn;
        public bool isCleared;
        public bool canTab;
        public bool gameOver;
        public float MaxTime;
        public float curTime;
        ChickenMove player;

        private void Awake() 
        {
            instance = this;
            gameOver = false;
            curTime = MaxTime;
            isTimerOn = false;
            canTab = false;

            player = GameObject.FindWithTag("Player").GetComponent<ChickenMove>();
        }

        private void Update() 
        {
            if(gameOver)
                return;
            
            if(isTimerOn)
            {
                curTime -= Time.deltaTime;
                //print(curTime);
            }
            if(curTime <= 0)
            {
                print("죽었죠? 10초 지났죠?");
                isTimerOn = false;
                player.PlayerDead();
            }
        }
    }




}
