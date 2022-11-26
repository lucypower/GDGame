using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer m_audioMixer;
    public TMP_Dropdown m_resDropdown;
    Resolution[] m_resolutions;

    private void Start()
    {
        m_resolutions = Screen.resolutions;
        int currentRes = 0;

        List<string> resOptions = new List<string>();

        for (int i = 0; i < m_resolutions.Length; i++)
        {
            string res = m_resolutions[i].width + " x " + m_resolutions[i].height;
            resOptions.Add(res);

            if (m_resolutions[i].width == Screen.currentResolution.width && m_resolutions[i].height == Screen.currentResolution.height)
            {
                currentRes = i;
            }
        }

        m_resDropdown.ClearOptions();
        m_resDropdown.AddOptions(resOptions);
        m_resDropdown.value = currentRes;
        m_resDropdown.RefreshShownValue();
    }

    public void SetResolution(int index)
    {
        Resolution res = m_resolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        m_audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void SetFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }
}
