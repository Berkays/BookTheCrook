using System;
using System.Collections;
using System.Collections.Generic;
using Colyseus;
using TMPro;
using UnityEngine;

public class ClientScript : MonoBehaviour
{
    public TextMeshProUGUI StatusText;
    public TMP_InputField NicknameField;
    const string SERVER = "ws://192.168.1.100:2657";
    const string ROOM_NAME = "Game";
    private Client client;
    private Room room;

    public void Connect()
    {
        StartCoroutine(ConnectRoutine());
    }

    public void DisconnnectFromServer()
    {
        room.Leave();
        client.Close();
    }

    IEnumerator ConnectRoutine()
    {
        client = new Client(SERVER);

        client.OnOpen += OnConnected;
        client.OnClose += OnClose;

        yield return StartCoroutine(client.Connect());

        room = client.Join(ROOM_NAME, new Dictionary<string, object>()
        {
            { "PlayerName", this.NicknameField.text }
        });

        room.OnReadyToConnect += (sender, e) =>
        {
            Debug.Log("Connecting to the room!");
            StartCoroutine(room.Connect());
        };

        room.OnJoin += OnJoin;
        room.OnMessage += OnMessage;

        while (true)
        {
            client.Recv();
            yield return 0;
        }

    }


    private void OnConnected(object sender, EventArgs e)
    {
        StatusText.text = "Status: Connected to the server";
    }

    private void OnJoin(object sender, EventArgs e)
    {
        StatusText.text = "Status: Connected to the room id:" + room.id;
    }

    private void OnClose(object sender, EventArgs e)
    {
        StatusText.text = "Status: Not connected";
    }

    private void OnMessage(object sender, MessageEventArgs e)
    {
        string serverMsg = e.message.ToString();
        Debug.Log("Server sent message: " + serverMsg);
        if (serverMsg == "Start")
            StatusText.text = "Starting game...";
    }
}
