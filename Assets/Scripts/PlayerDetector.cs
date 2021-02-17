using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float distanceToFollow;
    [SerializeField] private List<Player> players;
    
    private Player _TargetPlayer;

    public Player Target => _TargetPlayer;

    public void Awake()
    {
        _TargetPlayer = null;
        StartCoroutine(FindClosestEnemyAndAttack());
    }

    private IEnumerator FindClosestEnemyAndAttack()
    {
        while (true) {
            if (_TargetPlayer == null)
            {
                _TargetPlayer = players.FirstOrDefault(PlayerInAttackRadius);
            }
            else
            {
                if (PlayerInAttackRadius(_TargetPlayer) == false)
                {
                    _TargetPlayer = null;
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public bool PlayerInAttackRadius(Player player)
    {
        NavMeshPath path = new NavMeshPath();
        float distanceToPlayer = float.MaxValue;
        
        if (path.GetPathTo(transform.position, player.transform.position, -1))
        {
            var pathLength = path.GetPathLength();
            if (pathLength >= 0 && pathLength < distanceToPlayer)
            {
                distanceToPlayer = pathLength;
            }
        }
        return distanceToPlayer < distanceToFollow;
    }
}