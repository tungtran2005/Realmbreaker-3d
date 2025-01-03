using UnityEngine;

public abstract class PlayerAbstract : TungMonoBehaviour
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
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name + " LoadPlayerCtr", gameObject);
    }
}
