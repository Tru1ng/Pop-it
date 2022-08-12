using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class SecondPersonController : MonoBehaviour
{
    private Animator anim;
    private UnityEngine.AI.NavMeshAgent nav;

    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        MovementRay();
    }

    void MovementRay()
    {
        //fire ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit;

        //walk to mouse positon
        if(Physics.Raycast (ray, out _hit, Mathf.Infinity) && Input.GetMouseButtonDown(1))
        {
            nav.SetDestination(_hit.point);
            //animation walk
            anim.SetBool("Walk", true);
            nav.isStopped = false;
        }

        //stop when person < 0,3f from mouse position
        if (Vector3.Distance(transform.position, nav.destination) < 1.1f)
        {
            nav.isStopped = true;
            //animation idle
            anim.SetBool("Walk", false);
        }

    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "M")
        {
            Destroy(col.gameObject);
        }
    }
}
