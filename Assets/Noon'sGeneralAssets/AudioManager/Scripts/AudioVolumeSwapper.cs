using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Noon.AudioManagement {
    public class AudioVolumeSwapper : MonoBehaviour {
        static private bool m_currentState = true;

        public void SwapVolume() {
            AudioManager.Instance.MusicVolumeSwap(!m_currentState);
            m_currentState = !m_currentState;
        }

    }
}