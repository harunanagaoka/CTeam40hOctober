using UnityEngine;

public class Toriangle_se : MonoBehaviour
{
    [SerializeField] private SEManager seManager;

    // Inspectorで設定可能。未設定ならStartで既定の3つをセットします
    [SerializeField] private SEManager.SoundEffectName[] triangleSEs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        if (triangleSEs == null || triangleSEs.Length == 0)
        {
            triangleSEs = new SEManager.SoundEffectName[3];
            triangleSEs[0] = SEManager.SoundEffectName.Triangle_1;
            triangleSEs[1] = SEManager.SoundEffectName.Triangle_2;
            triangleSEs[2] = SEManager.SoundEffectName.Triangle_3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 衝突（非トリガー）で判定する場合
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Musical Note"))
        {
            PlayRandomTriangle();
        }
    }

    // トリガー判定を使っている場合はこちらも有効にできます
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Musical Note"))
        {
            PlayRandomTriangle();
        }
    }

    private void PlayRandomTriangle()
    {
        if (seManager == null || triangleSEs == null || triangleSEs.Length == 0) return;

        int idx = Random.Range(0, triangleSEs.Length);
        seManager.OnPlayOneShot(triangleSEs[idx]);
    }
}
