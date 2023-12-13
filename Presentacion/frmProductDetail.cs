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
    public partial class frmProductDetail : Form
    {
        private Product product = new Product();

        public frmProductDetail(Product product)
        {
            this.product = product;
            InitializeComponent();
        }

        private void frmProductDetail_Load(object sender, EventArgs e)
        {
            lblNameContainer.Text = product.name;
            lblCodeContainer.Text = product.code;
            lblDescriptionContainer.Text = product.description;
            lblBrandContainer.Text = product.brand.description;
            lblCategoryContainer.Text = product.category.description;
            lblUrlImageContainer.Text = product.imageUrl;
            lblPriceContainer.Text = product.price.ToString();

            loadImage(product.imageUrl);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProductBusiness productBusiness = new ProductBusiness();

            try
            {
                DialogResult response = MessageBox.Show("Quieres eliminar el producto codigo " + product.code + "?", "Eliminar seleccionado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (response == DialogResult.Yes)
                {
                    productBusiness.delete(product);
                }
                MessageBox.Show("Eliminado con exito!");
                Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmProducts productForm = new frmProducts(product);
            productForm.ShowDialog();
        }

        private void loadImage(string imageUrl)
        {
            try
            {
                pboProductImage.Load(imageUrl);
            }
            catch (Exception)
            {
                pboProductImage.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

    }
}
