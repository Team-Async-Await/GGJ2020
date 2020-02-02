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
        var gamePlayer = LevelController.Player1;

        if (active_player != -1)
        {
            if (active_player == 0)
            {
                gamePlayer = LevelController.Player1;
            }
            if (active_player == 1)
            {
                gamePlayer = LevelController.Player2;
            }
        }

        if (data == null)
            return;
        //Shoot
        var action = data["data"]["action"];
        if (action != null)
        {
            if (action.ToString() == "shoot")
                gamePlayer.Shoot();
        }
        //Move
        action = data["data"]["key"];
        if (action != null)
        {
            if (data["data"]["pressed"].ToString().ToLower() == "false")
            {
                gamePlayer.Pressed = false;
                return;
            }

            switch (action.ToString())
            {
                case "up":

                    gamePlayer.Move(new Vector2(0, 1));
                    gamePlayer.Pressed = true;
                    break;
                case "right":
                    gamePlayer.Move(new Vector2(1, 0));
                    gamePlayer.Pressed = true;
                    break;
                case "down":
                    gamePlayer.Move(new Vector2(0, -1));
                    gamePlayer.Pressed = true;
                    break;
                case "left":
                    gamePlayer.Move(new Vector2(-1, 0));
                    gamePlayer.Pressed = true;
                    break;
            }
        }
    }
}
