using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersionController : Singleton<VersionController> {
    
    public enum VersionType {Paid, Free}

    [SerializeField]
    private VersionType versionType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
