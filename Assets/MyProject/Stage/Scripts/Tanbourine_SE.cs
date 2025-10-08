using UnityEngine;

public class Tanbourine_SE : MonoBehaviour
{
    [SerializeField] private SEManager seManager;

    // Inspectorで設定可能。未設定ならStartで既定の3つをセットします
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

    // 衝突（非トリガー）で判定する場合
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
