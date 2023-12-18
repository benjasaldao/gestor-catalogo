using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Business;

namespace Presentacion
{
    public partial class frmCategory : Form
    {
        private Category category = null;

        public frmCategory()
        {
            InitializeComponent();
        }

        public frmCategory(Category category)
        {
            InitializeComponent();
            this.category = category;
            lblTitle.Text = "Modificar categoria";
            btnAddCategory.Text = "Guardar";
        }


        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();

            try
            {
                if(validateFields())
                {
                    return;
                }

                if (category == null)
                {
                    category = new Category();
                }

                category.description = txtDescription.Text;

                if (category.id != 0)
                {
                    categoryBusiness.update(category);
                    MessageBox.Show("Categoria actualizada con exito");
                } else
                {
                    categoryBusiness.add(category);
                    MessageBox.Show("Categoria agregada con exito");
                }

                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error al intentar guardar la categoria!");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            if (category != null)
            {
                txtDescription.Text = category.description;
            }
        }

        private bool validateFields()
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("El campo no puede estar vacio!");
                return true;
            } 
            return false;
        }
    }
}
