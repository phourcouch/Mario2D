using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOverScript : MonoBehaviour
{
    public Transform Mario;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per framed
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {

        Mario.transform.GetComponent<MarioScript>().ResetPos();

    }
}
