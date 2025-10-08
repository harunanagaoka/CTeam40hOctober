using UnityEngine;

public class Recorder_se : MonoBehaviour
{
    [SerializeField] private SEManager seManager;

    // Inspectorで設定可能。未設定ならStartで既定の3つをセットします（ここでは whistle を既定にしています）
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

    // 非トリガーの衝突判定
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Musical Note"))
        {
            PlayRandomRecorder();
        }
    }

    // トリガー判定を使っている場合はこちらも有効にしてください
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
