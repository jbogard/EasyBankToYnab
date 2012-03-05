using System;

namespace QuestMaster.EasyBankToYnab.UI.Foundation
{
  public static class EventHandlerExtensions
    {
        public static void Raise(this EventHandler handler, object sender, EventArgs e)
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }
    }
}