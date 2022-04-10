using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Husk
{
    public class SecondBlockTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("Block"))
            {
                this.transform.parent.GetComponent<TutorialFlow>().secondBlockTrigger = true;
            }
        }
    }   
}

