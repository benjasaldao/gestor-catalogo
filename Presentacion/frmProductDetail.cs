using Business;
using Domain;
using System;
using System.Windows.Forms;
using Utilities;

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
            txtUrlImage.Text = product.imageUrl;
            lblPriceContainer.Text = product.price.ToString();

            PresentationUtilities.loadImage(product.imageUrl, pboProductImage);
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
                    PresentationUtilities.loadImage("", pboProductImage);
                    productBusiness.delete(product);
                    MessageBox.Show("Producto eliminado con exito!");
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error al intentar borrar el producto!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmProducts productForm = new frmProducts(product);
            PresentationUtilities.loadImage("", pboProductImage);
            productForm.ShowDialog();
            PresentationUtilities.loadImage(product.imageUrl, pboProductImage);
        }
    }
}
