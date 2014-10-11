using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class HandleWaitingForm
    {
        private WaitingForm wf = new WaitingForm();
        public static void startWaitingForm(WaitingForm waitForm)
        {
            new Thread((ThreadStart)delegate
            {
                Application.Run(waitForm);
            }).Start();
        }

        public static void closeWaitingForm(WaitingForm waitForm)
        {
            waitForm.Invoke((EventHandler)delegate { waitForm.Close(); });
            waitForm = null;
        }
    }
}
