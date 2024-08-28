using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class BoostScripts : MonoBehaviour
{
    [SerializeField] SpeedSO speedData;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ScaleBoost"))
            StartCoroutine(ScaleBoost());
        if (collision.gameObject.CompareTag("SlowBoost"))
            StartCoroutine(SlowBoost());
        if (collision.gameObject.CompareTag("DangerBoost"))
            StartCoroutine(DangerBoost());
        if (collision.gameObject.CompareTag("SpeedBoost"))
            StartCoroutine(SpeedBoost());
    }  

    IEnumerator ScaleBoost()
    {
        float duration = 5f;
        float timer = 0f;

        this.transform.DOScale(new Vector3(0.5f, 0.5f, 0), 0.5f);
        while (timer < duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        this.transform.DOScale(new Vector3(1, 1, 0), 0.5f); 
    }

    IEnumerator SlowBoost()
    {
        float duration = 5f;
        float timer = 0f;

        speedData.speed = 40f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        speedData.speed = 80f;
    }

    IEnumerator DangerBoost()
    {
        float duration = 5f;
        float timer = 0f;

        speedData.speed = 120f;
        this.transform.DOScale(new Vector3(2, 2, 0), 0.5f);
        while (timer < duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        speedData.speed = 80f;
        this.transform.DOScale(new Vector3(1,1,0),0.5f);
    }

    IEnumerator SpeedBoost()
    {
        float duration = 5f;
        float timer = 0f;

        speedData.speed = 150f;
        while(timer < duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        speedData.speed = 80f;
    }

}
