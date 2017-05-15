using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {
    NavMeshAgent playerAgent;
	private Animator anim;
	public GameObject PlayerChild;

	public GameObject gameController;
	private Controller controller;

	private Rigidbody rBody;

	private float velocity;
	private Vector3 previous;

     void Start()
    {

		controller = gameController.GetComponent<Controller> ();

        playerAgent = GetComponent<NavMeshAgent>();
		anim = PlayerChild.GetComponent<Animator> ();

		rBody = this.GetComponent<Rigidbody> ();
		Debug.Log ("Hej");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();


        }
		velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
		previous = transform.position;

		//Debug.Log (velocity);

		if (velocity == 0) {
			//Debug.Log ("STOP");
			anim.SetBool ("Walking", false);

		}
		if (velocity != 0) {
			//Debug.Log ("GO");
			anim.SetBool ("Walking", true);

		}


    }

    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if(Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject; 
			//anim.SetBool ("Walking", true);
			Debug.Log ("Raycast" + interactionInfo.point);
			Debug.Log ("Player" + playerAgent.destination);
			Debug.Log (interactedObject.name);
            if(interactedObject.tag == "Interactable Object")
            {
                Debug.Log("Interactable interacted");
            }
			if(interactedObject.tag == "NPC")
			{
				interactedObject.GetComponent<Npc_Dialog> ().ShowWindow ();
			}
			else if(interactedObject.tag == "Carpenter")
			{
				Debug.Log ("HER ER NOGET TRÆ");
				controller.woodAmount = 1;
			}
            else
            {
                playerAgent.destination = interactionInfo.point;
            }
        }
    }
}
