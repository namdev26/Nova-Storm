using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : NamMonoBehaviour
{
    [SerializeField] protected SpawnerController spawnerController;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 5f;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
    }

    protected virtual void LoadController()
    {
        if (this.spawnerController != null) return;
        this.spawnerController = GetComponent<SpawnerController>();
        Debug.Log(transform.name + ": LoadController", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;
        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;

        Transform ranPoint = this.spawnerController.SpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = this.transform.rotation;

        Transform prefab = this.spawnerController.Spawner.RandomPrefab();
        Transform obj = this.spawnerController.Spawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
        //Invoke(nameof(this.JunkSpawning), 1f);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.spawnerController.Spawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }

}
