using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Husk
{
    public class CirclePlatform : MonoBehaviour
    {
        [Header("움직임 상태 변수")]
        [SerializeField] Transform circleCenter;
        public float radius;
        public float speed;
        float posX, posY, angle;
        public float ellipseX;
        public float ellipseY;
        [Header("상태")]
        public bool isMoving;
        public float idleTime;
        float timerTime;
        [SerializeField] bool isCW = true;

        void Update()
        {

            if(isMoving)
            {
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

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if(other.transform.CompareTag("Player"))
            {
                other.transform.SetParent(this.transform);
            }
        }

        private void OnCollisionExit2D(Collision2D other) 
        {
            if(other.transform.CompareTag("Player"))
            {
                other.transform.SetParent(null);
            }
        }
    }

}
