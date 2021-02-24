using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menus
{
    public class LobbyConnectionMenu : MonoBehaviour
    {
        [SerializeField] private NetworkManagerHLW networkManager;

        [Header("UI")] [SerializeField] private GameObject landingPagePanel = null;
        [SerializeField] private TMP_InputField ipAddressField = null;
        [SerializeField] private Button joinButton = null;


        private void OnEnable()
        {
            NetworkManagerHLW.OnClientConnected += HandleClientConnect;
            NetworkManagerHLW.OnClientDisconnected += HandleClientDisconnect;
        }

        private void OnDisable()
        {
            NetworkManagerHLW.OnClientConnected += HandleClientConnect;
            NetworkManagerHLW.OnClientDisconnected += HandleClientDisconnect;
        }

        public void JoinLobby()
        {
            string ipAddress = ipAddressField.text;

            networkManager.networkAddress = ipAddress;
            networkManager.StartClient();

            joinButton.interactable = false;
        }

        private void HandleClientDisconnect() => joinButton.interactable = false;
        private void HandleClientConnect()
        {
            joinButton.interactable = false;
            
            gameObject.SetActive(false);
            // landingPagePanel?.SetActive(false);
        }

        public void HostLobby()
        {
            networkManager.StartHost();
            
            // landingPagePanel?.SetActive(false);
        }
    }
}