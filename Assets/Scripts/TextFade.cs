using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextFade : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    bool flag = false;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(7f);
        flag = true;
    }

    void Update()
    {
        if (flag)
            tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, tmp.color.a - 0.03f);
    }
}
