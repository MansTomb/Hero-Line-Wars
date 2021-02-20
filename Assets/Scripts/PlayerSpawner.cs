using System;
using Mirror;
using UnityEngine;

public class PlayerSpawner : NetworkBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    
    [SerializeField] private UnitsList heroBelongsTo;
    [SerializeField] private UnitsList heroEnemies;
    
    private Vector3 _SpawnPosition;

    private void Awake()
    {
        _SpawnPosition = transform.position;
    }

    public override void OnStartServer() => NetworkManagerHLW.OnServerReading += SpawnHero;
    private void OnDestroy() => NetworkManagerHLW.OnServerReading -= SpawnHero;

    [Server]
    public void SpawnHero(NetworkConnection conn)
    {
        GameObject playerInstance = Instantiate(playerPrefab, _SpawnPosition, Quaternion.identity);
        
        playerInstance.GetComponent<Unit>().Init(heroBelongsTo, heroEnemies);
        Debug.Log("Spawn Hero");
        
        NetworkServer.Spawn(playerInstance, conn);
    }
}
