using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Common.Enum
{
    public enum AppMessageType
    {
        Navigate,
        PopUpMessage,
        ConfirmMessage, ConfirmWarningMessage,
        Close, YesNOMessage, TextReceiptMessage, TextReceiptMessageWithoutPhone, ReceiptConfirmationPrompt, PopupWarning
    }
}
