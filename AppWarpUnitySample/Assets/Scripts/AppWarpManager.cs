using UnityEngine;
using System.Collections;

using com.shephertz.app42.gaming.multiplayer.client;
using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.message;
using com.shephertz.app42.gaming.multiplayer.client.transformer;
using AssemblyCSharp;
using UnityEngine.UI;

public class AppWarpManager : MonoBehaviour {

	public string apiKey = "Your API Key";
	public string secretKey = "Your Secret Key";
	public InputField username;
	public InputField roomName;
	public InputField maxUsers;
	public InputField roomID;
	public InputField chatInput;
	public InputField charUsername;

	MyListener listen;
	Rect myRect;
//	IEnumerator e;
	// Use this for initialization
	void Start () {
		WarpClient.initialize(apiKey,secretKey);
		listen = GetComponent<MyListener>();
		WarpClient.GetInstance().AddConnectionRequestListener(listen);
		WarpClient.GetInstance().AddChatRequestListener(listen);
		WarpClient.GetInstance().AddLobbyRequestListener(listen);
		WarpClient.GetInstance().AddNotificationListener(listen);
		WarpClient.GetInstance().AddRoomRequestListener(listen);
		WarpClient.GetInstance().AddUpdateRequestListener(listen);
		WarpClient.GetInstance().AddZoneRequestListener(listen);

		myRect = new Rect (10, 350, 500, 300);
//		StartCoroutine ("SomeFunc");
	}

//	IEnumerator SomeFunc(){
//		e = execute ("");
//		while (e != null && e.MoveNext()) {
//			Debug.Log("asd");
//			yield return e.Current;
//		}
//	}
//
//	IEnumerator execute (string es){
//		yield return new WaitForSeconds (10);
//		Debug.Log ("Done");
//	}

	//Update
	void Update(){
		WarpClient.GetInstance().Update();
//		if (Input.GetKeyDown (KeyCode.W)) {
//			e = null;
//		}
	}

	//OnGUI
	void OnGUI()
	{
		GUI.contentColor = Color.black;
		GUI.Label(myRect, listen.getDebug());
	}

	//Application Quit
	void OnApplicationQuit()
	{
		WarpClient.GetInstance().Disconnect();
	}

	// Connect
	public void Connect () {
		Debug.Log ("Connect Called......"+System.DateTime.Now);
		WarpClient.GetInstance ().Connect(username.text);
	}
	// DisConnect
	public void Disconnect () {
		WarpClient.GetInstance().Disconnect();
	}
	// GetAllRooms
	public void GetAllRoom () {
		WarpClient.GetInstance().GetAllRooms();
	}
	// Connect
	public void CreateRoom () {
		if (WarpClient.GetInstance ().GetConnectionState ()== WarpConnectionState.CONNECTED) {
			Debug.Log("Creating Room..........");
			WarpClient.GetInstance ().CreateRoom (roomName.text, username.text, int.Parse (maxUsers.text), null);
		} else {
			Debug.Log("Not Connected........Try Again");
		}
	}
	// GetUserInfo
	public void GetUserInfo () {
		WarpClient.GetInstance().GetLiveUserInfo(username.text);
	}
	// JoinRoom
	public void JoinRoom () {
		WarpClient.GetInstance().JoinRoom(roomID.text);
	}
	// GetRoomInfo
	public void GetRoomInfo () {
		WarpClient.GetInstance().GetLiveRoomInfo(roomID.text);
	}
	// SubscribeRoom
	public void SubscribeRoom () {
		WarpClient.GetInstance().SubscribeRoom(roomID.text);
	}
	// LeaveRoom
	public void LeaveRoom () {
		WarpClient.GetInstance().LeaveRoom(roomID.text);
	}
	// UnSubscribeRoom
	public void UnSubscribeRoom () {
		WarpClient.GetInstance().UnsubscribeRoom(roomID.text);
	}
	// GetLobbyInfo
	public void GetLobbyInfo () {
		WarpClient.GetInstance().GetLiveLobbyInfo();
	}
	// JoinLobby
	public void JoinLobby () {
		//WarpClient.GetInstance().JoinLobby();
		//var array = Encoding.ASCII.GetBytes(new string("how are you", 100));
		byte[] smallArray = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
		WarpClient.GetInstance ().SendUpdatePeers (smallArray);
	}
	// LeaveLobby
	public void LeaveLobby () {
		//WarpClient.GetInstance().LeaveLobby();
//		for(int i=0, i<1000, i++){
//			WarpClient.GetInstance().SendChat("Hi, how are you?");
//		}

	}
	// GetOnlineUsers
	public void GetOnlineUsers () {
		WarpClient.GetInstance().GetOnlineUsers();
	}
	// SendChat
	public void SendChat () {
		WarpClient.GetInstance().SendChat(chatInput.text);
	}
	// SendPrivateChat
	public void SendPrivateChat () {
		WarpClient.GetInstance().sendPrivateChat(charUsername.text, chatInput.text);
	}
	// DeleteRoom
	public void DeleteRoom () {
		WarpClient.GetInstance().DeleteRoom(roomID.text);
	}
}