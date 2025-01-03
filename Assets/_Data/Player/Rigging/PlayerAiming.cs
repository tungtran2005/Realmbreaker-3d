using UnityEngine;

public class PlayerAiming : PlayerAbstract
{
    protected float closeLookDistance = 1.5f;
    protected float farLookDistance = 2.5f;

    private void FixedUpdate()
    {
        this.Aiming();
    }

    protected virtual void Aiming()
    {
        if (InputManager.Instance.AttackChecking) this.LookClose();
        else this.LookFar();
    }

    protected virtual void LookClose()
    {
        this.playerCtrl.VThirdPersonCamera.defaultDistance = this.closeLookDistance;
        this.playerCtrl.VThirdPersonCamera.rightOffset = 0.25f;
        this.playerCtrl.VThirdPersonCamera.height = 1.45f;
        CrosshairPointer crosshairPointer = this.playerCtrl.CrosshairPointer;
        this.playerCtrl.PlayerThirdPersonCtrl.RotateToPosition(crosshairPointer.transform.position);
        this.playerCtrl.PlayerThirdPersonCtrl.isSprinting = false;

        this.playerCtrl.AimingRig.weight = 1;
    }

    protected virtual void LookFar()
    {
        this.playerCtrl.VThirdPersonCamera.defaultDistance = this.farLookDistance;
        this.playerCtrl.AimingRig.weight = 0;
    }
}