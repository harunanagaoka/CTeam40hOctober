using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator anim;
    private float m_playerMove;

    private void Awake()
    {
        // Animator���擾�i����GameObject�ɃA�^�b�`����Ă���O��j
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("Animator��������܂���BPlayerAnimationController�Ɠ����I�u�W�F�N�g��Animator��ǉ����Ă��������B");
        }
    }

    // �VInput System�p�̈ړ����̓C�x���g
    private void OnMove(InputValue value)
    {
        Vector2 axis = value.Get<Vector2>();
        m_playerMove = axis.x;

        if (Mathf.Abs(axis.x) > 0.01f)
        {
            // �ړ���
            anim.SetInteger("PlayerController", 1);
        }
        else
        {
            // ��~���i�A�C�h���j
            anim.SetInteger("PlayerController", 0);
        }
    }

    // �g���K�[�Փˁi�����j
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Musical Note"))
        {
            // �����A�j���[�V������
            anim.SetInteger("PlayerController", 2);
        }
    }
}

