using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    public Transform followObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Following();
    }

    private void Following(){
        transform.position = new Vector3(followObject.position.x, transform.position.y, transform.position.z);
    }
}
