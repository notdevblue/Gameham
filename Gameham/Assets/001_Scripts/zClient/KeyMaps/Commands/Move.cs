using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commands.Movement.Movements
{
    public class MoveFoward : Command
    {
        IMoveable _moveable;

        public MoveFoward(IMoveable moveable)
        {
            _moveable = moveable;
        }

        public override void Execute()
        {
            _moveable.MoveUp();
        }
    }

    public class MoveBackword : Command
    {
        IMoveable _moveable;

        public MoveBackword(IMoveable moveable)
        {
            _moveable = moveable;
        }

        public override void Execute()
        {
            _moveable.MoveDown();
        }
    }

    public class MoveLeft : Command
    {
        IMoveable _moveable;

        public MoveLeft(IMoveable moveable)
        {
            _moveable = moveable;
        }

        public override void Execute()
        {
            _moveable.MoveLeft();
        }
    }

    public class MoveRight : Command
    {
        IMoveable _moveable;

        public MoveRight(IMoveable moveable)
        {
            _moveable = moveable;
        }

        public override void Execute()
        {
            _moveable.MoveRight();
        }
    }
}