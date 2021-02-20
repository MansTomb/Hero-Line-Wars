using System;
using Mirror;

public class NetworkManagerHLW : NetworkManager
{
    public static event Action<NetworkConnection> OnServerReading;
    
    public override void OnServerReady(NetworkConnection conn)
    {
        base.OnServerReady(conn);
        
        OnServerReading?.Invoke(conn);
    }
}
