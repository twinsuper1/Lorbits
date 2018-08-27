using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour {

    public Transform parentTarget;

    public bool useParentMethod;
    public bool worldPosStays = true;

    private void Awake()
    {
        if (!useParentMethod)
        {
            transform.parent = parentTarget;
        } else
        {
            transform.SetParent(parentTarget, worldPosStays);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
