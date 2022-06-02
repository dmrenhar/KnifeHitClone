﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject restartButton;

    [Header("Knife Count Display")]
    [SerializeField]
    private GameObject panelKnives;
    [SerializeField]
    private GameObject iconKnife;
    [SerializeField]
    private Color usedKnifeIconColor;

    public void ShowRestartButton()
    {
        restartButton.SetActive(true); 
    }

    public void SetIntialDisplayedKnideCount(int count)
    {
        for (int i = 0; i < count; i++)
            Instantiate(iconKnife, panelKnives.transform);
    }

    private int knifeIconIndexToChange = 0;
    public void DecrementDisplayedKnideCount()
    {   
        panelKnives.transform.GetChild(knifeIconIndexToChange++)
            .GetComponent<Image>().color = usedKnifeIconColor;
    }
}
