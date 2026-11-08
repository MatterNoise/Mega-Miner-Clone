using System;
using SDL3;
using RootBeer_CS;
using GameClasses;

class TweenClass
{
    public static float LERPInterpolate(float _ValueA, float _ValueB, float _Cuantity)
    {
        return _ValueA * (1 - _Cuantity) + _ValueB * _Cuantity;
    }
}