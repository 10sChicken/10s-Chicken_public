using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Husk
{
    public class AnimalCircleMove : MonoBehaviour
    {
        [Header("움직임 상태 변수")]
        [SerializeField] Transform circleCenter;
        [SerializeField] bool pauseOnTimer;
        public float radius;
        public float speed;
        float posX, posY, angle;
        public float ellipseX;
        public float ellipseY;
        [Header("상태")]
        public bool isMoving;
        public float idleTime;
        [SerializeField] float timerTime;
        [SerializeField] bool isCW = true;
        Animator anim;
        SpriteRenderer sr;
        void Start()
        {
            anim = GetComponent<Animator>();
            sr = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            anim.SetBool("isMoving", isMoving);

            // 탭 상태에서 움직이지 않는 동물이라면
            if(pauseOnTimer)
                if(!Timer.instance.isTimerOn)
                    return;

            if(isMoving)
            {
                sr.flipX = isCW;
                CrowMovement();
            }
            else 
            {
                timerTime -= Time.deltaTime;
                if(timerTime < 0)
                {
                    isMoving = true;
                    timerTime = idleTime;
                }
            }
        }

        void CrowMovement()
        {
            posX = (isCW) ? 
                (circleCenter.position.x + ellipseX * Mathf.Cos(angle) * radius) 
                :   (circleCenter.position.x - ellipseX * Mathf.Cos(angle) * radius);
            posY = circleCenter.position.y - ellipseY * Mathf.Sin(angle) * radius;

            this.transform.position = new Vector2(posX, posY);
            angle = angle + Time.deltaTime * speed;

            if(angle >= 3.14f)
            {
                isCW = !isCW;
                isMoving = false;
                angle = 0f;
            }
        }
    }
}
