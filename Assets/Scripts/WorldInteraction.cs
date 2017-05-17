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

	public GameObject mark;

     void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
		anim = PlayerChild.GetComponent<Animator> ();

		controller = gameController.GetComponent<Controller> ();

		rBody = this.GetComponent<Rigidbody> ();
    }

	IEnumerator Mark(RaycastHit ray)
	{
		Debug.Log ("VENTER");
		mark.SetActive (true);
		mark.transform.position = ray.point;

		yield return new WaitForSeconds(1);
		Debug.Log ("HAR VENTET");
		mark.SetActive(false);
		//Do Function here...
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();


        }
		velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
		previous = transform.position;

//		Debug.Log (velocity);

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
		if(Physics.Raycast(interactionRay, out interactionInfo, 35f))
		{
			GameObject interactedObject = interactionInfo.collider.gameObject; 


			if(interactedObject.tag == "Interactable Object")
			{
				Debug.Log("Interactable interacted");
			}
			if(interactedObject.tag == "NPC")
			{
				interactedObject.GetComponent<Npc_Dialog> ().ShowWindow ();
			}
			if(interactedObject.tag == "Skovhugger")
			{
				interactedObject.GetComponent<Npc_task> ().ShowWindow ();
			}
		
			else
			{
				StartCoroutine (Mark (interactionInfo));

				playerAgent.destination = interactionInfo.point;
				// move the sphere to the clicked position



			}
        }
    }


}
	