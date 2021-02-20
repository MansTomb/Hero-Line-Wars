using Mirror;
using UnityEngine;

public class MobSpawner : NetworkBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private UnitsList mobBelongsTo;
    [SerializeField] private UnitsList mobeEnemies;
    
    private Vector3 _SpawnPosition;

    private void Awake()
    {
        _SpawnPosition = transform.position;
    }

    [Command]
    public void SpawnMob(UnitSO mob)
    {
        var obj = Instantiate(mob.prefab, _SpawnPosition, Quaternion.identity);
        var unit = obj.GetComponent<Mob>();

        unit.Init(mobBelongsTo, mobeEnemies, destination);
    }
}
