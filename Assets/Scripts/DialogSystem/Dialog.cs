using System.Collections.Generic;
using OrderSystem;

namespace DialogSystem
{
    public class Dialog : IDialog
    {
        public IReadOnlyList<string> Lines { get; }
        public OrderData OrderDialog { get; }

        public Dialog(IReadOnlyList<string> lines, OrderData orderDialog)
        {
            Lines = lines;
            OrderDialog = orderDialog;
        }
    }
}