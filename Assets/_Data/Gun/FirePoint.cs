using UnityEngine;

public class FirePoint : TungMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GameObject.FindAnyObjectByType<PlayerCtrl>();
        Debug.Log(transform.name + " : LoadPlayerCtrl", gameObject);
    }
    private void Update()
    {
        this.Looking();
    }
    protected virtual void Looking()
    {
        transform.LookAt(this.playerCtrl.CrosshairPointer.transform.position);
    }
}
