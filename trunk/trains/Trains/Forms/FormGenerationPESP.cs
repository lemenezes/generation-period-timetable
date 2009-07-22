using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PeriodicTimetableGeneration.Forms
{
    public partial class FormGenerationPESP : Form
    {
        public FormGenerationPESP()
        {
            InitializeComponent();
        }

        #region List of Constraints (Methods)

        private void prepareListViewListOfConstraints()
        {
            // strat updating, prevent from draw method during updating
            listViewListOfConstraints.BeginUpdate();
            // retreive all constraints
            List<Constraint> constraints = ConstraintCache.getInstance().getCacheContent();
            // loop over all constraints
            foreach (Constraint constraint in constraints) 
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = constraint.TrainLineNumber1.ToString();
                lvi.SubItems.Add(constraint.TrainLineNumber2.ToString());
                lvi.Tag = constraint.TrainLineNumber1 + " - " + constraint.TrainLineNumber2;

                // add discrete set
                lvi.SubItems.Add(constraint.DiscreteSet.ToString());

                listViewListOfConstraints.Items.Add(lvi);
            }

            // end updating
            listViewListOfConstraints.EndUpdate();
        }

        #endregion


        #region Backround Worker (Generation)

        private void backgroundWorkerPESP_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorkerPESP_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorkerPESP_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        #endregion

        #region FormGenerationPESP Methods

        private void FormGenerationPESP_Load(object sender, EventArgs e)
        {

        }       

        #endregion

 
    }
}
