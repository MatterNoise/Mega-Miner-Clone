using System;
using SDL3;
using RootBeer_CS;
using GameClasses;

class ClampClass
{
    public static float Clamp(float _Min, float _Max, float _Value)
    {
        return MathF.Max(MathF.Min(_Max, _Value), _Min);
    }
}