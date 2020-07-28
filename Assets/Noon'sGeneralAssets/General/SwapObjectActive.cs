using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapObjectActive : MonoBehaviour
{
    [SerializeField] private bool m_isActive;

    private void Start()
    {
        m_isActive = gameObject.activeSelf;
    }

    public void SwapActivate() {
        gameObject.SetActive(!m_isActive);
        m_isActive = !m_isActive;
    }
}
