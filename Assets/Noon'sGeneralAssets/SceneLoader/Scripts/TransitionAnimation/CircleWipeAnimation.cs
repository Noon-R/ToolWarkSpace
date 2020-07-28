using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Noon.TransitionAnimator {

    public class CircleWipeAnimation : ATransitionAnimation {

        [SerializeField] private float m_maxRadius = 2.0f ;

        private Material m_circleWipeMaterial;
        private bool runAnimation = false;

        private void Awake() {
            m_circleWipeMaterial = gameObject.GetComponent<Image>().material;
        }


        public override bool StartAnimation(float duration, bool isInverse, System.Action onComplete) {
            if (runAnimation) return false;
            gameObject.SetActive(true);
            StartCoroutine(WipeAnimation(duration, isInverse, onComplete));
            return true;

        }

        public override bool SetProgress(float progress) {
            if (runAnimation) return false;

            return SetAnimationProgress(progress);

        }

        private bool SetAnimationProgress(float progress) {
            progress = Mathf.Clamp01(progress);

            float radius = Mathf.Lerp(0, m_maxRadius, progress);
            m_circleWipeMaterial.SetFloat("_Radius", radius);

            if (progress >= 1 || progress <= 0) {
                return true;
            } else {
                return false;
            }
        }

        IEnumerator WipeAnimation(float duration, bool isInverse, System.Action onComplete) {

            float startValue = 1;
            float endValue = 0;
            float currentValue ;
            float sign = -1;


            if (isInverse) {
                startValue = 0;
                endValue = 1;
                sign *= -1;
            } else {
                startValue = 1;
                endValue = 0;
            }
            currentValue = startValue;

            runAnimation = true;
            SetAnimationProgress(startValue);

            do {
                float stepValue = Time.deltaTime / duration;
                currentValue += stepValue*sign;

                yield return new WaitForEndOfFrame();

            } while (!SetAnimationProgress(currentValue));

            SetAnimationProgress(endValue);


            yield return new WaitForEndOfFrame();

            if (isInverse) {
                gameObject.SetActive(false);
            }

            onComplete();
            runAnimation = false;
        }

    }
}
