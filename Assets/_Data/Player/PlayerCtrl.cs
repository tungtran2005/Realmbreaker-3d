using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerCtrl : TungMonoBehaviour
{
    [SerializeField] protected PlayerThirdPersonCtrl playerThirdPersonCtrl;
    public PlayerThirdPersonCtrl PlayerThirdPersonCtrl => playerThirdPersonCtrl;

    [SerializeField] protected vThirdPersonCamera vThirdPersonCamera;
    public vThirdPersonCamera VThirdPersonCamera => vThirdPersonCamera;

    [SerializeField] protected CrosshairPointer crosshairPointer;
    public CrosshairPointer CrosshairPointer => crosshairPointer;

    [SerializeField] protected Rig aimingRig;
    public Rig AimingRig => aimingRig;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoaCrosshairPoint();
        this.LoadPlayerThirdPersonCtrl();
        this.LoadVThirdPersonCamera();
        this.LoadAimingRig();
    }
    protected virtual void LoaCrosshairPoint()
    {
        if (this.crosshairPointer != null) return;
        this.crosshairPointer = GetComponentInChildren<CrosshairPointer>();
        Debug.Log(transform.name + " : LoaCrosshairPoint", gameObject);
    }
    protected virtual void LoadPlayerThirdPersonCtrl()
    {
        if (this.playerThirdPersonCtrl != null) return;
        this.playerThirdPersonCtrl = GetComponent<PlayerThirdPersonCtrl>();
        Debug.Log(transform.name + " : LoadPlayerThirdPersonCtrl", gameObject);
    }
    protected virtual void LoadVThirdPersonCamera()
    {
        if (this.vThirdPersonCamera != null) return;
        this.vThirdPersonCamera = transform.parent.GetComponentInChildren<vThirdPersonCamera>();
        Debug.Log(transform.name + " : LoadVThirdPersonCamera", gameObject);
    }
    protected virtual void LoadAimingRig()
    {
        if(this.aimingRig != null) return;
        this.aimingRig = GetComponentInChildren<Rig>();
        Debug.Log(transform.name + " : LoadAimingRig", gameObject);
    }
}
