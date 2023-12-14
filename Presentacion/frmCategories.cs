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
    public partial class frmCategories : Form
    {
        private List<Category> categoriesList;

        public frmCategories()
        {
            InitializeComponent();
        }

        // Functions
        private void load()
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();

            try
            {
                categoriesList = categoryBusiness.list();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            dgvCategories.DataSource = categoriesList;
        }
        
        // Events
        private void frmCategories_Load(object sender, EventArgs e)
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
            List<Category> filteredList;

            if(filter != "")
            {
                filteredList = categoriesList.FindAll(category => category.description.ToLower().Contains(filter.ToLower()));
            } else
            {
                filteredList = categoriesList;
            }

            dgvCategories.DataSource = null;
            dgvCategories.DataSource = filteredList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCategory addCategoryForm = new frmCategory();
            addCategoryForm.ShowDialog();
            load();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Category selected = (Category)dgvCategories.CurrentRow.DataBoundItem;
            frmCategory frmCategoryForm = new frmCategory(selected);
            frmCategoryForm.ShowDialog();
            load();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            Category selected = (Category)dgvCategories.CurrentRow.DataBoundItem;

            try
            {
                DialogResult response = MessageBox.Show("Deseas eliminar la categoria " + selected.description.ToLower() + "?", "Eliminar categoria selecionada", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
                if (response == DialogResult.Yes)
                {
                    categoryBusiness.delete(selected);
                    MessageBox.Show("Categoria eliminada con exito!");
                }
                load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
