using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	
	public GameObject playerPrefab;
	public Transform spawnObject;
	
	private string roomName = "Dynoman_Testing_Room_1";
	private bool refreshing = false;
	private HostData[] hostData = new HostData[0];
	private int numOfGames = 1;
	private int startPort = 25001;
	private int currentPort = 25001;
	
	Rect btn1 = new Rect(Screen.width * 0.08f, Screen.width * 0.05f,
	                     Screen.width * 0.2f, Screen.width * 0.1f);
	Rect btn2 = new Rect(Screen.width * 0.08f, Screen.width * 0.05f * 1.2f + Screen.width * 0.1f,
	                     Screen.width * 0.2f, Screen.width * 0.1f);
	Rect srvBtn = new Rect(Screen.width * 0.3f, Screen.width * 0.05f, 
	                       Screen.width * 0.2f, Screen.width * 0.05f);
	
	// Use this for initialization
	void Start () {
		currentPort = startPort;
	}
	
	void StartServer(){

		currentPort = Random.Range(25001, 25101);
		Network.InitializeServer(4, currentPort, !Network.HavePublicAddress());
		MasterServer.RegisterHost(roomName,"Dynoman " + numOfGames, "A Bomber-Man Experience");
		Debug.LogWarning(currentPort);
	}
	
	void RefreshHostList(){
		MasterServer.RequestHostList(roomName);
		refreshing = true;
		Debug.LogWarning(Network.player.ipAddress);
	}

	void Update () {
		if (refreshing){
			if (MasterServer.PollHostList().Length > 0){
				refreshing = false;
				Debug.Log(MasterServer.PollHostList().Length);
				hostData = MasterServer.PollHostList();
			}
		}
	}
	
	void spawnPlayer(){
		if (Network.isServer){
			Network.Instantiate(playerPrefab, spawnObject.position, 
			                    Quaternion.identity, 0);

		}
		else if (Network.isClient){
			Network.Instantiate(playerPrefab, spawnObject.position, 
			                    Quaternion.identity, 1);		
		}
	}
	
	//Server Messages
	void OnServerInitialized(){
		Debug.LogWarning ("Server Initialized!");
		spawnPlayer();

	}
	
	void OnConnectedToServer(){
		spawnPlayer();
		Debug.LogWarning("Shingeki");
	}

	void OnPlayerConnected(NetworkPlayer player){
		Debug.Log ("Player:" + player.port);
	}
	
	void OnMasterServerEvent(MasterServerEvent mse){
		if (mse == MasterServerEvent.RegistrationSucceeded)
			Debug.LogWarning("Registered Server");
	}
	
	//GUI
	void OnGUI(){
		if (!Network.isClient && !Network.isServer){
			if(GUI.Button(btn1, "Start Server")){
				Debug.LogWarning("Starting Server");
				StartServer();
			}
			
			if(GUI.Button(btn2, "Refresh Hosts")){
				Debug.LogWarning("Refreshing");
				RefreshHostList();
			}
			
			if (hostData.Length > 0){
				for (int i = 0; i < hostData.Length; i++){
					if(GUI.Button(srvBtn, hostData[i].gameName))
						Network.Connect(hostData[i]);
						
				}
			}
		}
	}
}
