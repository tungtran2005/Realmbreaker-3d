using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class RoomRadar : TungMonoBehaviour
{
    [SerializeField] protected PlayerCtrl target;
    [SerializeField] protected BoxCollider boxCollider;
    [SerializeField] protected Rigidbody rb;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider();
        this.LoadRigidbody();
    }
    protected virtual void LoadBoxCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider>();
        this.boxCollider.size = new Vector3(22, 2, 22);
        this.boxCollider.center = new Vector3(0, 1.5f, 0);
        this.boxCollider.isTrigger = true;
        Debug.Log(transform.name + " : LoadBoxCollider", gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if(this.rb != null) return;
        this.rb = GetComponent<Rigidbody>();
        this.rb.useGravity = false;
        Debug.Log(transform.name + " : LoadRigidbody", gameObject);
    }
    

}
