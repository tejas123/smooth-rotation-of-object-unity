using UnityEngine;
using System.Collections;

public class SmoothRotation : MonoBehaviour {

	[Range(0,360)]public float angle;//Specify Angle For Rotation
	float tempAngle;//Temporary Angle Measurement Variable
	bool horizontalFlag;//Check For Horizontal Roation
	bool verticalFlag;//Check For Vertical Roation
	bool isRotating;//Check Whether Currently Object is Rotating Or Not.
	int Direction;//Direction Of Rotation

	//Called For Initialization
	void Start () {
		horizontalFlag=verticalFlag=isRotating=false;
	}

	//Method For Horizontal Input
	void CheckForHorizontalInput()
	{
		if(Input.GetAxis("Horizontal")!=0 && !isRotating)
		{
			isRotating=true;
			Direction=(Input.GetAxis("Horizontal")<0?-1:1);//Set Direction
			horizontalFlag=true;
			tempAngle=0;
		}
	}

	//Method For Vertical Input
	void CheckForVerticalInput()
	{
		if(Input.GetAxis("Vertical")!=0 && !isRotating)
		{
			isRotating=true;
			Direction=(Input.GetAxis("Vertical")<0?-1:1);//Set Direction
			verticalFlag=true;
			tempAngle=0;
		}
	}

	//Method For horizontal Rotation
	void HorizontalRotation()
	{
		transform.Rotate(Vector3.up*angle*Time.fixedDeltaTime*Direction,Space.World);
		tempAngle+=angle*Time.fixedDeltaTime;
		if(tempAngle>=angle)
		{
			tempAngle=0;
			isRotating=false;
			horizontalFlag=false;
		}
	}

	//Method For Vertical Rotation
	void VerticalRotation()
	{
		transform.Rotate(Vector3.right*angle*Time.fixedDeltaTime*Direction,Space.World);
		tempAngle+=angle*Time.fixedDeltaTime;
		if(tempAngle>=angle)
		{
			tempAngle=0;
			isRotating=false;
			verticalFlag=false;
		}
	}
	
	void Update () {

		CheckForHorizontalInput();
		CheckForVerticalInput();
		if(horizontalFlag)
			HorizontalRotation();
		if(verticalFlag)
			VerticalRotation();



	}
}
