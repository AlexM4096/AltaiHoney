using System.Collections.Generic;
using OrderSystem;

namespace DialogSystem
{
    public interface IDialog
    {
        IReadOnlyList<string> Lines { get; }
        OrderData OrderDialog { get; }
    }
}