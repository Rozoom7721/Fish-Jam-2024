using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownBar : MonoBehaviour
{

    public Transform bar;

    private float fill;
    private bool isCounting;
    private float duration;


    private void Start()
    {
        isCounting = false;
        fill = 0.0f;
        bar.localScale = new Vector3(fill, 1f);
    }

    public CooldownBar startCounting()
    {
        isCounting = true;
        fill = duration;

        return this;
    }

    public CooldownBar stopCounting()
    {
        isCounting = false;
        fill = 0.0f;

        bar.localScale = new Vector3((float)fill / duration, 1f);

        return this;
    }

    public CooldownBar setDuration(float _duration)
    {
        duration = _duration;
        return this;
    }


    private void Update()
    {
        if(isCounting)
        {
            UpdateCooldown();
        }
    }


    public void UpdateCooldown()
    {
        float step = Time.deltaTime;
        fill -= step;



        bar.localScale = new Vector3((float)fill/duration, 1f);

        
    }


}
