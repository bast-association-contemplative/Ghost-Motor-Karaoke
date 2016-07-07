#pragma strict

private var UDPHost : String = "127.0.0.1";
private var listenerPort : int = 8000;
private var broadcastPort : int = 57131;
private var oscHandler : Osc;

private var OpenBCIEvent : int = 0;
  
private var ghost_script : Ghost;

function Awake() {
    ghost_script = this.GetComponent("Ghost"); //Don't forget to place the 'Ghost' file inside the 'Standard Assets' folder  
}


public function Start ()
{	
	var udp : UDPPacketIO = GetComponent("UDPPacketIO");
	udp.init(UDPHost, broadcastPort, listenerPort);
	oscHandler = GetComponent("Osc");
	oscHandler.init(udp);
			
	oscHandler.SetAddressHandler("/getMic", OpenBCITest);

	//ghostScript = GetComponent(Ghost);

}
Debug.Log("Running");

function Update () {

	Debug.Log(OpenBCIEvent);
	if(OpenBCIEvent > 10 || OpenBCIEvent < -10){
	//transform.position = new Vector3(transform.position.x + (OpenBCIEvent/10), transform.position.y);
	}

	if(OpenBCIEvent > 10){
		ghost_script.move(0.1f);
	} else if(OpenBCIEvent < -10){
		ghost_script.move(-0.1f);
	}
}	

public function OpenBCITest(oscMessage : OscMessage) : void
{	
	Osc.OscMessageToString(oscMessage);
	OpenBCIEvent = oscMessage.Values[0];
}