using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternFloat : MonoBehaviour {

    //public AnimationCurve LanternFloating;

    // Update is called once per frame
    private void FixedUpdate()
    {
        //transform.position = new Vector3(transform.position.x, LanternFloating.Evaluate((Time.time % LanternFloating.length)), transform.position.z);
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.deltaTime)+3f, transform.position.z);
    }

}