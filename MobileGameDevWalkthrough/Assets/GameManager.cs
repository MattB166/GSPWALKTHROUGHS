using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Suns;

    public int singleSunValue;

    public TMP_Text sunText;

    private void Awake()
    {
        Instance = this;
    }

    public void AddSuns(int amount)
    {
        Suns += amount;
        sunText.text = Suns.ToString("00");
    }

    public void RemoveSuns(int amount)
    {
        Suns -= amount;
        sunText.text = Suns.ToString("00");
    }

    public bool SunPriceCheck(int Price)
    {
        return (Suns - Price >= 0); 
    }
}
