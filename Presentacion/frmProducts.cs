using System;
using System.Windows.Forms;
using Business;
using Domain;
using Utilities;

namespace Presentacion
{
    public partial class frmProducts : Form
    {
        private Product product = null;
        private OpenFileDialog file = null;

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
                    PresentationUtilities.loadImage(product.imageUrl, pboProductPreview);
                    txtPrice.Text = product.price.ToString();
                    cboBrand.SelectedIndex = product.brand.id - 1;
                    cboCategory.SelectedIndex = product.category.id - 1;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error al intentar cargar las marcas y/o categorias para los desplegables");
            }
        }

        private void txtImageUrl_Leave(object sender, EventArgs e)
        {
            PresentationUtilities.loadImage(txtImageUrl.Text, pboProductPreview);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductBusiness productBusiness = new ProductBusiness();

            try
            {
                if (validateFields())
                {
                    return;
                }

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
                    PresentationUtilities.loadImage("", pboProductPreview);
                    productBusiness.update(product);
                    MessageBox.Show("Producto modificado con exito");
                } else
                {
                    productBusiness.add(product);
                    MessageBox.Show("Producto agregado con exito");
                }

                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error al intentar guardar el producto");
            }

        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            file = new OpenFileDialog();
            file.Filter = "Imagenes JPG,PNG|*.jpg;*.png";
            if (file.ShowDialog() == DialogResult.OK)
            {
                txtImageUrl.Text = file.FileName;
                PresentationUtilities.loadImage(file.FileName, pboProductPreview);
            }
        } 

        private bool validateFields()
        {
            bool isOneEmpty = txtCode.Text == "" || txtDescription.Text == "" || txtImageUrl.Text == "" || txtName.Text == "" || txtPrice.Text == "";

            if(isOneEmpty)
            {
                MessageBox.Show("Debes completar todos los campos");
                return true;
            }

            if(!PresentationUtilities.onlyNumbers(txtPrice.Text))
            {
                MessageBox.Show("Solo se pueden ingresar numeros en el precio");
                return true;
            }

            if(!PresentationUtilities.isProductCode(txtCode.Text))
            {
                MessageBox.Show("El codigo ingresado es invalido");
                return true;
            }

            return false;
        }
    }
}
