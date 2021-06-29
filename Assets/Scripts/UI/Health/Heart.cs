using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float lerpDuration;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.fillAmount = 1;
    }

    public void Init()
    {
        StartCoroutine(InitAnimation(lerpDuration,null));
    }
    
    public void Destroy()
    {
        StartCoroutine(DestroyAnimation(lerpDuration, AfterDestroy));
    }
    private IEnumerator InitAnimation(float duration, UnityAction callback)
    {

        image.fillAmount = 0;
        while (image.fillAmount < 1)
        {
            image.fillAmount = Mathf.MoveTowards(image.fillAmount, 1, duration * Time.deltaTime);
            yield return null;
        }
        image.fillAmount = 1;
        callback?.Invoke();
    }
    private IEnumerator DestroyAnimation(float duration, UnityAction callback)
    {
        image.fillAmount = 1;
        while (image.fillAmount > 0)
        {
            image.fillAmount -= (1 / duration) * Time.deltaTime;
            yield return null;
        }
        image.fillAmount = 0;
        callback?.Invoke();
    }
 
    private void AfterDestroy()
    {
        Destroy(gameObject);
    }
}
