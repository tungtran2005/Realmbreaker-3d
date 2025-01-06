using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerCtrl : TungSingleton<PlayerCtrl>
{
    [SerializeField] protected PlayerThirdPersonCtrl playerThirdPersonCtrl;
    public PlayerThirdPersonCtrl PlayerThirdPersonCtrl => playerThirdPersonCtrl;

    [SerializeField] protected vThirdPersonCamera vThirdPersonCamera;
    public vThirdPersonCamera VThirdPersonCamera => vThirdPersonCamera;

    [SerializeField] protected CrosshairPointer crosshairPointer;
    public CrosshairPointer CrosshairPointer => crosshairPointer;

    [SerializeField] protected LevelByExpPlayer level;
    public LevelByExpPlayer Level => level;

    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;

    [SerializeField] protected Rig aimingRig;
    public Rig AimingRig => aimingRig;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoaCrosshairPoint();
        this.LoadPlayerThirdPersonCtrl();
        this.LoadVThirdPersonCamera();
        this.LoadAimingRig();
        this.LoadLevel();
        this.LoadDamageReceiver();
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
    protected virtual void LoadLevel()
    {
        if(this.level != null) return;
        this.level = GetComponentInChildren<LevelByExpPlayer>();
        Debug.Log(transform.name + " : LoadLevel", gameObject);
    }
    protected virtual void LoadDamageReceiver()
    {
        if(this.damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<DamageReceiver>();
        Debug.Log(transform.name + " : LoadDamageReceiver", gameObject);
    }
}
