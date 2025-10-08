using UnityEngine;

public class Cymbal_se : MonoBehaviour
{
    [SerializeField] private SEManager seManager;

    // Inspectorで設定可能。未設定ならStartで既定の3つをセットします
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

    // 非トリガーの衝突判定
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Musical Note"))
        {
            PlayRandomCymbal();
        }
    }

    // トリガー判定を使っている場合はこちらも有効にしてください
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
