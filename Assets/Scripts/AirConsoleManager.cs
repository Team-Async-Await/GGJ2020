using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class AirConsoleManager : MonoBehaviour
{
    void Awake()
    {
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onDisconnect += OnDisconnect;
    }

	void OnConnect(int device_id)
	{
		if (AirConsole.instance.GetActivePlayerDeviceIds.Count == 0)
		{
			if (AirConsole.instance.GetControllerDeviceIds().Count >= 2)
			{
				//StartGame();
			}
			else
			{
				//uiText.text = "NEED MORE PLAYERS";
			}
		}
	}
	
	void OnDisconnect(int device_id)
	{
		int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device_id);
		if (active_player != -1)
		{
			if (AirConsole.instance.GetControllerDeviceIds().Count >= 2)
			{
				//StartGame();
			}
			else
			{
				AirConsole.instance.SetActivePlayers(0);
				//ResetBall(false);
				//uiText.text = "PLAYER LEFT - NEED MORE PLAYERS";
			}
		}
	}

	/// <summary>
	/// We check which one of the active players has moved the paddle.
	/// </summary>
	/// <param name="from">From.</param>
	/// <param name="data">Data.</param>
	void OnMessage(int device_id, JToken data)
	{
		int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device_id);

		var json = data.Last.ToString().Replace(@"\r", "").Replace(@"\n","");
		var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

//		data["data"]["action"].ToString();
//"shoot"
//data["data"]["key"].ToString();
//"up"


		if (active_player != -1)
		{
			if (active_player == 0)
			{
				//this.racketLeft.velocity = Vector3.up * (float)data["move"];
				Debug.Log("Player1");
			}
			if (active_player == 1)
			{
				Debug.Log("Player2");
				//this.racketRight.velocity = Vector3.up * (float)data["move"];
			}
		}
	}

	void Start()
    {
        
    }

    void Update()
    {
        
    }
}
