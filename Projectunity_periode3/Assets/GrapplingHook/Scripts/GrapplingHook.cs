using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{

    public GameObject hook;
    public GameObject hookHolder;

    public float hookTravelsSpeed;
    public float playerTravelSpeed;

    public static bool fired;
    public bool hooked;
    public GameObject hookedObj;

    public float maxDisctance;
    private float currentDisctance;

    void Update()
    {
        //firing the hook
        if (Input.GetMouseButtonDown(0) && fired == false)
            fired = true;

        if (fired == true && hooked == false)
        {
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelsSpeed);
            currentDisctance = Vector3.Distance(transform.position, hook.transform.position);

            if (currentDisctance >= maxDisctance)
                ReturnHook();
        }

        if(hooked == true)
        {
            hook.transform.parent = hookedObj.transform;
            transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, Time.deltaTime * playerTravelSpeed);
            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);

            this.GetComponent<Rigidbody>().useGravity = false;

            if (distanceToHook < 1)
                ReturnHook();
        } else {
            hook.transform.parent = hookHolder.transform;
            this.GetComponent<Rigidbody>().useGravity = true;
        }


    }
        void ReturnHook()
        {
            hook.transform.position = hookHolder.transform.position;
            fired = false;
            hooked = false;
        }

    
}
