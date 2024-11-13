using System;
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
using DAL.DAO;
using DAL.DTO;

namespace PersonalTracking
{
    public partial class FrmEmployeeList : Form
    {
        public FrmEmployeeList()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.EmployeeID == 0)
                MessageBox.Show("Please select an employee on table");
            else
            {
                FrmEmployee frm = new FrmEmployee();
                frm.isUpdate = true;
                frm.detail = detail;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                FillAllData();
                CleanFilters();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmEmployee frm= new FrmEmployee();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            FillAllData();
            CleanFilters();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbPosition_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cmbDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        EmployeeDTO dto = new EmployeeDTO();
        private bool combofull = false;
        EmployeeDetailDTO detail = new EmployeeDetailDTO();

        void FillAllData()
        {
            dto = EmployeeBLL.GetAll();
            dataGridView1.DataSource = dto.Employees;
            
            combofull = false;
            cmbDepartment.DataSource = dto.Departments;
            cmbDepartment.DisplayMember = "DepartmentName";     
            cmbDepartment.ValueMember = "ID";
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.DisplayMember = "PositionName";
            cmbPosition.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            combofull = true;
        }

        private void FrmEmployeeList_Load(object sender, EventArgs e)
        {
            FillAllData();
            dataGridView1.Columns[0].Visible = false;           // Numero del Empleado
            dataGridView1.Columns[1].HeaderText = "User No";    // Numero de Usuario
            dataGridView1.Columns[2].HeaderText = "Name";       // Nombre del Usuario
            dataGridView1.Columns[3].HeaderText = "SurName";    // Apellido del Usuario
            dataGridView1.Columns[4].HeaderText = "Department"; // Departamento Correspondiente
            dataGridView1.Columns[5].HeaderText = "Position";   // Posición  Correspondiente 
            dataGridView1.Columns[6].Visible = false;           // ID del Departamento 
            dataGridView1.Columns[7].Visible = false;           // ID de la Posición 
            dataGridView1.Columns[8].HeaderText = "Salary";     // Salario del Usuario
            dataGridView1.Columns[9].Visible = false;           // Si es Administrador o no
            dataGridView1.Columns[10].Visible = false;          // Contra del Usuario
            dataGridView1.Columns[11].Visible = false;          // Imagen del Usuario
            dataGridView1.Columns[12].Visible = false;          // Dirección del Usuario 
            dataGridView1.Columns[13].Visible = false;          // Cumpleaños  del Usuario 
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combofull)
            {
                cmbPosition.DataSource= dto.Positions.Where(x=>x.DepartmentID==
                Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<EmployeeDetailDTO> list= dto.Employees;
            if(txtUserNo.Text.Trim()!="")
                list=list.Where(x=>x.UserNo==Convert.ToInt32(txtUserNo.Text)).ToList();
            if (txtName.Text.Trim() != "")
                list = list.Where(x => x.Name.Contains(txtName.Text)).ToList();
            if (txtSurname.Text.Trim() != "")
                list = list.Where(x => x.SurName.Contains(txtSurname.Text)).ToList();
            if (cmbDepartment.SelectedIndex != -1)
                list = list.Where(x => x.DepartmentID 
                == Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            if (cmbPosition.SelectedIndex != -1)
                list = list.Where(x => x.PositionID
                == Convert.ToInt32(cmbPosition.SelectedValue)).ToList();
            dataGridView1.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanFilters();
            
        }

        private void CleanFilters()
        {
            txtUserNo.Clear();
            txtName.Clear();
            txtSurname.Clear();
            combofull = false;
            cmbDepartment.DataSource = dto.Departments;
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.SelectedIndex = -1;
            combofull = true;
            dataGridView1.DataSource = dto.Employees;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.UserNo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detail.Name = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.SurName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.DepartmentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
            detail.PositionID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            detail.Salary = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
            detail.IsAdmin = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
            detail.Password = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            detail.ImagePath = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            detail.Adress = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();            
            detail.Birthday = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex ].Cells[13].Value);                                                
            
        }
    }
}
