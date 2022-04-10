using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderCheck : MonoBehaviour
{
    Rigidbody2D rigid;
    Husk.Timer timer;
    int jumping = 0;

    public event Action<bool> ChickenInvincibleTrigger;
    public event Action<bool> ChickenJumpTrigger;
    public event Action ChickenMoveRight;
    public event Action ChickenMoveLeft;
    public event Action<bool> ChickenGravityReverse;
    public event Action<bool> OnOffTileEvent;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        if (FindObjectOfType<Husk.ChickenMove>() == true)
        {
            Husk.ChickenMove chickenMove = FindObjectOfType<Husk.ChickenMove>();
            ChickenInvincibleTrigger += chickenMove.Invincible;
            ChickenJumpTrigger += chickenMove.SetJump;
            ChickenMoveRight += chickenMove.MoveAmountInc;
            ChickenMoveLeft += chickenMove.MoveAmountDec;
            ChickenGravityReverse += chickenMove.SetGravity;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if(!Husk.Timer.instance.isTimerOn)  return;

        switch(other.gameObject.layer)
        {
            case 9 :
                // if (ChickenMoveRight != null)
                //     ChickenMoveRight();
                ChickenMoveRight?.Invoke();
                break;
            case 10 :
                // if (ChickenMoveLeft != null)
                //     ChickenMoveLeft();
                ChickenMoveLeft?.Invoke();
                break;
            case 11 :
                // if (ChickenJumpTrigger != null)
                //     ChickenJumpTrigger(true);
                ChickenJumpTrigger?.Invoke(true);
                break;
            case 12 :
                // if (ChickenInvincibleTrigger != null)
                //     ChickenInvincibleTrigger(true);
                ChickenInvincibleTrigger?.Invoke(true);
                break;
            case 15 :
                // if (ChickenGravityReverse != null)
                //     ChickenGravityReverse(true);
                ChickenGravityReverse?.Invoke(true);
                break;
            case 16 :
                // if (OnOffTileEvent != null)
                //     OnOffTileEvent(true);
                OnOffTileEvent?.Invoke(true);
                break;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {        
        switch(other.gameObject.layer)
        {
            // case 9 :
            //     if (ChickenMoveRight != null)
            //         ChickenMoveLeft();
            //     break;
            // case 10 :
            //     if (ChickenMoveLeft != null)
            //         ChickenMoveRight();
            //     break;
            // case 11 :
            //     if (ChickenJumpTrigger != null)
            //         ChickenJumpTrigger(false);
            //     break;
            // case 12 :
            //     if (ChickenInvincibleTrigger != null)
            //         ChickenInvincibleTrigger(false);
            //     break;
            // case 15 :
            //     if (ChickenGravityReverse != null)
            //         ChickenGravityReverse(false);
            //     break;
            // case 16 :
            //     if (OnOffTileEvent != null)
            //         OnOffTileEvent(false);
            //     break;
            case 9 :
                ChickenMoveLeft?.Invoke();
                break;
            case 10 :
                ChickenMoveRight?.Invoke();
                break;
            case 11 :
                ChickenJumpTrigger?.Invoke(false);
                break;
            case 12 :
                ChickenInvincibleTrigger?.Invoke(false);
                break;
            case 15 :
                ChickenGravityReverse?.Invoke(false);
                break;
            case 16 :
                OnOffTileEvent?.Invoke(false);
                break;
        }

    }
}
