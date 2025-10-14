using UnityEngine;

public class Accordion_se : MonoBehaviour
{
    [SerializeField] private SEManager seManager;

    // Inspectorで設定可能。未設定ならStartで既定の3つをセットします
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

    // 非トリガーの衝突判定
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Musical Note"))
        {
            PlayRandomAccordion();
        }
    }

    // トリガー判定を使っている場合はこちらも有効にしてください
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
