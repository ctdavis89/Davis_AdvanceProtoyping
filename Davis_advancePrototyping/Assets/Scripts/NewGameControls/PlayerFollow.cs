using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    public Transform PLayerTransform;
    private Vector3 _cameraOffset;

    [Range(0.0f, 1.0f)]
    public float SmoothFactor = 0.5f;
    public bool LookAtPlayer = false;

    public bool RotateAroundPlayer = true;

    public float RotationsSpeed = 0.5f;


	// Use this for initialization
	void Start () {

        _cameraOffset = transform.position - PLayerTransform.position;



	}
	
	// Update is called once per frame
	void Update () {

        if(RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationsSpeed, Vector3.up);
            _cameraOffset = camTurnAngle * _cameraOffset;
        }

        Vector3 newPos = PLayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if (LookAtPlayer || RotateAroundPlayer)
            transform.LookAt(PLayerTransform);

	}
}
