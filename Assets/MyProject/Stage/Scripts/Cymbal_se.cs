using UnityEngine;

public class Cymbal_se : MonoBehaviour
{
    [SerializeField] private SEManager seManager;

    // Inspector�Őݒ�\�B���ݒ�Ȃ�Start�Ŋ����3���Z�b�g���܂�
    [SerializeField] private SEManager.SoundEffectName[] cymbalSEs;

    void Start()
    {

        if (cymbalSEs == null || cymbalSEs.Length == 0)
        {
            cymbalSEs = new SEManager.SoundEffectName[3];
            cymbalSEs[0] = SEManager.SoundEffectName.Cymbal_1;
            cymbalSEs[1] = SEManager.SoundEffectName.Cymbal_2;
            cymbalSEs[2] = SEManager.SoundEffectName.Cymbal_3;
        }
    }

    // ��g���K�[�̏Փ˔���
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Musical Note"))
        {
            PlayRandomCymbal();
        }
    }

    // �g���K�[������g���Ă���ꍇ�͂�������L���ɂ��Ă�������
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Musical Note"))
        {
            PlayRandomCymbal();
        }
    }

    private void PlayRandomCymbal()
    {
        if (seManager == null || cymbalSEs == null || cymbalSEs.Length == 0) return;

        int idx = Random.Range(0, cymbalSEs.Length);
        seManager.OnPlayOneShot(cymbalSEs[idx]);
    }
}
