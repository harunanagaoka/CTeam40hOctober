using UnityEngine;
using static MusicManager;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource m_audioSources;

    [SerializeField]
    private AudioClip[] m_audioClips;

    public enum MusicName
    {
        Title,
        Game,
        End
    }

    public void OnPlay(MusicName musicNum)
    {
        OnStop();
        m_audioSources.clip = m_audioClips[(int)musicNum];
        m_audioSources.loop = true;
        m_audioSources.Play();

    }
    public void OnStop()
    {
        m_audioSources.Stop();
    }

    public void OnplayTitleBGM()
    {
        OnStop();
        m_audioSources.clip = m_audioClips[(int)MusicName.Title];
        m_audioSources.loop = true;
        m_audioSources.Play();
    }
    public void OnplayGameBGM()
    {
        OnStop();
        m_audioSources.clip = m_audioClips[(int)MusicName.Game];
        m_audioSources.loop = true;
        m_audioSources.Play();
    }
    public void OnplayEndBGM()
    {
        OnStop();
        m_audioSources.clip = m_audioClips[(int)MusicName.End];
        m_audioSources.loop = true;
        m_audioSources.Play();
    }
}