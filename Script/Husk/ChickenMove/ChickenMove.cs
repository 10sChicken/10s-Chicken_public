using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Husk
{
    public class ChickenMove : MonoBehaviour
    {
        public event Action<AudioClip> JumpSound;
        private Rigidbody2D rigid;
        private ChickenAnimation anim;
        private SpriteRenderer sr;

        [Header("Player State")]
        public bool moveRight;
        public bool moveLeft;
        [SerializeField] private int moveAmount;
        [SerializeField] private bool jump;
        public float jumpForce;
        public float walkSpeed;
        public bool canMove;
        private bool shouldRestart;
        private bool gravityReverse;
        private Vector3 speedBeforeStop;


        [Header("Collision")]
        public bool onGround;
        [SerializeField] private Vector2 bottomOffset;   // 0 -0.24
        [SerializeField] private float collisionRadius;   // 0.36
        public LayerMask groundLayer;

        [Header("Effect")]
        [SerializeField] AudioClip jumpClip;


        private void Start()
        {
            // set bool
            moveLeft = false;
            moveRight = false;
            canMove = true;


            rigid = GetComponent<Rigidbody2D>();
            anim = GetComponent<ChickenAnimation>();
            sr = GetComponent<SpriteRenderer>();

            if (FindObjectOfType<SoundManager>() == true)
                JumpSound += FindObjectOfType<SoundManager>().SFXPlay;
        }


        private void Update()
        {
            canMove = Timer.instance.isTimerOn;
            onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
            // if (Input.GetKeyDown(KeyCode.R))
            // {
            //     PlayerDead();
            // }

            if (!canMove)
            {
                shouldRestart = true;
                PlayerIsStop();
                return;
            }

            if (shouldRestart)
            {
                shouldRestart = false;
                PlayerisMoving();
            }

            // Horizontal Move
            moveRight = moveAmount > 0;
            moveLeft = moveAmount < 0;
            MoveH(moveAmount);

            if(jump)
            {
                jump = false;
                Jump();
            }

            if(gravityReverse)
            {
                gravityReverse = false;
                GravityReverse();
            }
        }


        #region  PlayerMove

        private void MoveH(int dir)
        {
            sr.flipX = !(dir >= 0);
            transform.Translate(Vector3.right * dir * Time.deltaTime * walkSpeed);
        }

        public void MoveAmountInc()
        {
            moveAmount++;
        }

        public void MoveAmountDec()
        {
            moveAmount--;
        }

        public void SetJump(bool input)
        {
            jump = input;
        }

        private void Jump()
        {
            // if (JumpSound != null && Timer.instance.isTimerOn)
            //     JumpSound(jumpClip);
            if(Timer.instance.isTimerOn)
                JumpSound?.Invoke(jumpClip);

            anim.SetTrigger("Jump");
            rigid.AddForce(new Vector2(0, jumpForce * rigid.gravityScale), ForceMode2D.Impulse);
        }

        private void PlayerIsStop()
        {
            speedBeforeStop = rigid.velocity;
            rigid.velocity = Vector3.zero;
            rigid.isKinematic = true;
        }

        private void PlayerisMoving()
        {
            rigid.isKinematic = false;
            rigid.velocity = speedBeforeStop;
        }

        public void SetGravity(bool reverseActive)
        {
            gravityReverse = reverseActive;
        }
        private void GravityReverse()
        {
            rigid.gravityScale *= -1;
            sr.flipY = !sr.flipY;
            sr.flipX = !sr.flipX;
        }

        public void Invincible(bool isActive)
        {
            if(isActive)
            {
                // layer change
                this.gameObject.layer = 13;
                // Invincible animation
                anim.SetBool("Invincible", isActive);
            }
            else 
            {
                this.gameObject.layer = 0;
                anim.SetBool("Invincible", false);
            }
        }

        #endregion

        #region  PlayerDead
        public void PlayerDead()
        {
            SaveData.instance.playerData.playerDeadCount++;
            SaveData.instance.SaveGame();

            Timer.instance.isTimerOn = false;
            canMove = false;
            this.gameObject.layer = 13;
            if (!Timer.instance.gameOver)
                StartCoroutine("PlayerDeadCourtine");

        }
        IEnumerator PlayerDeadCourtine()
        {
            if (FindObjectOfType<SoundManager>() == true)
                JumpSound -= FindObjectOfType<SoundManager>().SFXPlay;
            Timer.instance.gameOver = true;

            anim.SetTrigger("DeadTrigger");
            anim.SetBool("Dead", true);

            yield return new WaitForSeconds(2f);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        #endregion


        private void OnTriggerEnter2D(Collider2D other)
        {
            // 혹시 태그 여러개 될시 Switch로 변경
            if (other.CompareTag("Enemy"))
            {
                PlayerDead();
            }

            if (other.CompareTag("Goal"))
            {
                StartCoroutine(StageClear());
            }
        }


        #region StageClear

        IEnumerator StageClear()
        {
            // TODO : Update Save Data
            // FindObjectOfType<SaveData>().StageClearSave(SceneManager.GetActiveScene().buildIndex);

            Timer.instance.isTimerOn = false;
            Timer.instance.isCleared = true;

            canMove = false;
            anim.SetTrigger("Victory");

            SaveData.instance.playerData.stagesCleared[SceneManager.GetActiveScene().buildIndex] = true;
            SaveData.instance.SaveGame();

            yield return new WaitForSeconds(1f);

            FindObjectOfType<InGameUI>().StageClearPanelActive();
        }

        #endregion
    }
}

