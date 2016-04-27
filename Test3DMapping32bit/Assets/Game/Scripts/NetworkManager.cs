using UnityEngine;
using System.Collections;
using System;
using Photon;

public enum GameRole { Camera, Player }

public class NetworkManager : PunBehaviour {

    public GameRole Role = GameRole.Camera;
    public SpawnPointsReference SpawnPoints;
    public Transform World;

    private PhotonView _photonView;

    private bool _cameraServerSeatTaken;
    private bool _redPlayerSeatTaken;
    private bool _bluePlayerSeatTaken;

    private string roomName = "DemoRoom";
    private RoomInfo[] roomsList;

	void Start () {
        _photonView = PhotonView.Get(this);
        PhotonNetwork.ConnectUsingSettings("0.1");

    }

    public override void OnPhotonJoinRoomFailed(object[] codeAndMsg)
    {
        PhotonNetwork.CreateRoom(roomName, new RoomOptions() { maxPlayers = 3 }, null);
    }

public override void OnJoinedLobby()
    {

        PhotonNetwork.JoinRoom(roomName);

    }

    public override void OnReceivedRoomListUpdate()
    {
        roomsList = PhotonNetwork.GetRoomList();
    }

    public override void OnJoinedRoom()
    {

        StartCoroutine(AssumeRole());

    }

    public IEnumerator AssumeRole()
    {
        yield return new WaitForSeconds(2);
        switch (Role)
        {
            case GameRole.Camera:
                Instantiate(Resources.Load("ARCamera"), SpawnPoints.ARCameraSpawn.position, SpawnPoints.ARCameraSpawn.rotation);
                PhotonNetwork.Instantiate("RedTarget", SpawnPoints.RedTargetSpawn.position, SpawnPoints.RedTargetSpawn.rotation, 0).transform.parent = World;
                PhotonNetwork.Instantiate("BlueTarget", SpawnPoints.BlueTargetSpawn.position, SpawnPoints.BlueTargetSpawn.rotation, 0).transform.parent = World;
                PhotonNetwork.Instantiate("Puck", SpawnPoints.PuckSpawn.position, SpawnPoints.PuckSpawn.rotation, 1).transform.parent = World;
                break;
            case GameRole.Player:
                if (!GameObject.Find("RedMallet(Clone)"))
                {
                    Instantiate(Resources.Load("Red VR Camera"), SpawnPoints.RedVRCameraSpawn.position, SpawnPoints.RedVRCameraSpawn.rotation);
                    PhotonNetwork.Instantiate("RedMallet", SpawnPoints.RedMalletSpawn.position, SpawnPoints.RedMalletSpawn.rotation, 0).transform.parent = World;
                }
                else if (!GameObject.Find("BlueMallet(Clone)"))
                {
                    Instantiate(Resources.Load("Blue VR Camera"), SpawnPoints.BlueVRCameraSpawn.position, SpawnPoints.BlueVRCameraSpawn.rotation);
                    PhotonNetwork.Instantiate("BlueMallet", SpawnPoints.BlueMalletSpawn.position, SpawnPoints.BlueMalletSpawn.rotation, 0).transform.parent = World;
                }
                else
                {
                    _photonView.RPC("BroadcastDebugLog", PhotonTargets.All, "Extra player doesn't get a mallet");
                }
                break;
            default:
                break;
        }

        _photonView.RPC("TakeSeat", PhotonTargets.AllBuffered, Role);
    }


    [PunRPC]
    public void TakeSeat(GameRole role)
    {
        if (role == GameRole.Camera)
        {
            if (_cameraServerSeatTaken)
            {
                _photonView.RPC("BroadcastDebugLog", PhotonTargets.All, "Camera seat is taken but another camera is trying to join");
            }
            else
            {
                _cameraServerSeatTaken = true;
            }
        }
        else if (_redPlayerSeatTaken)
        {
            if (_bluePlayerSeatTaken)
            {
                _photonView.RPC("BroadcastDebugLog", PhotonTargets.All, "Both player seats taken but another player is trying to join");
            }
            else
            {
                _bluePlayerSeatTaken = true;
            }
        }
        else
        {
            _redPlayerSeatTaken = true;
        }
        
    }

    [PunRPC]
    public void BroadcastDebugLog(string message)
    {
        Debug.Log(message);
    }

    void Update () {
	
	}
}
