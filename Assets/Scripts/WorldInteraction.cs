using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {
    NavMeshAgent playerAgent;
	private Animator anim;
	public GameObject PlayerChild;

     void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
		anim = PlayerChild.GetComponent<Animator> ();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();


        }

    }

    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if(Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject; 
			anim.Play ("Walk");
			Debug.Log ("Raycast" + interactionInfo.point);
			Debug.Log ("Player" + playerAgent.destination);

            if(interactedObject.tag == "Interactable Object")
            {
                Debug.Log("Interactable interacted");
            }
            else
            {
                playerAgent.destination = interactionInfo.point;
				anim.Play ("Idle");
            }
        }
    }
}
