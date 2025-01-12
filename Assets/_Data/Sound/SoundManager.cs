using System.Collections.Generic;
using UnityEngine;

public class SoundManager : TungSingleton<SoundManager>
{
    [SerializeField] protected SoundSpawnerCtrl ctrl;
    public SoundSpawnerCtrl Ctrl => ctrl;

    [Range(0f, 1f)]
    [SerializeField] protected float volumeSfx = 1f;
    [SerializeField] protected List<SFXCtrl> listSfx;
    private void FixedUpdate()
    {
        this.VolumeSfxUpdating(volumeSfx);
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSoundSpawnerCtrl();
    }
    protected virtual void LoadSoundSpawnerCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponent<SoundSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadSoundSpawnerCtrl", gameObject);
    }
    public virtual SFXCtrl CreateSfx(string soundName, Vector3 position)
    {
        SFXCtrl soundPrefab = (SFXCtrl)this.ctrl.Prefabs.GetByName(soundName);

        SFXCtrl newSound = this.CreateSfx(soundPrefab);
        newSound.transform.position = position;
        newSound.gameObject.SetActive(true);
        return newSound;
    }

    public virtual SFXCtrl CreateSfx(SFXCtrl sfxPrefab)
    {
        SFXCtrl newSound = (SFXCtrl)this.ctrl.Spawner.Spawn(sfxPrefab, Vector3.zero);
        this.AddSfx(newSound);
        return newSound;
    }

    public virtual void AddSfx(SFXCtrl newSound)
    {
        if (this.listSfx.Contains(newSound)) return;
        this.listSfx.Add(newSound);
    }
    public virtual void VolumeSfxUpdating(float volume)
    {
        this.volumeSfx = volume;
        foreach (SFXCtrl sfxCtrl in this.listSfx)
        {
            sfxCtrl.AudioSource.volume = this.volumeSfx;
        }
    }
}
