using UnityEngine;
using System.Threading;
using System.Collections;

public interface ITask
{
    public bool run();
}


public class IsTrue : ITask
{
    bool someBool;

    public IsTrue( bool inputBool)
    {
        someBool = inputBool;
    }
    public bool run()
    {
        if (someBool)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class IsFalse : ITask
{
    bool someBool;

    public IsFalse(bool inputBool)
    {
        someBool = inputBool;
    }

    public bool run()
    {
        if (someBool)
        {
            Debug.Log("Input is true");
            return false;
        }
        else
        {
            Debug.Log("Input is false");
            return true;
        }
    }
}

public class MoveToTarget : ITask
{
    Seeker mMover;
    GameObject mTarget;
    public MoveToTarget(Kinematic mover, GameObject target)
    {
        mMover = mover as Seeker;
        mTarget = target;
    }

    public bool run()
    {
        mMover.myTarget = mTarget;
        mMover.SetupSteering();
        return true;
    }
}

public class OpenDoor : ITask
{
    GameObject mDoor;
    public OpenDoor (GameObject door)
    {
        mDoor = door;
    }
    public bool run()
    {
        mDoor.transform.eulerAngles = new Vector3(mDoor.transform.eulerAngles.x, mDoor.transform.eulerAngles.y + 90, mDoor.transform.eulerAngles.z);
        Debug.Log("Door opened");
        return true;
    }
}

public class BargeDoor : ITask
{
    Rigidbody rb;

    public BargeDoor(Rigidbody RB)
    {
        rb = RB;
    }
    public bool run()
    {
        rb.AddForce(new Vector3(-100, 300, 0));
        return true;
    }
}

public class Wait : MonoBehaviour, ITask
{
    private float Timer = .5f;

    public bool run()
    {
        StartCoroutine(Waiter());
        StopCoroutine(Waiter());
        return true;
    }
    
    IEnumerator Waiter()
    {
        Debug.Log("CoroutineStarted");
        yield return new WaitForSeconds(Timer);
    }
}