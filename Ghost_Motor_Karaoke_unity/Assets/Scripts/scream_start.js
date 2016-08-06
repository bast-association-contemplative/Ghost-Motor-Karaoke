#pragma strict
import UnityEngine.SceneManagement;

private var UDPHost : String = "127.0.0.1";
private var listenerPort : int = 8000;
private var broadcastPort : int = 57131;
private var oscHandler : Osc;

private var OpenBCIEvent : int = 0;

public var SoundLvl = 40;
	 		 		 	
public function Start ()
{	
	var udp : UDPPacketIO = GetComponent(UDPPacketIO);
	udp.init(UDPHost, broadcastPort, listenerPort);
	oscHandler = GetComponent(Osc);
	oscHandler.init(udp);
			
	oscHandler.SetAddressHandler("/getMic", OpenBCITest);
}

Debug.Log("Running");

function Update () {

	//Debug.Log(OpenBCIEvent);

	if(OpenBCIEvent > SoundLvl){
		SceneManager.LoadScene("motor Karaoke");
	} else if(OpenBCIEvent < -SoundLvl){
		SceneManager.LoadScene("motor Karaoke");
	}
}	

public function OpenBCITest(oscMessage : OscMessage) : void
{	
	Osc.OscMessageToString(oscMessage);
	OpenBCIEvent = oscMessage.Values[0];
}