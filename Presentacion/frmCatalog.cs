using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Business;
using Domain;
using Utilities;

namespace Presentacion
{
    public partial class frmCatalogo : Form
    {
        private List<Product> productList;

        public frmCatalogo()
        {
            InitializeComponent();
        }

        // Event functions
        private void frmCatalogo_Load(object sender, EventArgs e)
        {
            load();
            cboField.Items.Add("Precio");
            cboField.Items.Add("Marca");
            cboField.Items.Add("Categoria");
            cboField.Items.Add("Codigo");
            cboField.Items.Add("Descripcion");
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvProducts.CurrentRow != null)
            {
                Product selected = (Product)dgvProducts.CurrentRow.DataBoundItem;
                PresentationUtilities.loadImage(selected.imageUrl, pboProduct);
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
            PresentationUtilities.loadImage("", pboProduct);
            productDetalForm.ShowDialog();
            load();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            frmCategoriesList categoriesForm = new frmCategoriesList();
            categoriesForm.ShowDialog();
            load();
        }

        private void btnBrands_Click(object sender, EventArgs e)
        {
            frmBrandsList brandsForms = new frmBrandsList();
            brandsForms.ShowDialog();
            load();
        }

        private void cboField_SelectedIndexChanged(object sender, EventArgs e)
        {
            string option = cboField.Text;

            BrandBusiness brandBusiness = new BrandBusiness();
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            txtAdvancedFilter.Enabled = true;
            try
            {
                switch (option)
                {
                    case "Marca":
                        cboCriterion.Items.Clear();
                        List<Brand> brandItems = brandBusiness.list();

                        foreach (Brand item in brandItems)
                        {
                            cboCriterion.Items.Add(item.ToString());
                        }

                        txtAdvancedFilter.Enabled = false;

                        break;
                    case "Categoria":
                        cboCriterion.Items.Clear();
                        List<Category> categoryItems = categoryBusiness.list();

                        foreach (Category item in categoryItems)
                        {
                            cboCriterion.Items.Add(item.ToString());
                        }

                        txtAdvancedFilter.Enabled = false;

                        break;
                    case "Precio":
                        cboCriterion.Items.Clear();
                        cboCriterion.Items.Add("Mayor a");
                        cboCriterion.Items.Add("Menor a");
                        break;
                    case "Codigo":
                        cboCriterion.Items.Clear();
                        cboCriterion.Items.Add("Letra");
                        cboCriterion.Items.Add("Numero");
                        cboCriterion.Items.Add("Codigo completo");
                        break;
                    default:
                        cboCriterion.Items.Clear();
                        cboCriterion.Items.Add("Contiene");
                        cboCriterion.Items.Add("Termina con");
                        cboCriterion.Items.Add("Empieza con");
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error al intentar cargar las marcas y/o categorias para los filtros");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ProductBusiness productBusiness = new ProductBusiness();

            try
            {
                if(validateFields())
                {
                    return;
                }
                string field = cboField.Text;
                string criterion = cboCriterion.Text;
                string filter = txtAdvancedFilter.Text;

                dgvProducts.DataSource = productBusiness.filter(field, criterion, filter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al intetar realizar la busqueda!");
            }
        }

        private void btnCleanFilter_Click(object sender, EventArgs e)
        {
            dgvProducts.DataSource = productList;
            cboCriterion.SelectedIndex = -1;
            cboField.SelectedIndex = -1;
            txtAdvancedFilter.Text = "";
        }

        private void cboCriterion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboCriterion.Text == "Letra")
            {
                txtAdvancedFilter.MaxLength = 1;
            } else if (cboCriterion.Text == "Numero")
            {
                txtAdvancedFilter.MaxLength = 2;
            } else
            {
                txtAdvancedFilter.MaxLength = 32767;
            }
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
                MessageBox.Show("Hubo un error al listar los productos!");
            }

            dgvProducts.DataSource = productList;
            hideColumns();
            PresentationUtilities.loadImage(productList[0].imageUrl, pboProduct);
        }

        private void hideColumns()
        {
            dgvProducts.Columns["imageUrl"].Visible = false;
            dgvProducts.Columns["id"].Visible = false;
        }

        private bool validateFields()
        {
            if (cboField.SelectedIndex < 0)
            {
                MessageBox.Show("No se selecciono el campo por el cual filtrar!");
                return true;
            }
            if (cboCriterion.SelectedIndex < 0)
            {
                MessageBox.Show("No se selecciono el criterio por el cual filtrar!");
                return true;
            }

            if (cboField.Text == "Precio" || cboCriterion.Text == "Numero")
            {
                if (string.IsNullOrEmpty(txtAdvancedFilter.Text))
                {
                    MessageBox.Show("Debes cargar algun numero en el filtro");
                    return true;
                }
                if (!PresentationUtilities.onlyNumbers(txtAdvancedFilter.Text))
                {
                    MessageBox.Show("Solo numeros!");
                    return true;
                }
            }

            if (cboCriterion.Text == "Letra")
            {
                if (PresentationUtilities.onlyNumbers(txtAdvancedFilter.Text))
                {
                    MessageBox.Show("Solo ingresar letras en el campo filtro!");
                    return true;
                }
            }

            return false;
        }
    }
}
