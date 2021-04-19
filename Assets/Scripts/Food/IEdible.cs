using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEdible
{
    public string Name { get; }
    public float Health { get; set; }
    public IStatus[] Statuses { get; }
}
