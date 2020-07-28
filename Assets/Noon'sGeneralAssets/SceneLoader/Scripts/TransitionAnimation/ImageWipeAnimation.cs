﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Noon.AudioManagement;

namespace Noon.TransitionAnimator {

    public class ImageWipeAnimation : ATransitionAnimation {

        [SerializeField] private float m_maxScale = 2.0f;
        [SerializeField] private bool m_haveSE = false;
        [SerializeField] private string[] m_SENames = new string[2];

        private Material m_imageWipeMaterial;
        private bool runAnimation = false;

        private void Awake() {
            m_imageWipeMaterial = gameObject.GetComponent<Image>().material;
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

            float scale = Mathf.Lerp(0, m_maxScale, progress);
            m_imageWipeMaterial.SetFloat("_Scale", scale);

            if (progress >= 1 || progress <= 0) {
                return true;
            } else {
                return false;
            }
        }

        IEnumerator WipeAnimation(float duration, bool isInverse, System.Action onComplete) {

            float startValue = 1;
            float endValue = 0;
            float currentValue;

            float stepValue = -Time.deltaTime / duration;

            if (m_haveSE) {
                string name = m_SENames[0];
                if (!isInverse) {
                    name = m_SENames[1];
                }
                AudioManager.Instance.ShotSE(name);
            }

            if (!isInverse) {
                startValue = 0;
                endValue = 1;
                stepValue *= -1;
            } else {
                startValue = 1;
                endValue = 0;
            }
            currentValue = startValue;

            runAnimation = true;
            SetAnimationProgress(startValue);

            do {

                currentValue += stepValue;

                yield return null;

            } while (!SetAnimationProgress(currentValue));

            SetAnimationProgress(endValue);


            yield return null;

            if (isInverse) {
                gameObject.SetActive(false);
            }

            onComplete();
            runAnimation = false;
        }

    }
}
