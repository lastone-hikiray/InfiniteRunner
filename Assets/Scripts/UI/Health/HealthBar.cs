using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HorizontalLayoutGroup))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Heart heartTemplate;

    private List<Heart> hearts = new List<Heart>();


    private void OnEnable()
    {
        player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int currentQuantity)
    {
        int dif = currentQuantity - hearts.Count;
        if(dif > 0)
        {
            for (int i = 0; i < dif; i++)
            {
                CreateHeart();
            }
        }
        else if (dif < 0)
        {
            dif = Math.Abs(dif);
            for (int i = 0; i < dif; i++)
            {
                RemoveHeart();
            }
        }
    }
    private void RemoveHeart()
    {
        Heart heart = hearts[hearts.Count - 1];
        hearts.Remove(heart);
        heart.Destroy();
    }
    private void CreateHeart()
    {
        Heart newHeart = Instantiate(heartTemplate, this.transform);
        hearts.Add(newHeart);
        newHeart.Init();
    }

}
