using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commands
{
    abstract public class BulletCommand
    {
        abstract public void Fire();
        abstract public void Delete();
    }
}
