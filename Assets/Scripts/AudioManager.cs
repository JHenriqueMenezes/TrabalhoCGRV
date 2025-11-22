using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0, 1)] float shootingVolume = 1f;

    [Header("Damage SFX")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0, 1)] float damageVolume = 1f;

    [Header("UI SFX")]
    [SerializeField] AudioClip buttonClickClip;
    [SerializeField] [Range(0, 1)] float buttonClickVolume = 1f;
    [SerializeField] AudioClip buttonHoverClip;
    [SerializeField] [Range(0, 1)] float buttonHoverVolume = 1f;

    public void PlayButtonClickSFX()
    {
        if (buttonClickClip != null)
        {
            PlayAudioClio(buttonClickClip, buttonClickVolume);
        }
    }

    public void PlayButtonHoverSFX()
    {
        if (buttonHoverClip != null)
        {
            PlayAudioClio(buttonHoverClip, buttonHoverVolume);
        }
    }

    public void PlayShootingSFX() 
    {
        if (shootingClip != null)
        {
            PlayAudioClio(shootingClip, shootingVolume);
        }
    }

    public void PlayDamageSFX() 
    {
        if (damageClip != null)
        {
            PlayAudioClio(damageClip, damageVolume);
        }
    }

    public void PlayAudioClio(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
}
