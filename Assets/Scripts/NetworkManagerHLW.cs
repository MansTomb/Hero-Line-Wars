using System;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManagerHLW : NetworkManager
{
    [SerializeField] private int minPlayers = 2;
    [Scene] [SerializeField] private string menuScene = string.Empty;

    [Header("Room")] [SerializeField] private NetworkRoomPlayerLobby roomPlayerPrefab = null;

    public static event Action OnClientConnected;
    public static event Action OnClientDisconnected;
    
    public List<NetworkRoomPlayerLobby> RoomPlayers { get; } = new List<NetworkRoomPlayerLobby>();
    
    public static event Action<NetworkConnection> OnServerReading;

    public void NotifyPlayersOfReadyState() => RoomPlayers.ForEach(p => p.HandleReadyToStart(IsReadyToStart()));
    private bool IsReadyToStart() => numPlayers >= minPlayers && RoomPlayers.TrueForAll(p => p.IsReady);

    public override void OnStartServer() => spawnPrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs").ToList();
    public override void OnStartClient()
    {
        var spawnablePrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs");

        foreach (var prefab in spawnablePrefabs)
        {
            ClientScene.RegisterPrefab(prefab);
        }
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        OnClientConnected?.Invoke();
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);
        OnClientDisconnected?.Invoke();
    }

    public override void OnServerConnect(NetworkConnection conn)
    {
        base.OnServerConnect(conn);
        if (numPlayers >= maxConnections || SceneManager.GetActiveScene().path != menuScene)
        {
            conn.Disconnect();
        }
    }

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        if (SceneManager.GetActiveScene().path == menuScene)
        {
            bool isLeader = RoomPlayers.Count == 0;
            NetworkRoomPlayerLobby roomPlayerInstance = Instantiate(roomPlayerPrefab);

            roomPlayerInstance.IsLeader = isLeader;
            
            NetworkServer.AddPlayerForConnection(conn, roomPlayerInstance.gameObject);
        }
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        if (conn.identity != null)
        {
            var player = conn.identity.GetComponent<NetworkRoomPlayerLobby>();
            RoomPlayers.Remove(player);
            
        }
        base.OnServerDisconnect(conn);
    }

    public override void OnStopServer() => RoomPlayers.Clear();

    public override void OnServerReady(NetworkConnection conn)
    {
        base.OnServerReady(conn);
        
        OnServerReading?.Invoke(conn);
    }
}
