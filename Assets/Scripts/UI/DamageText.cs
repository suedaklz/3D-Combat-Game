using System.Collections;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    TMP_Text damage;
    public float fadeDuration = 2f;
    public float speed = 2f;

    private void Start()
    {
        damage = this.GetComponent<TMP_Text>();
        StartCoroutine(Fade());
    }

    public IEnumerator Fade()
    {
        float fadeSpeed = 1f/fadeDuration;
        Color textColor = damage.color;

        for(float t = 0.0f; t<1.0f;  t+=Time.deltaTime * fadeSpeed)
        {
            textColor.a = Mathf.Lerp(1, 0, t);
            damage.color = textColor;
            yield return true;
        }

        Destroy(this.gameObject);
    }

    private void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
