using Menus;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NetworkRoomPlayerLobby : NetworkBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject lobbyUI = null;
    [SerializeField] private TMP_Text[] playerNameTexts = new TMP_Text[8];
    [SerializeField] private TMP_Text[] playerReadyTexts = new TMP_Text[8];
    [SerializeField] private Button startGameButton = null;

    [SyncVar(hook = nameof(HandleDisplayNameChanged))]
    public string DisplayName = "...";

    [SyncVar(hook = nameof(HandleReadyStatusChanged))]
    public bool IsReady = false;

    private bool _IsLeader;
    public bool IsLeader
    {
        set
        {
            _IsLeader = value;
            startGameButton.gameObject.SetActive(value);
        }
    }

    private NetworkManagerHLW room;

    public NetworkManagerHLW Room
    {
        get
        {
            if (room != null)
                return room;
            return room = NetworkManager.singleton as NetworkManagerHLW;
        }
    }

    public override void OnStartAuthority()
    {
        CmdSetDisplayName(PlayerNameInput.Username);
        
        lobbyUI.SetActive(true);
    }

    public override void OnStartClient()
    {
        Room.RoomPlayers.Add(this);

        UpdateDisplay();
    }

    public override void OnStopClient()
    {
        Room.RoomPlayers.Remove(this);

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (!hasAuthority)
        {
            foreach (var player in Room.RoomPlayers)
            {
                if (player.hasAuthority)
                {
                    player.UpdateDisplay();
                    break;
                }
            }
            return;
        }

        for (int i = 0; i < playerNameTexts.Length; i++)
        {
            playerNameTexts[i].text = "Waiting For Player...";
            playerReadyTexts[i].text = string.Empty;
        }

        for (int i = 0; i < Room.RoomPlayers.Count; i++)
        {
            playerNameTexts[i].text = Room.RoomPlayers[i].DisplayName;
            playerReadyTexts[i].text = Room.RoomPlayers[i].IsReady ?
                "<color=green>Ready</color>" :
                "<color=red>Not Ready</color>";
        }
    }

    public void HandleReadyToStart(bool readyToStart)
    {
        if (!_IsLeader)
            return;

        startGameButton.interactable = readyToStart;
    }

    [Command]
    public void CmdReadyUp()
    {
        IsReady = !IsReady;
        
        Room.NotifyPlayersOfReadyState();
    }

    public void CmdStartGame()
    {
        if (Room.RoomPlayers[0].connectionToClient != connectionToClient)
            return;
    }
    
    [Command]
    private void CmdSetDisplayName(string displayName) => DisplayName = displayName;
    public void HandleReadyStatusChanged(bool oldValue, bool newValue) => UpdateDisplay();
    public void HandleDisplayNameChanged(string oldValue, string newValue) => UpdateDisplay();
}