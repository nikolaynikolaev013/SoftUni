using System;
using System.Collections.Generic;

namespace _07.Military_Elite.Interfaces
{
    public interface LieutenantGeneral
    {
        IReadOnlyCollection<IPrivate> privates { get; }
    }
}
