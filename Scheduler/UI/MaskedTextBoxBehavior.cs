using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Scheduler.UI
{
    internal class MaskedTextBoxBehavior
    {
        private static HashSet<MaskedTextBox> phoneTextBoxes = new HashSet<MaskedTextBox>();

        public static void ModifyMaskedTextBoxBehavior(Form form, object sender)
        {
            if (sender == null || !(sender is MaskedTextBox maskedTextBox))
                return;

            form.BeginInvoke((MethodInvoker)delegate ()
            {
                if (maskedTextBox.Mask == "000-0000")
                {
                    if (!phoneTextBoxes.Contains(maskedTextBox))
                    {
                        maskedTextBox.SelectionStart = 0;
                        phoneTextBoxes.Add(maskedTextBox);
                    }
                }
                else
                {
                    string mask = maskedTextBox.Mask;
                    maskedTextBox.Mask = "";

                    int position = Math.Min(maskedTextBox.SelectionStart, maskedTextBox.Text.Length);
                    maskedTextBox.Select(position, 0);

                    maskedTextBox.Mask = mask;
                }
            });
        }
    }
}
