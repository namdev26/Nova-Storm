using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : NamMonoBehaviour
{
    
    [SerializeField] protected List<Transform> prefabs;

    protected override void LoadComponent()
    {   
        base.LoadComponent();
        this.LoadPrefabs();
    }

    private void LoadPrefabs()
    {   
        if (this.prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }

        this.HidePrefabs();
        Debug.Log(transform.name + ": Loaded prefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {   
        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning(": Prefab not found: " + prefabName, gameObject);
            return null;
        }
        Transform newPrefab = Instantiate(prefab, spawnPos, rotation);
        return newPrefab;
    }

    public virtual Transform GetPrefabByName(string prefabName){
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }
}
