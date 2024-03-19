using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class MenuManager : MonoBehaviourPunCallbacks
{
	[SerializeField] private TMP_InputField _createLobbyInput;
	[SerializeField] private TMP_InputField _joinLobbyInput;

	public void CreateLobby()
	{
		RoomOptions roomOptions = new RoomOptions();
		roomOptions.MaxPlayers = 4;
		PhotonNetwork.CreateRoom(_createLobbyInput.text, roomOptions);
	}

	public void JoinLobby()
	{
		PhotonNetwork.JoinRoom(_joinLobbyInput.text);
	}

	public override void OnJoinedRoom()
	{
		PhotonNetwork.LoadLevel("Game");
	}
}
