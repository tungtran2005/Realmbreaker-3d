using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairPointer : TungMonoBehaviour
{
    [SerializeField] protected float maxDistance = 100f;
    [SerializeField] protected LayerMask layerMask = 1;
    private void Update()
    {
        this.Pointing();
    }
    protected virtual void Pointing()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        if(Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask))
        {
            transform.position = hit.point;
        }
    }
}
