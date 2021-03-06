﻿namespace patterns.AbstractFactory
{
    public abstract class BaseFactory
    {
        public abstract BaseBottle CreateBottle();

        public abstract BaseWater CreateWater();
    }
}
