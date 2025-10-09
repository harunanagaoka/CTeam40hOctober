using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{
    private Animator m_animator;

    [SerializeField]
    private string m_boolParameterName = "isHit";

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        // ������ԂōĐ����Ȃ��悤�ɂ���
        m_animator.SetBool(m_boolParameterName, false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �Փˑ���̃^�O���`�F�b�N
        if (collision.gameObject.CompareTag("Wall") ||
            collision.gameObject.CompareTag("Obstacle") ||
            collision.gameObject.CompareTag("Cymbal"))
        {
            // �A�j���[�V��������x�����Đ�
            StartCoroutine(PlayAnimationOnce());
        }
    }

    private IEnumerator PlayAnimationOnce()
    {
        // ���łɍĐ����Ȃ疳��
        if (m_animator.GetBool(m_boolParameterName))
            yield break;

        // �A�j���[�V�����Đ��J�n
        m_animator.SetBool(m_boolParameterName, true);

        // ���݂̃X�e�[�g�����擾�iTake001�̒����𓾂�j
        yield return null; // 1�t���[���҂i�m���ɃX�e�[�g���؂�ւ��悤�Ɂj
        AnimatorStateInfo stateInfo = m_animator.GetCurrentAnimatorStateInfo(0);

        // �A�j���[�V�����̒��������ҋ@
        yield return new WaitForSeconds(stateInfo.length);

        // �A�j���[�V�����I��
        m_animator.SetBool(m_boolParameterName, false);
    }
}
