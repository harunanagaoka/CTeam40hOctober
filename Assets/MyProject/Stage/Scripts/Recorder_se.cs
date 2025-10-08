using UnityEngine;

public class Recorder_se : MonoBehaviour
{
    [SerializeField] private SEManager seManager;

    // Inspector�Őݒ�\�B���ݒ�Ȃ�Start�Ŋ����3���Z�b�g���܂��i�����ł� whistle ������ɂ��Ă��܂��j
    [SerializeField] private SEManager.SoundEffectName[] recorderSEs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        if (recorderSEs == null || recorderSEs.Length == 0)
        {
            recorderSEs = new SEManager.SoundEffectName[3];
            recorderSEs[0] = SEManager.SoundEffectName.Whistle_1;
            recorderSEs[1] = SEManager.SoundEffectName.Whistle_2;
            recorderSEs[2] = SEManager.SoundEffectName.Whistle_3;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ��g���K�[�̏Փ˔���
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Musical Note"))
        {
            PlayRandomRecorder();
        }
    }

    // �g���K�[������g���Ă���ꍇ�͂�������L���ɂ��Ă�������
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Musical Note"))
        {
            PlayRandomRecorder();
        }
    }

    private void PlayRandomRecorder()
    {
        if (seManager == null || recorderSEs == null || recorderSEs.Length == 0) return;

        int idx = Random.Range(0, recorderSEs.Length);
        seManager.OnPlayOneShot(recorderSEs[idx]);
    }
}
