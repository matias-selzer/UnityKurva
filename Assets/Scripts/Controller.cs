using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

	public GameObject rotatedObject;
	private int speed;

    // Start is called before the first frame update
    void Start()
    {
		#if !UNITY_EDITOR && UNITY_WEBGL
		WebGLInput.captureAllKeyboardInput = false;
		#endif
		speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
		rotatedObject.transform.Rotate (0,speed * Time.deltaTime,0);
    }

	public void rotate(string value){
		speed = int.Parse (value);

	}
}
