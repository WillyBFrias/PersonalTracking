﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace PersonalTracking
{
    public partial class FrmDepartmentList : Form
    {
        public FrmDepartmentList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmDepartment frm = new FrmDepartment();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            list = DepartmentBLL.GetDepartments();
            dataGridView1.DataSource = list;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
                MessageBox.Show("Please select a department from  table");
            else
            {
                FrmDepartment frm= new FrmDepartment();
                frm.isUpdate = true;
                frm.detail = detail;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                list = DepartmentBLL.GetDepartments();
                dataGridView1.DataSource = list;


            }
        }


        List<DEPARTMENTS> list = new List<DEPARTMENTS>();
        public DEPARTMENTS detail = new DEPARTMENTS();
        private void FrmDepartmentList_Load(object sender, EventArgs e)
        {            
            list = DepartmentBLL.GetDepartments();
            dataGridView1.DataSource = list;
            dataGridView1.Columns[0].Visible=false;                     // ID del Departamento
            dataGridView1.Columns[1].HeaderText = "Department Name";    // Nombre del Departamento
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.DepartmentName = dataGridView1.Rows[e.RowIndex ].Cells[1].Value.ToString();
        }
    }
}
