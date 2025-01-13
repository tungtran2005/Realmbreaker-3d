using UnityEngine;

public class SliderSFX : SliderAbstract
{
    protected override void OnValueChanged(float value)
    {
        SoundManager.Instance.VolumeSfxUpdating(value);
    }
}
