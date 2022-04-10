using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Husk
{
    public class ChickenAnimation : MonoBehaviour
    {
        Animator anim;
        ChickenMove chicken;

        private void Start() 
        {
            anim = GetComponent<Animator>();
            chicken = GetComponent<ChickenMove>();
        }


        private void Update() 
        {
            anim.SetBool("OnGround", chicken.onGround);
            anim.SetBool("CanMove", chicken.canMove);

            // walk
            bool isWalking = chicken.moveLeft ^ chicken.moveRight;
            anim.SetBool("Walk", isWalking);
        }

        public void SetTrigger(string trigger)
        {
            anim.SetTrigger(trigger);
        }

        public void SetBool(string animation, bool b)
        {
            anim.SetBool(animation, b);
        }
    }
}

