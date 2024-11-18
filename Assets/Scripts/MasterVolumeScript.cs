using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MasterVolumeScript : MonoBehaviour
{
    public Slider m_slider;

    public TextMeshProUGUI infoTMP;

    public float m_volume;

    private void Start()
    {
        if(m_slider.value != PlayerPrefs.GetFloat("MasterVolume"))
        {
            m_slider.value = PlayerPrefs.GetFloat("MasterVolume");
        }
    }

    private void Update()
    {
        checkSettings();
    }

    public void onValChange(float value)
    {
        m_volume = value;
        PlayerPrefs.SetFloat("MasterVolume", m_volume);
        m_volume = Mathf.Round(m_volume * 100f) / 100f;

        int percentage = Mathf.RoundToInt(m_volume * 100);
        infoTMP.text = "Volume: " + percentage + "%";
    }

    public void checkSettings()
    {
        if(AudioListener.volume != PlayerPrefs.GetFloat("MasterVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume");
        }
    }
}
