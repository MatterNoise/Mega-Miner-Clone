using System;
using SDL3;
using RootBeer_CS;

namespace GameClasses;
public class BaseTemplateClass
{
    public virtual void Init() { }
    public virtual void Close() { }

    public virtual void Update() { }
    public virtual void Draw() { }
}