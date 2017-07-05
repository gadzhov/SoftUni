using System;
using System.Collections;
class RandomList : ArrayList
{
    private Random _rnd;

    public RandomList()
    {
        this._rnd = new Random();
    }

    public string RandomString()
    {
        return "";
    }
}
