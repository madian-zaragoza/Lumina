using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class Volumen : MonoBehaviour
{
    public AudioMixer audioMixer; // Asignar el Audio Mixer en Unity
    private float musicVolume = 0.5f;
    private float ambientVolume = 0.5f;

    // Referencias a los TextMeshProUGUI para mostrar el volumen
    public TextMeshProUGUI musicVolumeText; // Asignar en el Inspector
    public TextMeshProUGUI ambientVolumeText; // Asignar en el Inspector

    // Métodos para subir/bajar volumen de la música
    public void IncreaseMusicVolume ()
    {
        musicVolume = Mathf.Clamp(musicVolume + 0.1f, 0f, 1f);
        UpdateAudioMixer("Música", musicVolume);
        UpdateMusicVolumeText();
    }

    public void DecreaseMusicVolume ()
    {
        musicVolume = Mathf.Clamp(musicVolume - 0.1f, 0f, 1f);
        UpdateAudioMixer("Música", musicVolume);
        UpdateMusicVolumeText();
    }

    // Métodos para subir/bajar volumen del ambiente
    public void IncreaseAmbientVolume ()
    {
        ambientVolume = Mathf.Clamp(ambientVolume + 0.1f, 0f, 1f);
        UpdateAudioMixer("Ambientación", ambientVolume);
        UpdateAmbientVolumeText();
    }

    public void DecreaseAmbientVolume ()
    {
        ambientVolume = Mathf.Clamp(ambientVolume - 0.1f, 0f, 1f);
        UpdateAudioMixer("Ambientación", ambientVolume);
        UpdateAmbientVolumeText();
    }

    // Método para actualizar el volumen en el Audio Mixer
    private void UpdateAudioMixer (string parameterName, float volume)
    {
        // Si el volumen es 0, lo silencia estableciendo el valor en -80 dB
        if (volume <= 0)
        {
            audioMixer.SetFloat(parameterName, -80f);
        }
        else
        {
            // Si no, lo ajusta según el valor de volumen
            audioMixer.SetFloat(parameterName, Mathf.Log10(volume) * 20);
        }
    }

    // Métodos para actualizar el texto de volumen
    private void UpdateMusicVolumeText ()
    {
        musicVolumeText.text = Mathf.RoundToInt(musicVolume * 100) + "%";
    }

    private void UpdateAmbientVolumeText ()
    {
        ambientVolumeText.text = Mathf.RoundToInt(ambientVolume * 100) + "%";
    }
}
