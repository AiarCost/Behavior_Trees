using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : ITask
{
    public List<ITask> children;

    public Selector(List<ITask> taskList)
    {
        children = taskList;
    }

    public bool run()
    {
        foreach( ITask task in children)
        {
            if (task.run())
            {
                return true;
            }
        }
        return false;
    }
}
