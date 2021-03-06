﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Noon.General;

namespace Noon.AudioManagement{
    public class AudioManager : SingletonMonoBehaviour<AudioManager> {

        private Dictionary<string, AudioClip> m_BGMLib = new Dictionary<string, AudioClip>();
        private Dictionary<string, AudioClip> m_SELib = new Dictionary<string, AudioClip>();

        private AudioClip m_currentBGMClip;

        [SerializeField] private AudioSource m_mainBGMSource;
        [SerializeField] private AudioSource m_SEAudioSource;

        private void Awake(){

            AudioClip[] bgms = Resources.LoadAll<AudioClip>("Music/BGM/");
            AudioClip[] ses =  Resources.LoadAll<AudioClip>("Music/SE/");
            
            foreach (AudioClip clip in bgms) {

                m_BGMLib.Add(clip.name,clip);

            }

            foreach (AudioClip clip in ses) {

                m_SELib.Add(clip.name, clip);

            }

        }

        /// <summary>
        /// BGMは基本１つのみを流す。
        /// 現在かかっているBGMを止めて、新しく流す
        /// 今か流れている物であればそのまま流したままになる(戻り値はtrue)
        /// nameのクリップがないとき、false
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool SwapBGM(string name) {
            AudioClip nextClip = m_BGMLib[name];

            if (nextClip == null) {
                return false;
            }

            if (nextClip == m_currentBGMClip) {
                return true;
            }
            m_currentBGMClip = nextClip;

            m_mainBGMSource.Stop();
            m_mainBGMSource.clip = nextClip;
            m_mainBGMSource.loop = true;
            m_mainBGMSource.Play();

            return true;
        }


        /// <summary>
        /// SEは複数同時再生可
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ShotSE(string name) {
            AudioClip clip = m_SELib[name];

            if (clip == null) return false;

            m_SEAudioSource.PlayOneShot(clip);


            return true;
        }

        /// <summary>
        /// 音を流すかどうかを決めれるtrueの時流す
        /// </summary>
        /// <param name="value"></param>
        public void MusicVolumeSwap(bool value) {
            if (value) {
                m_mainBGMSource.volume = 0.25f;
                m_SEAudioSource.volume = 1;
            } else {
                m_mainBGMSource.volume = 0;
                m_SEAudioSource.volume = 0;
            }
        }

        public void SetBGMVolume(float volume) {
            volume = Mathf.Clamp(volume,0,1);

            m_mainBGMSource.volume = volume;
        }

        public void SetSEVolume(float volume)
        {
            volume = Mathf.Clamp(volume, 0, 1);

            m_SEAudioSource.volume = volume;
        }
    }
}