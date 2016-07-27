#pragma strict

private var UDPHost : String = "127.0.0.1";
private var listenerPort : int = 8000;
private var broadcastPort : int = 57131;
private var oscHandler : Osc;

private var PureDataEvent : int = 0;
  
private var ghost_script : Ghost;

public var player0 : GameObject;
private var player0anim : Animator;
	 	
public var player1 : GameObject;
private var player1anim : Animator;

var anim_array = new Array ("impact1", "impact2", "impact3", "impact4", "impact5", "impact6", "persoHit1", "persoHit2", "persoHit3");
public var anim_audio_array : AudioClip[];

private var ghostCollide0 : int;
private var ghostCollide1 : int;

function Awake() {
	ghost_script = this.GetComponent(Ghost); 			//Don't forget to place the 'Ghost' file inside the 'Standard Assets' folder  
	player0anim = player0.GetComponent(Animator);
	player1anim = player1.GetComponent(Animator);
}

public function Start ()
{	
	var udp : UDPPacketIO = GetComponent(UDPPacketIO);
	udp.init(UDPHost, broadcastPort, listenerPort);
	oscHandler = GetComponent(Osc);
	oscHandler.init(udp);
			
	oscHandler.SetAddressHandler("/getMic", GetPdEvent);

	ghostCollide0 = ghost_script.CollidePlayer0;
	ghostCollide1 = ghost_script.CollidePlayer1;
}

Debug.Log("Running");

function Update () {

	//Debug.Log(PureDataEvent);

	if(PureDataEvent > 20){

		player0anim.SetTrigger (anim_array[Random.Range(0,5)].ToString());
		player1anim.SetTrigger (anim_array[Random.Range(6,8)].ToString());

		GetComponent.<AudioSource>().clip = anim_audio_array[Random.Range(0, anim_audio_array.Length)];
		GetComponent.<AudioSource>().Play();

	} else if(PureDataEvent < -20){

		player0anim.SetTrigger (anim_array[Random.Range(6,8)].ToString());
		player0anim.SetTrigger (anim_array[Random.Range(0,5)].ToString());

		GetComponent.<AudioSource>().clip = anim_audio_array[Random.Range(0, anim_audio_array.Length)];
		GetComponent.<AudioSource>().Play();

	}

	//Debug.Log(ghost_script.CollidePlayer0 + " + " + ghost_script.CollidePlayer1);

	if(ghostCollide0 < ghost_script.CollidePlayer0){

		Debug.Log("DELAY NOW");
		ghostCollide0 = ghost_script.CollidePlayer0;

	} else if(ghostCollide1 < ghost_script.CollidePlayer1){

		Debug.Log("DELAY NOW");
		ghostCollide1 = ghost_script.CollidePlayer1;

	}

	if(PureDataEvent > 10){
		ghost_script.move(0.1f, -0.5f);
	} else if(PureDataEvent < -10){
		ghost_script.move(-0.1f, 0.5f);
	}
}	

public function GetPdEvent(oscMessage : OscMessage) : void
{
	Osc.OscMessageToString(oscMessage);
	PureDataEvent = oscMessage.Values[0];
}