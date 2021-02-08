using AppUserZeroCode.Datos;
using AppUserZeroCode.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppUserZeroCode.Presentacion
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            view_user();
        }

        int idUsuario;

        private void btnInsert_Click(object sender, EventArgs e)
        {
            pnlUser.Visible = true;
            pnlUser.Dock = DockStyle.Fill;
            btnSave.Visible = true;
            btnSaveAll.Visible = false;
            txtUsuario.Clear();
            txtPass.Clear();
        }

        private void pctIcono_Click(object sender, EventArgs e)
        {
            ofdIcono.InitialDirectory = "";
            ofdIcono.Filter = "Imagenes | *.jpg;*.png";
            ofdIcono.FilterIndex = 2;
            ofdIcono.Title = "Cargador de Imagenes";

            if(ofdIcono.ShowDialog()== DialogResult.OK)
            {
                pctIcono.BackgroundImage = null;
                pctIcono.Image = new Bitmap(ofdIcono.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "")
            {
                if (txtPass.Text != "") {
                    insertar_user();
                    view_user();
                }
                else {
                    MessageBox.Show("Ingresa una Contraseña","Sin Contraseña",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else {
                MessageBox.Show("Ingresa un Usuario", "Sin Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void insertar_user()
        {
            lUsers dt = new lUsers();
            dUsers methods = new dUsers();
            dt.usuarios = txtUsuario.Text;
            dt.pass = txtPass.Text;
            MemoryStream ms = new MemoryStream();
            pctIcono.Image.Save(ms, pctIcono.Image.RawFormat);
            dt.icono = ms.GetBuffer();
            dt.estado = "ACTIVO";
            if (methods.insert(dt))
            {
                MessageBox.Show("Usuario Registrado", "Registro Correcto");
                pnlUser.Visible = false;
                pnlUser.Dock = DockStyle.None;
            }

        }
        private void view_user()
        {
            DataTable dt;
            dUsers methods = new dUsers();
            dt = methods.view();
            dtgList.DataSource = dt;

        }

        private void dtgList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idUsuario = Convert.ToInt32(dtgList.SelectedCells[2].Value.ToString());

            if (e.ColumnIndex == this.dtgList.Columns["Delete"].Index)
            {
                DialogResult res;
                res= MessageBox.Show("¿Quieres Eliminar el Registro?", "Eliminando Registro",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    delete_user();
                    view_user();
                }
            }

            if (e.ColumnIndex==this.dtgList.Columns["Edit"].Index)
            {
                
                txtUsuario.Text = dtgList.SelectedCells[3].Value.ToString();
                txtPass.Text = dtgList.SelectedCells[4].Value.ToString();
                pctIcono.BackgroundImage = null;
                byte[] bits = (Byte[])dtgList.SelectedCells[5].Value;
                MemoryStream ms = new MemoryStream(bits);
                pctIcono.Image = Image.FromStream(ms);

                pnlUser.Visible = true;
                pnlUser.Dock = DockStyle.Fill;
                btnSave.Visible = false;
                btnSaveAll.Visible = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlUser.Visible = false;
            pnlUser.Dock = DockStyle.None;
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            editar_user();
            view_user();
        }
        private void editar_user()
        {
            lUsers dt = new lUsers();
            dUsers methods = new dUsers();
            dt.idusarios = idUsuario;
            dt.usuarios = txtUsuario.Text;
            dt.pass = txtPass.Text;
            MemoryStream ms = new MemoryStream();
            pctIcono.Image.Save(ms, pctIcono.Image.RawFormat);
            dt.icono = ms.GetBuffer();
            dt.estado = "ACTIVO";
            if (methods.edit(dt))
            {
                MessageBox.Show("Usuario Actualizado", "Registro Correcto");
                pnlUser.Visible = false;
                pnlUser.Dock = DockStyle.None;
            }

        }

        private void delete_user()
        {
            lUsers dt = new lUsers();
            dUsers methods = new dUsers();
            dt.idusarios = idUsuario;
            
            if (methods.delete(dt))
            {
                MessageBox.Show("Usuario Eliminado", "Eliminacion Correcto");
                pnlUser.Visible = false;
                pnlUser.Dock = DockStyle.None;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void search_user(string search)
        {

            DataTable dt;
            dUsers methods = new dUsers();
            dt = methods.search(search);
            dtgList.DataSource = dt;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            search_user(txtSearch.Text);
        }
    }
}
