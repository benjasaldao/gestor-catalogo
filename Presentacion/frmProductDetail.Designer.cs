namespace Presentacion
{
    partial class frmProductDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.pboProductImage = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblUrlImage = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblNameContainer = new System.Windows.Forms.Label();
            this.lblCodeContainer = new System.Windows.Forms.Label();
            this.lblDescriptionContainer = new System.Windows.Forms.Label();
            this.lblBrandContainer = new System.Windows.Forms.Label();
            this.lblCategoryContainer = new System.Windows.Forms.Label();
            this.lblPriceContainer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtUrlImage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboProductImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(449, 390);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pboProductImage
            // 
            this.pboProductImage.Location = new System.Drawing.Point(337, 56);
            this.pboProductImage.Name = "pboProductImage";
            this.pboProductImage.Size = new System.Drawing.Size(312, 293);
            this.pboProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboProductImage.TabIndex = 1;
            this.pboProductImage.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(292, 390);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Borrar producto";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblName.Location = new System.Drawing.Point(78, 78);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(66, 17);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Nombre: ";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCode.Location = new System.Drawing.Point(86, 116);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(56, 17);
            this.lblCode.TabIndex = 4;
            this.lblCode.Text = "Codigo:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDescription.Location = new System.Drawing.Point(58, 154);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(86, 17);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Descripcion:";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblBrand.Location = new System.Drawing.Point(89, 192);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(51, 17);
            this.lblBrand.TabIndex = 6;
            this.lblBrand.Text = "Marca:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCategory.Location = new System.Drawing.Point(69, 230);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(73, 17);
            this.lblCategory.TabIndex = 7;
            this.lblCategory.Text = "Categoria:";
            // 
            // lblUrlImage
            // 
            this.lblUrlImage.AutoSize = true;
            this.lblUrlImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUrlImage.Location = new System.Drawing.Point(25, 268);
            this.lblUrlImage.Name = "lblUrlImage";
            this.lblUrlImage.Size = new System.Drawing.Size(115, 17);
            this.lblUrlImage.TabIndex = 8;
            this.lblUrlImage.Text = "Url de la imagen:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPrice.Location = new System.Drawing.Point(86, 332);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(52, 17);
            this.lblPrice.TabIndex = 9;
            this.lblPrice.Text = "Precio:";
            // 
            // lblNameContainer
            // 
            this.lblNameContainer.AutoSize = true;
            this.lblNameContainer.Location = new System.Drawing.Point(148, 80);
            this.lblNameContainer.Name = "lblNameContainer";
            this.lblNameContainer.Size = new System.Drawing.Size(0, 13);
            this.lblNameContainer.TabIndex = 10;
            // 
            // lblCodeContainer
            // 
            this.lblCodeContainer.AutoSize = true;
            this.lblCodeContainer.Location = new System.Drawing.Point(148, 122);
            this.lblCodeContainer.Name = "lblCodeContainer";
            this.lblCodeContainer.Size = new System.Drawing.Size(0, 13);
            this.lblCodeContainer.TabIndex = 11;
            // 
            // lblDescriptionContainer
            // 
            this.lblDescriptionContainer.AutoSize = true;
            this.lblDescriptionContainer.Location = new System.Drawing.Point(148, 160);
            this.lblDescriptionContainer.Name = "lblDescriptionContainer";
            this.lblDescriptionContainer.Size = new System.Drawing.Size(0, 13);
            this.lblDescriptionContainer.TabIndex = 12;
            // 
            // lblBrandContainer
            // 
            this.lblBrandContainer.AutoSize = true;
            this.lblBrandContainer.Location = new System.Drawing.Point(148, 196);
            this.lblBrandContainer.Name = "lblBrandContainer";
            this.lblBrandContainer.Size = new System.Drawing.Size(0, 13);
            this.lblBrandContainer.TabIndex = 13;
            // 
            // lblCategoryContainer
            // 
            this.lblCategoryContainer.AutoSize = true;
            this.lblCategoryContainer.Location = new System.Drawing.Point(148, 234);
            this.lblCategoryContainer.Name = "lblCategoryContainer";
            this.lblCategoryContainer.Size = new System.Drawing.Size(0, 13);
            this.lblCategoryContainer.TabIndex = 14;
            // 
            // lblPriceContainer
            // 
            this.lblPriceContainer.AutoSize = true;
            this.lblPriceContainer.Location = new System.Drawing.Point(142, 336);
            this.lblPriceContainer.Name = "lblPriceContainer";
            this.lblPriceContainer.Size = new System.Drawing.Size(0, 13);
            this.lblPriceContainer.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 22);
            this.label1.TabIndex = 17;
            this.label1.Text = "Detalle articulo";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(135, 390);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 23);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Modificar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtUrlImage
            // 
            this.txtUrlImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtUrlImage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUrlImage.Enabled = false;
            this.txtUrlImage.Location = new System.Drawing.Point(146, 268);
            this.txtUrlImage.Multiline = true;
            this.txtUrlImage.Name = "txtUrlImage";
            this.txtUrlImage.Size = new System.Drawing.Size(176, 53);
            this.txtUrlImage.TabIndex = 19;
            // 
            // frmProductDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(684, 450);
            this.Controls.Add(this.txtUrlImage);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPriceContainer);
            this.Controls.Add(this.lblCategoryContainer);
            this.Controls.Add(this.lblBrandContainer);
            this.Controls.Add(this.lblDescriptionContainer);
            this.Controls.Add(this.lblCodeContainer);
            this.Controls.Add(this.lblNameContainer);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblUrlImage);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.pboProductImage);
            this.Controls.Add(this.btnClose);
            this.Name = "frmProductDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmProductDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboProductImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pboProductImage;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblUrlImage;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblNameContainer;
        private System.Windows.Forms.Label lblCodeContainer;
        private System.Windows.Forms.Label lblDescriptionContainer;
        private System.Windows.Forms.Label lblBrandContainer;
        private System.Windows.Forms.Label lblCategoryContainer;
        private System.Windows.Forms.Label lblPriceContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtUrlImage;
    }
}