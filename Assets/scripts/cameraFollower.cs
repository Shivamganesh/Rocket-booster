using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollower : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform rocket;
    private void LateUpdate()
    {
        transform.position = new Vector3(rocket.position.x, rocket.position.y, -17.16f);
    }
}
