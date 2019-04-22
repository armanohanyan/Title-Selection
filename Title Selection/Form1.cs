﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Title_Selection
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public int TitleID = 0;

        private void frmMain_Load(object sender, EventArgs e)
        {
            ResetNainForm();
            //dgvTitleList.DataSource = null;
            //dgvTitleList.DataSource = SQLHelper.ListOfThemes();
        }
        private void frmMain_Shown(object sender, EventArgs e)
        {
            ResetNainForm();
        }
        private void frmMain_Activated(object sender, EventArgs e)
        {
            ResetNainForm();
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            DataTable dt = SQLHelper.ListOfThemes();
            int rownumber = Convert.ToInt32(dgvTitleList.SelectedRows[0].Cells[0].Value);
            string title = dt.Rows[0]["Թեմա"].ToString();

            if (dgvTitleList.SelectedRows.Count > 0)
            {
                if (dgvTitleList.SelectedRows[0].Cells[2].Value is true)
                {
                    MessageBox.Show("Տվյալ թեման արդեն իկս ընտրված է։");
                    //throw new Exception("Տվյալ թեման արդեն իկս ընտրված է");
                }
                else
                {
                    frmSelectTitle f = new frmSelectTitle();
                    f.txtTitle.Text = title;
                    f.lblTitleID.Text = rownumber.ToString();
                    f.ShowDialog();
                }


                //int id = Convert.ToInt32(dgvTitleList.SelectedRows[0].Cells[0].Value.ToString());
                //SQLHelper.SelectTheme(id);

                //dgvTitleList.DataSource = null;
                //dgvTitleList.DataSource = SQLHelper.ListOfThemes();

                //MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Անհրաժեշտ է ընտրել թեմա։");
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    throw;
            //}


        }

        public void ResetNainForm()
        {
            dgvTitleList.AllowUserToAddRows = false;
            dgvTitleList.AllowUserToDeleteRows = false;
            dgvTitleList.AllowUserToOrderColumns = false;
            dgvTitleList.AllowUserToResizeColumns = false;
            dgvTitleList.AllowUserToResizeRows = false;
            dgvTitleList.AllowDrop = false;
            dgvTitleList.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvTitleList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgvTitleList.AutoResizeColumns();
            dgvTitleList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dgvTitleList.Width = panel1.Width;
            //dgvTitleList.Height = panel1.Height;
            //dgvTitleList.Enabled = false;
            dgvTitleList.AutoSize = true;
            dgvTitleList.DataSource = null;
            dgvTitleList.DataSource = SQLHelper.ListOfThemes();

            int colCount = dgvTitleList.Columns.Count; // this returns the total number of columns (=6)
            int gridSize = dgvTitleList.Width - 44;
            for (int i = 0; i < colCount; i++)
            {
                DataGridViewColumn column = dgvTitleList.Columns[i]; // column[1] selects the required column
                column.Width = gridSize / colCount;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // sets the AutoSizeMode of column defined in previous line
                int colWidth = column.Width; // store columns width after auto resize
                                             //MessageBox.Show(colWidth.ToString()); // show me the autoresize width (used as a visual check really)

                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // set the column resize mode to 'none' to allow manual/program changes
                colWidth = gridSize / colCount; // add 20 pixels to what 'colWidth' already is
                colWidth = gridSize / colCount; // add 20 pixels to what 'colWidth' already is

                dgvTitleList.Columns[0].Width = Convert.ToInt32(0.08 * gridSize); // set the columns width to the value stored in 'colWidth'
                dgvTitleList.Columns[1].Width = Convert.ToInt32(0.45 * gridSize); // set the columns width to the value stored in 'colWidth'
                dgvTitleList.Columns[2].Width = Convert.ToInt32(0.07 * gridSize); // set the columns width to the value stored in 'colWidth'
                dgvTitleList.Columns[3].Width = Convert.ToInt32(0.1 * gridSize); // set the columns width to the value stored in 'colWidth'
                dgvTitleList.Columns[4].Width = Convert.ToInt32(0.1 * gridSize); // set the columns width to the value stored in 'colWidth'
                dgvTitleList.Columns[5].Width = Convert.ToInt32(0.1 * gridSize); // set the columns width to the value stored in 'colWidth'
                dgvTitleList.Columns[6].Width = Convert.ToInt32(0.1 * gridSize); // set the columns width to the value stored in 'colWidth'





            }


        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            ResetNainForm();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
