using UnityEngine;

public class GunShooting : TungMonoBehaviour
{
    [SerializeField] protected FirePoint firePoint;
    [SerializeField] protected string effectName = "Bullet";
    [SerializeField] protected float fireSpeed = 0.2f;
    [SerializeField] protected float timer = 0;
    private void FixedUpdate()
    {
        this.Shooting();
    }
    protected virtual void Shooting()
    {
        if (InputManager.Instance.AttackChecking == false) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.fireSpeed) return;
        this.timer = 0;
        this.SpawnBullet(firePoint);
    }
    protected virtual EffectCtrl SpawnBullet(FirePoint firePoint)
    {
        EffectCtrl prefab = EffectSpawnerCtrl.Instance.Prefabs.GetByName(effectName);
        EffectCtrl newEffect = EffectSpawnerCtrl.Instance.Spawner.Spawn(prefab,firePoint.transform.position,firePoint.transform.rotation);
        newEffect.gameObject.SetActive(true);
        return newEffect;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFirePoint();
    }
    protected virtual void LoadFirePoint()
    {
        if (this.firePoint != null) return;
        this.firePoint = transform.parent.Find("FirePoint").GetComponent<FirePoint>();
        Debug.Log(transform.name + " : LoadFirePoint", gameObject);
    }
}
