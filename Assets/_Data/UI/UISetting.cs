using UnityEngine;

public class UISetting : TungSingleton<UISetting>
{
    [SerializeField] protected bool isShow = true;
    protected bool IsShow => isShow;

    [SerializeField] protected Transform showHide;
    private void LateUpdate()
    {
        this.HotkeyToggle();
    }
    protected override void Start()
    {
        base.Start();
        this.Hide();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShowHide();
    }
    protected virtual void LoadShowHide()
    {
        if (this.showHide != null) return;
        this.showHide = transform.Find("ShowHide");
        Debug.Log(transform.name + " : LoadShowHide", gameObject);
    }
    public virtual void Hide()
    {
        this.showHide.gameObject.SetActive(false);
        this.isShow = false;
        Time.timeScale = 1f;
    }
    public virtual void Show()
    {
        this.showHide.gameObject.SetActive(true);
        this.isShow = true;
        Time.timeScale = 0;
    }
    public virtual void Toggle()
    {
        if (!this.isShow) this.Show();
        else this.Hide();
    }
    protected virtual void HotkeyToggle()
    {
        if(InputManager.Instance.IsToggleSetting) this.Toggle();
    }
}
