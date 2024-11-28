using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Water : MonoBehaviour
{
    Volume volume;
    LensDistortion distortionEffect;
    void Start()
    {
        volume = GetComponent<Volume>();
        if (volume.profile.TryGet(out LensDistortion lensDistortion))
        {
            distortionEffect = lensDistortion;
        }
    }

    void Update()
    {
        FloatParameter ejemplo = new FloatParameter(1 + Mathf.Sin(Time.time) / 2);
        FloatParameter ejemplo2 = new FloatParameter(1 + Mathf.Sin(Time.time) / 2);
        distortionEffect.xMultiplier.SetValue(ejemplo);
        distortionEffect.yMultiplier.SetValue(ejemplo2);
    }
}
