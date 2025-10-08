using UnityEngine;

public class SEManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] m_audioSources;

    [SerializeField]
    private AudioClip[] m_audioClips;

    public enum SoundEffectName
    {
    Player_1,
    Player_2,
    Player_3,
    Triangle_1,
    Triangle_2,
    Triangle_3,
    Whistle_1,
    Whistle_2,
    Whistle_3,
    Tambourine_1,
    Tambourine_2,
    Tambourine_3,
    Cymbal_1,
    Cymbal_2,
    Cymbal_3,
    Accordion_1,
    Accordion_2,
    Accordion_3,
    Cymbal_pfm_,
    Accordion_pfm_1,
    Accordion_pfm_2,

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
