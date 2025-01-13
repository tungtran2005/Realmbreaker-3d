using UnityEngine;
using UnityEngine.UI;

public abstract class SliderAbstract : TungMonoBehaviour
{
    [SerializeField] protected Slider slider;
    protected override void Start()
    {
        base.Start();
        this.AddEventOnValueChanged();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }
    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
        Debug.Log(transform.name + " : LoadSlider", gameObject);
    }
    protected virtual void AddEventOnValueChanged()
    {
        this.slider.onValueChanged.AddListener(this.OnValueChanged);
    }
    protected abstract void OnValueChanged(float value);
}
