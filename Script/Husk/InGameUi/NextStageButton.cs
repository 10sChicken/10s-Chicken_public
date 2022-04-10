using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace Husk
{
    public class NextStageButton : MonoBehaviour
    {
        Sequence popupAnimation;
        [SerializeField] GameObject ScreenAd;


        private void Awake()
        {
            popupAnimation = DOTween.Sequence()
            .SetAutoKill(false)
            .Append(transform.DOLocalMoveY(-200, 2).From(true))
            .Join(GetComponent<CanvasGroup>().DOFade(1, 1).From(0))
            .Pause();
        }

        private void OnEnable() 
        {
            ScreenAd.SetActive(true);

            popupAnimation.Restart();
        }

        public void NextStageBtn()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void MainMenuBtn()
        {
            SceneManager.LoadScene(0);
        }
    }
}
