using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHandler : MonoBehaviour
{
    [SerializeField] GameObject portalTrigger;
    Shard[] shards;
    int totalShards;

    private void Awake()
    {
        shards = FindObjectsOfType<Shard>();
        totalShards = shards.Length;
    }

    public void RemoveShardCount()
    {
        totalShards--;
        if (totalShards == 0)
        {
            portalTrigger.SetActive(true);
        }
    }

    public void OpenPortal()
    {
        FindObjectOfType<Portal>().OpenPortal();
    }
}
