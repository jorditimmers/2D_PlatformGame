using System;
using DPlatformGame.Interfaces;

namespace DPlatformGame.Combat
{
    public class CheckCollision
    {
        public static bool Check(ICollision ob1, ICollision ob2)
        {
            if (ob1.Frame.Intersects(ob2.Frame))
            {
                return true;
            }
            return false;
        }
    }
}

