using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace AMSX
{
    class CComboBoxControl
    {
        public static void AddDataToComboBox(ComboBox cComboBox, string[] strData)
        {
            foreach (string strItem in strData)
            {
                if (!string.IsNullOrEmpty(strItem))
                {
                    cComboBox.Items.Add(strItem);
                }
            }

            if (cComboBox.Items.Count != 0)
            {
                cComboBox.SelectedIndex = 0;
            }
        }
    }
}
