using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float distanceToFollow;
    
    private UnitsList _UnitsToAttack;
    private Unit _TargetHero;

    public Unit Target => _TargetHero;

    public void Init(UnitsList enemyUnits)
    {
        _UnitsToAttack = enemyUnits;
        _TargetHero = null;
        StartCoroutine(FindClosestEnemyAndAttack());
    }

    private IEnumerator FindClosestEnemyAndAttack()
    {
        while (true) {
            if (_TargetHero == null)
            {
                _TargetHero = _UnitsToAttack.Units.FirstOrDefault(PlayerInAttackRadius);
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

    public bool PlayerInAttackRadius(Unit hero)
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