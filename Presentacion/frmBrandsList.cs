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
    public partial class frmBrandsList : Form
    {
        private List<Brand> brandsList;

        public frmBrandsList()
        {
            InitializeComponent();
        }

        // Functions
        private void load()
        {
            BrandBusiness brandBusiness = new BrandBusiness();

            try
            {
                brandsList = brandBusiness.list();
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error al listar las marcas");
            }

            dgvBrands.DataSource = brandsList;
        }

        // Events
        private void frmBrands_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string filter = txtFilter.Text;
            List<Brand> filteredList;

            if (filter != "")
            {
                filteredList = brandsList.FindAll(brand => brand.description.ToLower().Contains(filter.ToLower()));
            }
            else
            {
                filteredList = brandsList;
            }

            dgvBrands.DataSource = null;
            dgvBrands.DataSource = filteredList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBrand addBrandForm = new frmBrand();
            addBrandForm.ShowDialog();
            load();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Brand selected = (Brand)dgvBrands.CurrentRow.DataBoundItem;
            frmBrand updateCategoryForm = new frmBrand(selected);
            updateCategoryForm.ShowDialog();
            load();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BrandBusiness brandBusiness = new BrandBusiness();
            Brand selected = (Brand)dgvBrands.CurrentRow.DataBoundItem;

            try
            {
                DialogResult response = MessageBox.Show("Deseas eliminar la marca " + selected.description.ToLower() + "?", "Eliminar marca selecionada", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (response == DialogResult.Yes)
                {
                    brandBusiness.delete(selected);
                    MessageBox.Show("Marca eliminada con exito!");
                }
                load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo borrar la marca seleccionada!");
            }
        }
    }
}
