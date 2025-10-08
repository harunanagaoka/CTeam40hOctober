using UnityEngine;

public class Tanbourine_SE : MonoBehaviour
{
    [SerializeField] private SEManager seManager;

    // Inspector�Őݒ�\�B���ݒ�Ȃ�Start�Ŋ����3���Z�b�g���܂�
    [SerializeField] private SEManager.SoundEffectName[] tambourineSEs;

    void Start()
    {
        if (tambourineSEs == null || tambourineSEs.Length == 0)
        {
            tambourineSEs = new SEManager.SoundEffectName[3];
            tambourineSEs[0] = SEManager.SoundEffectName.Tambourine_1;
            tambourineSEs[1] = SEManager.SoundEffectName.Tambourine_2;
            tambourineSEs[2] = SEManager.SoundEffectName.Tambourine_3;
        }
    }

    // �Փˁi��g���K�[�j�Ŕ��肷��ꍇ
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Musical Note"))
        {
            PlayRandomTambourine();
        }
    }


    private void PlayRandomTambourine()
    {
        if (seManager == null || tambourineSEs == null || tambourineSEs.Length == 0) return;

        int idx = Random.Range(0, tambourineSEs.Length);
        seManager.OnPlayOneShot(tambourineSEs[idx]);
    }
}
