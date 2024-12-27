using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : TungMonoBehaviour
{
    //[SerializeField] protected PlayerThirdPersonCtrl playerThirdPersonCtrl;
    //public PlayerThirdPersonCtrl PlayerThirdPersonCtrl => playerThirdPersonCtrl;
    
    [SerializeField] protected CrosshairPointer crosshairPointer;
    public CrosshairPointer CrosshairPointer => crosshairPointer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoaCrosshairPoint();
    }
    protected virtual void LoaCrosshairPoint()
    {
        if (this.crosshairPointer != null) return;
        this.crosshairPointer = GetComponentInChildren<CrosshairPointer>();
        Debug.Log(transform.name + " : LoaCrosshairPoint", gameObject);
    }
}
