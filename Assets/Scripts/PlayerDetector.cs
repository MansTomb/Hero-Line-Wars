using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float distanceToFollow;
    [SerializeField] private List<Hero> players;
    
    private Hero _TargetHero;

    public Hero Target => _TargetHero;

    public void Awake()
    {
        _TargetHero = null;
        StartCoroutine(FindClosestEnemyAndAttack());
    }

    private IEnumerator FindClosestEnemyAndAttack()
    {
        while (true) {
            if (_TargetHero == null)
            {
                _TargetHero = players.FirstOrDefault(PlayerInAttackRadius);
            }
            else
            {
                if (PlayerInAttackRadius(_TargetHero) == false)
                {
                    _TargetHero = null;
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public bool PlayerInAttackRadius(Hero hero)
    {
        NavMeshPath path = new NavMeshPath();
        float distanceToPlayer = float.MaxValue;
        
        if (path.GetPathTo(transform.position, hero.transform.position, -1))
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