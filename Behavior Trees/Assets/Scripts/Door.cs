using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsOpen;
    public bool IsLocked;
    public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    private void Start()
    {
        if (IsOpen)
        {
            this.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);
        }
    }

    public void ChangeBoolOpen()
    {
        IsOpen = !IsOpen;
    }

    public void ChangeBoolLocked()
    {
        IsLocked = !IsLocked;
    }
}
