using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PeriodicTimetableGeneration.Util
{

    class TabUtil
    {
        private TabControl control;

        private int actualPosition;

        public TabUtil(TabControl control)
        {
            this.control = control;
            actualPosition = 0;
        }

        public void selectTab(TabPage page)
        {
            actualPosition = control.TabPages.IndexOf(page);
            control.SelectTab(page);
        }

        public void onTabSelected(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex > actualPosition)
            {
                MessageBox.Show("Use the NEXT button to move forward.", "Could not proceed.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

    }

}
