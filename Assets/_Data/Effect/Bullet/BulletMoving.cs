using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletMoving : MonoBehaviour
{
    [SerializeField] protected float speed = 20f;
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        transform.parent.Translate(Time.fixedDeltaTime * speed * Vector3.forward);
    }
}
