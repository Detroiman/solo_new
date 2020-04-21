using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class AccSettings : MonoBehaviour
{
	[SerializeField] private InputField nameInputField = null;
	[SerializeField] private Button Nickname;
	public GameObject Back;
	private const string PlayerPrefsNameKey = "PlayerName";

	void Start() => SetUpInputField();
	private void SetUpInputField()
	{
		if (!PlayerPrefs.HasKey(PlayerPrefsNameKey)) { return; }

		string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

		nameInputField.text = defaultName;

		
	}

	

	public void SavePlayerName() {
		
		string playerName = nameInputField.text;

		
		PhotonNetwork.NickName = playerName;

		PlayerPrefs.SetString(PlayerPrefsNameKey, playerName);
	}

	void Update()
	{

	}
	public void buttonBack()
	{
		Application.LoadLevel("Settings");
	}
	public void buttonNickname()
	{
	}
}
