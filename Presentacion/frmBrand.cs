using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmBrand : Form
    {
        private Brand brand = null;

        public frmBrand()
        {
            InitializeComponent();
        }

        public frmBrand(Brand brand)
        {
            InitializeComponent();
            this.brand = brand;
            lblTitle.Text = "Modificar marca";
            btnAddBrand.Text = "Guardar";
        }


        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            BrandBusiness brandBusiness = new BrandBusiness();

            try
            {
                if (validateFields())
                {
                    return;
                }

                if (brand == null)
                {
                    brand = new Brand();
                }

                brand.description = txtDescription.Text;

                if (brand.id != 0)
                {
                    brandBusiness.update(brand);
                    MessageBox.Show("Marca actualizada con exito");
                }
                else
                {
                    brandBusiness.add(brand);
                    MessageBox.Show("Marca agregada con exito");
                }

                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error al intentar guardar la marca");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBrand_Load(object sender, EventArgs e)
        {
            if (brand != null)
            {
                txtDescription.Text = brand.description;
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
