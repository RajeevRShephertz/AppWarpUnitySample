using UnityEngine;

using com.shephertz.app42.gaming.multiplayer.client;
using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.message;
using com.shephertz.app42.gaming.multiplayer.client.transformer;
using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class MyListener : MonoBehaviour, ConnectionRequestListener, ZoneRequestListener, ChatRequestListener, LobbyRequestListener, NotifyListener, RoomRequestListener, UpdateRequestListener {

		string debug = "";

		private void Log(string msg)
		{
			debug = msg + "\n" + debug;
			Debug.Log (debug);
		}

		public string getDebug()
		{
			return debug;
		}

//		public void onInvokeZoneRPCDone (RPCEvent rpcEvent)
//		{
//
//		}
//
//		public void onInvokeRoomRPCDone (RPCEvent rpcEvent)
//		{
//
//		}

		public void onConnectDone(ConnectEvent eventObj){
			Debug.Log ("Time:"+System.DateTime.Now);
			Log ("onConnectDone : " + eventObj.getResult());
		}

		public void onDisconnectDone (ConnectEvent eventObj){
			Log ("onDisConnectDone : " + eventObj.getResult());
		}

		public void onJoinRoomDone (RoomEvent eventObj){
			Log ("onJoinRoomDone : " + eventObj.getResult());
		}

		public void onGetLiveRoomInfoDone (LiveRoomInfoEvent eventObj){
			Log ("onGetLiveRoomInfoDone : " + eventObj.getResult()  + ", RoomName : " + eventObj.getData().getName() + ", RoomID : " + eventObj.getData().getId() + ", RoomOwner : " + eventObj.getData().getRoomOwner() + ", MaxUsers : " + eventObj.getData().getMaxUsers());
		}

		public void onInitUDPDone (byte resultCode){
		}

		public void onSendChatDone (byte result){
			Log ("onSendChatDone : " + result);
		}

		public void onSendPrivateChatDone (byte result){
			Log ("onSendPrivateChatDone : " + result);
		}

		public void onGetLiveLobbyInfoDone (LiveRoomInfoEvent eventObj){
			Log ("onGetLiveLobbyInfoDone : " + eventObj.getResult()  + ", RoomName : " + eventObj.getData().getName() + ", RoomID : " + eventObj.getData().getId());
		}
		
		public void onJoinLobbyDone (LobbyEvent eventObj){
			Log ("onJoinLobbyDone : " + eventObj.getResult()  + ", RoomName : " + eventObj.getInfo().getName() + ", RoomID : " + eventObj.getInfo().getId());
		}
		
		public void onLeaveLobbyDone (LobbyEvent eventObj){
			Log ("onLeaveLobbyDone : " + eventObj.getResult()  + ", RoomName : " + eventObj.getInfo().getName() + ", RoomID : " + eventObj.getInfo().getId());
		}
		
		public void onSubscribeLobbyDone (LobbyEvent eventObj){

		}
		
		public void onUnSubscribeLobbyDone (LobbyEvent eventObj){

		}

		public void onCreateRoomDone (RoomEvent eventObj){
			Log ("onCreateRoomDone : " + eventObj.getResult() + ", RoomName : " + eventObj.getData().getName() + ", RoomID : " + eventObj.getData().getId());
		}
		
		public void onDeleteRoomDone (RoomEvent eventObj){
			Log ("onDeleteRoomDone : " + eventObj.getResult() + ", RoomName : " + eventObj.getData().getName() + ", RoomID : " + eventObj.getData().getId());
		}

		public void onGetAllRoomsDone (AllRoomsEvent eventObj){
			Log ("onGetAllRoomsDone : " + eventObj.getResult());
			string[] rooms = eventObj.getRoomIds ();
			if (rooms != null && rooms.Length != 0) {
					foreach (string room in rooms) {
						Log ("room " + room);
				}
			}
		}

		public void onGetLiveUserInfoDone (LiveUserInfoEvent eventObj){
			Log ("onGetLiveUserInfoDone : " + eventObj.getResult() + ", Name : " + eventObj.getName() + ", IsInLobby : " + eventObj.isLocationLobby());
		}
		
		public void onGetMatchedRoomsDone (MatchedRoomsEvent matchedRoomsEvent){
			Log ("onGetMatchedRoomsDone : " + matchedRoomsEvent.getResult());
		}
		
		public void onGetOnlineUsersDone (AllUsersEvent eventObj){
			Log ("onGetOnlineUsersDone : " + eventObj.getResult());
			string[] usernames = eventObj.getUserNames ();
			if (usernames != null && usernames.Length != 0) {
				foreach (string username in usernames) {
					Log ("username " + username);
				}
			}
		}
		
		public void onSetCustomUserDataDone (LiveUserInfoEvent eventObj){
			Log ("onSetCustomUserDataDone : " + eventObj.getResult());
		}

		//NotifyListener
		public void onRoomCreated (RoomData eventObj)
		{
			Log ("onRoomCreated");
		}
		
		public void onRoomDestroyed (RoomData eventObj)
		{
			Log ("onRoomDestroyed");
		}
		
		public void onUserLeftRoom (RoomData eventObj, string username)
		{
			Log ("onUserLeftRoom : " + username);
		}
		
		public void onUserJoinedRoom (RoomData eventObj, string username)
		{
			Log ("onUserJoinedRoom : " + username);
		}
		
		public void onUserLeftLobby (LobbyData eventObj, string username)
		{
			Log ("onUserLeftLobby : " + username);
		}
		
		public void onUserJoinedLobby (LobbyData eventObj, string username)
		{
			Log ("onUserJoinedLobby : " + username);
		}
		
		public void onUserChangeRoomProperty(RoomData roomData, string sender, Dictionary<string, object> properties, Dictionary<string, string> lockedPropertiesTable)
		{
			Log ("onUserChangeRoomProperty : " + sender);
		}
		
		public void onPrivateChatReceived(string sender, string message)
		{
			Log ("onPrivateChatReceived Successfull Sender : " + sender + ", Message : " + message);
		}
		
		public void onMoveCompleted(MoveEvent move)
		{
			Log ("onMoveCompleted by : " + move.getSender());
		}

		public void onUserPaused(String locid, Boolean isLobby, String username)
		{
		}
		
		public void onUserResumed(String locid, Boolean isLobby, String username)
		{
		}
		
		public void onGameStarted(string sender, string roomId, string nextTurn)
		{
		}
		
		public void onGameStopped(string sender, string roomId)
		{
		}
		
		public void onPrivateUpdateReceived(String sender, byte[] update, bool fromUdp)
		{
			
		}

		public void onNextTurnRequest(String lastTurn)
		{
			
		}

		public void onChatReceived (ChatEvent eventObj){
			Log ("onChatReceived Successfull Sender : " + eventObj.getSender() + ", Message : " + eventObj.getMessage());
		}

		public void onUpdatePeersReceived (UpdateEvent eventObj)
		{
			Debug.Log ("onUpdatePeersReceived.....Called");
		}

		public void onLockPropertiesDone(byte result)
		{
			Log ("onLockPropertiesDone : " + result);
		}
		
		public void onUnlockPropertiesDone(byte result)
		{
			Log ("onUnlockPropertiesDone : " + result);
		}

		public void onLeaveRoomDone (RoomEvent eventObj)
		{
			Log ("onLeaveRoomDone : " + eventObj.getResult() + ", RoomName : " + eventObj.getData().getName() + ", RoomID : " + eventObj.getData().getId());
		}
		
		public void onSetCustomRoomDataDone (LiveRoomInfoEvent eventObj)
		{
			Log ("onSetCustomRoomDataDone : " + eventObj.getResult());
		}

		//RoomRequestListener
		public void onSubscribeRoomDone (RoomEvent eventObj)
		{			
			Log ("onSubscribeRoomDone : " + eventObj.getResult() + ", RoomName : " + eventObj.getData().getName() + ", RoomID : " + eventObj.getData().getId());
		}
		
		public void onUnSubscribeRoomDone (RoomEvent eventObj)
		{
			Log ("onUnSubscribeRoomDone : " + eventObj.getResult() + ", RoomName : " + eventObj.getData().getName() + ", RoomID : " + eventObj.getData().getId());
		}

		public void onUpdatePropertyDone(LiveRoomInfoEvent eventObj){
		}

		//UpdateRequestListener
		public void onSendUpdateDone (byte result)
		{
			Debug.Log ("Yo, Got the result onSendUpdateDone " + result);
		}
		
		public void onSendPrivateUpdateDone(byte result)
		{
		}
	}
}
