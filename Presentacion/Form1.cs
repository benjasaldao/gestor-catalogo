using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Domain;

namespace Presentacion
{
    public partial class frmCatalogo : Form
    {
        private List<Product> productList;

        public frmCatalogo()
        {
            InitializeComponent();
        }

        // Events
        private void frmCatalogo_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvProducts.CurrentRow != null)
            {
                Product selected = (Product)dgvProducts.CurrentRow.DataBoundItem;
                loadImage(selected.imageUrl);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProducts productForm = new frmProducts();
            productForm.ShowDialog();
            load();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string filter = txtFilter.Text;
            List<Product> filteredList;

            if (filter != "")
            {
                filteredList = productList.FindAll(product => product.name.ToLower().Contains(filter.ToLower()));
            } else
            {
                filteredList = productList;
            }

            dgvProducts.DataSource = null;
            dgvProducts.DataSource = filteredList;
            hideColumns();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Product selected = (Product)dgvProducts.CurrentRow.DataBoundItem;
            frmProductDetail productDetalForm = new frmProductDetail(selected);
            productDetalForm.ShowDialog();
            load();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            frmCategories categoriesForm = new frmCategories();
            categoriesForm.ShowDialog();
        }

        private void btnBrands_Click(object sender, EventArgs e)
        {
            frmBrands brandsForms = new frmBrands();
            brandsForms.ShowDialog();
        }


        // Functions
        private void load()
        {
            ProductBusiness business = new ProductBusiness();

            try
            {
                productList = business.list();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            dgvProducts.DataSource = productList;
            hideColumns();
            loadImage(productList[0].imageUrl);
        }

        private void hideColumns()
        {
            dgvProducts.Columns["imageUrl"].Visible = false;
            dgvProducts.Columns["id"].Visible = false;
        }

        private void loadImage(string imageUrl)
        {
            try
            {
                pboProduct.Load(imageUrl);
            }
            catch (Exception)
            {
                pboProduct.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

    }
}
