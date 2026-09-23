using UnityEngine;
using System.Collections.Generic;

public class VFXManager : MonoBehaviour
{
    public static VFXManager Instance { get; private set; }

    [System.Serializable]
    public struct VFXEntry
    {
        public string id;
        public ParticleSystem prefab;
        public float destroyDelay;
    }

    [SerializeField] List<VFXEntry> vfxLibrary;
    Dictionary<string, VFXEntry> lookup;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        lookup = new Dictionary<string, VFXEntry>();
        foreach (var entry in vfxLibrary)
        {
            lookup[entry.id] = entry;
        }
    }

    public void PlayVFX(string id, Vector3 position, Quaternion rotation = default)
    {
        if (!lookup.TryGetValue(id, out VFXEntry entry) || entry.prefab == null)
        {
            Debug.LogWarning($"this one doesnt exist man");
            return;
        }

        ParticleSystem instance = Instantiate(entry.prefab, position, rotation);
        float delay = entry.destroyDelay > 0 ? entry.destroyDelay : instance.main.duration;
        Destroy(instance.gameObject, delay);
    }
}