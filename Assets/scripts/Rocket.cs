using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float upThrust = 100f;

    Rigidbody rigidody;

    AudioSource audioSource;

    void Start()
    {
        rigidody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "friendly":
                Debug.Log("ok");
                break;
        }
    }

    private void Thrust()
    {
        float thrustSpeed = upThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            rigidody.AddRelativeForce(Vector3.up * thrustSpeed);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        rigidody.freezeRotation = true; //take mannual control of rotation

        float rotationSpeed = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }

        rigidody.freezeRotation = false; // resume the physics control of rotation
    }

   
}
