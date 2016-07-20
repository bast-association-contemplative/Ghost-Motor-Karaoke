#pragma strict

private var UDPHost : String = "127.0.0.1";
private var listenerPort : int = 8000;
private var broadcastPort : int = 57131;
private var oscHandler : Osc;

private var OpenBCIEvent : int = 0;
  
private var ghost_script : Ghost;

public var player0 : GameObject;
private var player0anim : Animator;
	   	  //var player0life : GameObject;
	 	
public var player1 : GameObject;
private var player1anim : Animator;
	   	   //var player1life : GameObject;

var anim_array = new Array ("impact1", "impact2", "impact3", "persoHit1", "persoHit2", "persoHit3");
public var anim_audio_array : AudioClip[];

function Awake() {
    ghost_script = this.GetComponent(Ghost); //Don't forget to place the 'Ghost' file inside the 'Standard Assets' folder  
    player0anim = player0.GetComponent(Animator);
    player1anim = player1.GetComponent(Animator);
}

public function Start ()
{	
	var udp : UDPPacketIO = GetComponent(UDPPacketIO);
	udp.init(UDPHost, broadcastPort, listenerPort);
	oscHandler = GetComponent(Osc);
	oscHandler.init(udp);
			
	oscHandler.SetAddressHandler("/getMic", OpenBCITest);

	//ghostScript = GetComponent(Ghost);

	//var audio: AudioSource = GetComponent.<AudioSource>();

	//TODO Get Player life pour stopper la possibilité de bouger le Ghost
	//Création d'une variable win true/false dans le ghost script
	//player0life = player0.transform.Find("vie").gameObject;
	//player1life = player1.transform.Find("vie").gameObject;
}

Debug.Log("Running");

function Update () {

	Debug.Log(OpenBCIEvent);
	//if(OpenBCIEvent > 10 || OpenBCIEvent < -10){
	//transform.position = new Vector3(transform.position.x + (OpenBCIEvent/10), transform.position.y);
	//}


	if(OpenBCIEvent > 20){


		player0anim.SetTrigger (anim_array[4].ToString());
		player1anim.SetTrigger (anim_array[2].ToString());

		GetComponent.<AudioSource>().clip = anim_audio_array[Random.Range(0, anim_audio_array.Length)];
		GetComponent.<AudioSource>().Play();

	} else if(OpenBCIEvent < -20){

		player0anim.SetTrigger (anim_array[4].ToString());
		player0anim.SetTrigger (anim_array[1].ToString());

		GetComponent.<AudioSource>().clip = anim_audio_array[Random.Range(0, anim_audio_array.Length)];
		GetComponent.<AudioSource>().Play();

	}

	//if(player0life.lifeSate > 0 && player1life.lifeSate > 0){
		if(OpenBCIEvent > 10){
			ghost_script.move(0.1f);
		} else if(OpenBCIEvent < -10){
			ghost_script.move(-0.1f);
		}
	//}
}	

public function OpenBCITest(oscMessage : OscMessage) : void
{	
	Osc.OscMessageToString(oscMessage);
	OpenBCIEvent = oscMessage.Values[0];
}