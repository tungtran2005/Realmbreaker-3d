using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonAbstract : TungMonoBehaviour
{
    [SerializeField] protected Button button;
    protected override void Start()
    {
        base.Start();
        this.AddEventOnClick();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }
    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = GetComponent<Button>();
        Debug.Log(transform.name + " : LoadButton", gameObject);
    }

    protected virtual void AddEventOnClick()
    {
        this.button.onClick.AddListener(this.OnClick);
    }
    protected abstract void OnClick();
}
