using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Husk
{
    public class FirstBlockTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("Block"))
            {
                this.transform.parent.GetComponent<TutorialFlow>().firstBlockTrigger = true;
            }
        }
    }
}

