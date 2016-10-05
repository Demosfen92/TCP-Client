using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class Connector : MonoBehaviour {

	private byte[] data = new byte[1024];
	private string input;
	private string stringData;

	private IPEndPoint endpoint;
	private Socket server;

	// Use this for initialization
	void Start () {

		endpoint = new IPEndPoint (IPAddress.Parse("192.168.1.38"), 3159);
		server = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

		try {
			server.Connect(endpoint);
			Debug.Log ("Connection established.");
		} catch(SocketException ex) {
			Debug.Log ("Unnable to connect.");
			Debug.Log (ex.ToString());
			return;
		}
	}
	
	// Update is called once per frame
	void Update () {
		var recieved = server.Receive (data);
		stringData = Encoding.UTF8.GetString (data, 0, recieved);
		Debug.Log (stringData);
	}
}
