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
using DAL.DTO;

namespace PersonalTracking
{
    public partial class FrmPositionList : Form
    {
        public FrmPositionList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmPosition frm = new FrmPosition();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            FillGrid(); 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
                MessageBox.Show("Please select a position from table");
            else
            {
                FrmPosition frm = new FrmPosition();
                frm.isUpdate = true;
                frm.detail = detail;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                FillGrid();
                
            }
        }
        List<PositionDTO> positionList = new List<PositionDTO>(); 
        void FillGrid()
        {
            positionList = PositionBLL.GetPositions();
            dataGridView1.DataSource = positionList;
        }

        PositionDTO detail= new PositionDTO();
        private void FrmPositionList_Load(object sender, EventArgs e)
        {
            FillGrid();
            dataGridView1.Columns[0].HeaderText = "Department Name"; // Nombre del Departamento 
            dataGridView1.Columns[1].Visible = false;                // Departamento Antiguo 
            dataGridView1.Columns[2].Visible = false;                // ID de la posición
            dataGridView1.Columns[3].HeaderText = "Position Name";   // Nombre de la posición  
            dataGridView1.Columns[4].Visible = false;                // ID del Departamento 

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.PositionName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.ID= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            detail.DepartmentID= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            detail.OldDepartmentID= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to delete this position", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                PositionBLL.DeletePosition(detail.ID);
                MessageBox.Show("Position was Deleted");
                FillGrid();
               

            }
        }
    }
}
