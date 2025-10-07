using UnityEngine;

public class SEManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] m_audioSources;

    [SerializeField]
    private AudioClip[] m_audioClips;

    public enum SoundEffectName
    {
    player_1,
    player_2,
    player_3,
    triangle_1,
    triangle_2,
    triangle_3,
    whistle_1,
    whistle_2,
    whistle_3,
    tambourine_1,
    tambourine_2,
    tambourine_3,
    cymbal_1,
    cymbal_2,
    cymbal_3,
    accordion_1,
    accordion_2,
    accordion_3,
    cymbal_pfm_,
    accordion_pfm_1,
    accordion_pfm_2,

    }
    public void OnPlayOneShot(SoundEffectName seNum)
    {
        m_audioSources[(int)seNum].PlayOneShot(m_audioClips[(int)seNum]);
    }
    public void OnPlay(SoundEffectName seNum)
    {
        m_audioSources[(int)seNum].clip = m_audioClips[(int)seNum];
        m_audioSources[(int)seNum].loop = true;
        m_audioSources[(int)seNum].Play();
    }
    public void OnStop(SoundEffectName seNum)
    {
        m_audioSources[(int)(seNum)].Stop();
    }
}
