using System;
using System.Collections.Generic;
using UnityEngine;

public class FallCommand : MonoBehaviour
{
    float bottom = -50;
    Transform player;
    Transform voidAnchor;
    [SerializeField] List<Transform> respawnAnchors;

    void Start()
    {
        GameObject _voidAnchor = GameObject.Find("VoidAnchor");
        voidAnchor = _voidAnchor.transform;
        player = GameObject.Find("Player").transform;
        if (_voidAnchor != null) { bottom = voidAnchor.position.y;  Debug.Log("VoidAnchor found"); }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.position.y < bottom)
        {
            Transform nearestRespawnPoint = FindNearestRespawnPoint();
            if (nearestRespawnPoint == null) throw new SystemException();
            else
            {
                player.position = nearestRespawnPoint.position;
            }
        }
    }

    Transform FindNearestRespawnPoint()
    {
        float nearestDistance = 0;
        Transform currentClosest = null;
        foreach (Transform respawnAnchor in respawnAnchors)
        {
            if (currentClosest == null)
            {
                currentClosest = respawnAnchor;
                nearestDistance = Vector2.Distance(currentClosest.position, player.position);
            }
            else
            {    
                float currentDistance = Vector2.Distance(respawnAnchor.position, player.position);
                if (currentDistance < nearestDistance)
                {
                    currentClosest = respawnAnchor;
                }
            }
        }
        return currentClosest;
    }
}
