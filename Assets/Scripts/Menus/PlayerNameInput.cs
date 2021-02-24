using TMPro;
using UnityEngine;

namespace Menus
{
    public class PlayerNameInput : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        
        public static string Username { get; private set; }

        private const string PrefsUsernameValue = "Username";

        private void Start() => SetUpField();
        
        private void SetUpField()
        {
            if (!PlayerPrefs.HasKey(Username)) 
                return;

            string defaultName = PlayerPrefs.GetString(PrefsUsernameValue);

            inputField.text = defaultName;
            
            SetPlayerName(defaultName);
        }

        public void SetPlayerName(string name)
        {
            Username = name;
            PlayerPrefs.SetString(PrefsUsernameValue, Username);
        }
    }
}
