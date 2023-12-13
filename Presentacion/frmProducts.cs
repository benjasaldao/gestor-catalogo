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
using Business;

namespace Presentacion
{
    public partial class frmProducts : Form
    {
        private Product product = null;

        public frmProducts()
        {
            InitializeComponent();
        }

        public frmProducts(Product product)
        {
            InitializeComponent();
            this.product = product;
            lblTitle.Text = "Modificar producto";
            btnAddProduct.Text = "Guardar";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            BrandBusiness brandBusiness = new BrandBusiness();

            try
            {
                cboBrand.DataSource = brandBusiness.list();
                cboBrand.ValueMember = "Id";
                cboBrand.DisplayMember = "Description";

                cboCategory.DataSource = categoryBusiness.list();
                cboCategory.ValueMember = "Id";
                cboCategory.DisplayMember = "Description";

                if (product != null)
                {
                    txtCode.Text = product.code;
                    txtName.Text = product.name;
                    txtDescription.Text = product.description;
                    txtImageUrl.Text = product.imageUrl;
                    loadImage(product.imageUrl);
                    txtPrice.Text = product.price.ToString();
                    cboBrand.SelectedIndex = product.brand.id - 1;
                    cboCategory.SelectedIndex = product.category.id - 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadImage(string imageUrl)
        {
            try
            {
                pboProductPreview.Load(imageUrl);
            }
            catch (Exception)
            {
                pboProductPreview.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        private void txtImageUrl_Leave(object sender, EventArgs e)
        {
            loadImage(txtImageUrl.Text);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductBusiness productBusiness = new ProductBusiness();

            try
            {
                if (product == null)
                {
                    product = new Product();
                }
                product.code = txtCode.Text;
                product.name = txtName.Text;
                product.description = txtDescription.Text;
                product.imageUrl = txtImageUrl.Text;
                product.price = decimal.Parse(txtPrice.Text);
                product.brand = (Brand)cboBrand.SelectedItem;
                product.category = (Category)cboCategory.SelectedItem;

                if (product.id != 0)
                {
                    productBusiness.update(product);
                    MessageBox.Show("Producto modificado con exito");
                } else
                {
                    productBusiness.add(product);
                    MessageBox.Show("Producto agregado con exito");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
