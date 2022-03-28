using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : ITask
{
    public List<ITask> children;

    public Sequence(List<ITask> taskList)
    {
        children = taskList;
    }

    public bool run()
    {
        foreach(ITask task in children)
        {
            if (!task.run())
            {
                return false;
            }
        }
        return true;
    }
}
