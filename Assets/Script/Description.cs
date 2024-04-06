using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Description : MonoBehaviour
{
    public string desc;
    public TextMeshProUGUI descTmp;

    public void ChangeDesc()
    {
        descTmp.text = desc;
    }
}
