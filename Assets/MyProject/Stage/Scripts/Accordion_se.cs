using UnityEngine;

public class Accordion_se : MonoBehaviour
{
    [SerializeField] private SEManager seManager;

    // Inspector�Őݒ�\�B���ݒ�Ȃ�Start�Ŋ����3���Z�b�g���܂�
    [SerializeField] private SEManager.SoundEffectName[] accordionSEs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject ob = GameObject.Find("SEManager");
        seManager = ob.GetComponent<SEManager>();

        if (accordionSEs == null || accordionSEs.Length == 0)
        {
            accordionSEs = new SEManager.SoundEffectName[3];
            accordionSEs[0] = SEManager.SoundEffectName.Accordion_1;
            accordionSEs[1] = SEManager.SoundEffectName.Accordion_2;
            accordionSEs[2] = SEManager.SoundEffectName.Accordion_3;
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
            PlayRandomAccordion();
        }
    }

    // �g���K�[������g���Ă���ꍇ�͂�������L���ɂ��Ă�������
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Musical Note"))
        {
            PlayRandomAccordion();
        }
    }

    private void PlayRandomAccordion()
    {
        if (seManager == null || accordionSEs == null || accordionSEs.Length == 0) return;

        int idx = Random.Range(0, accordionSEs.Length);
        seManager.OnPlayOneShot(accordionSEs[idx]);
    }
}
