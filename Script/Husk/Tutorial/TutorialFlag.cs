using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Husk
{
    public class TutorialFlag : MonoBehaviour
    {
        ChickenMove chickenMove;
        ChickenAnimation chickenAnimation;
        public bool isClear;


        private void Awake() 
        {
            chickenMove = FindObjectOfType<ChickenMove>();
            chickenAnimation = FindObjectOfType<ChickenAnimation>();
        }


        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("Player"))
            {
                Timer.instance.isTimerOn = false;
                chickenMove.canMove = false;
                chickenAnimation.SetTrigger("Victory");
                isClear = true;
            }
        }
    }
}

