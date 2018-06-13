using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;


public class UdpClientManager : MonoBehaviour {
	Thread udpListeningThread;
	Thread udpSendingThread;
	public int portNumberReceive;
	UdpClient receivingUdpClient;

	private void initListenerThread()
	{
		portNumberReceive = 5000;

		Debug.Log("Started on : " + portNumberReceive.ToString());
		udpListeningThread = new Thread(new ThreadStart(UdpListener));

		// Run in background
		udpListeningThread.IsBackground = true;
		udpListeningThread.Start();
	}

	public void UdpListener()
	{
		receivingUdpClient = new UdpClient(portNumberReceive);

		while (true)
		{
			//Listening 
			try
			{
				IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
				//IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Broadcast, 5000);

				// Blocks until a message returns on this socket from a remote host.
				byte[] receiveBytes = receivingUdpClient.Receive(ref RemoteIpEndPoint);

				if (receiveBytes != null)
				{
					string returnData = Encoding.ASCII.GetString(receiveBytes);
					Debug.Log("Message Received" + returnData.ToString());
					Debug.Log("Address IP Sender" + RemoteIpEndPoint.Address.ToString());
					Debug.Log("Port Number Sender" + RemoteIpEndPoint.Port.ToString());

					if (returnData.ToString() == "TextTest")
					{
						//Do something if TextTest is received
					}
				}
			}
			catch (Exception e)
			{
				Debug.Log(e.ToString());
			}
		}
	}

	void Start()
	{
		initListenerThread();
	}
}