namespace PetStoreApp
{
    partial class SellerMenu
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.артикулDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.названиеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.категорияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.брендDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.животноеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.описаниеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.составDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.единицаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.стоимостьDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.количествонаскладеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Единица = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.товарыBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.petStoreDataSet1 = new PetStoreApp.PetStoreDataSet1();
            this.petStoreDataSet = new PetStoreApp.PetStoreDataSet();
            this.товарыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.товарыTableAdapter = new PetStoreApp.PetStoreDataSetTableAdapters.ТоварыTableAdapter();
            this.товарыTableAdapter1 = new PetStoreApp.PetStoreDataSet1TableAdapters.ТоварыTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.товарыBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.petStoreDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.petStoreDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.товарыBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(48, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 55);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить товар";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.артикулDataGridViewTextBoxColumn,
            this.названиеDataGridViewTextBoxColumn,
            this.категорияDataGridViewTextBoxColumn,
            this.брендDataGridViewTextBoxColumn,
            this.животноеDataGridViewTextBoxColumn,
            this.описаниеDataGridViewTextBoxColumn,
            this.составDataGridViewTextBoxColumn,
            this.единицаDataGridViewTextBoxColumn,
            this.стоимостьDataGridViewTextBoxColumn,
            this.количествонаскладеDataGridViewTextBoxColumn,
            this.Единица});
            this.dataGridView1.DataSource = this.товарыBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(48, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(687, 150);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // артикулDataGridViewTextBoxColumn
            // 
            this.артикулDataGridViewTextBoxColumn.DataPropertyName = "Артикул";
            this.артикулDataGridViewTextBoxColumn.HeaderText = "Артикул";
            this.артикулDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.артикулDataGridViewTextBoxColumn.Name = "артикулDataGridViewTextBoxColumn";
            this.артикулDataGridViewTextBoxColumn.Width = 125;
            // 
            // названиеDataGridViewTextBoxColumn
            // 
            this.названиеDataGridViewTextBoxColumn.DataPropertyName = "Название";
            this.названиеDataGridViewTextBoxColumn.HeaderText = "Название";
            this.названиеDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.названиеDataGridViewTextBoxColumn.Name = "названиеDataGridViewTextBoxColumn";
            this.названиеDataGridViewTextBoxColumn.Width = 125;
            // 
            // категорияDataGridViewTextBoxColumn
            // 
            this.категорияDataGridViewTextBoxColumn.DataPropertyName = "Категория";
            this.категорияDataGridViewTextBoxColumn.HeaderText = "Категория";
            this.категорияDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.категорияDataGridViewTextBoxColumn.Name = "категорияDataGridViewTextBoxColumn";
            this.категорияDataGridViewTextBoxColumn.Width = 125;
            // 
            // брендDataGridViewTextBoxColumn
            // 
            this.брендDataGridViewTextBoxColumn.DataPropertyName = "Бренд";
            this.брендDataGridViewTextBoxColumn.HeaderText = "Бренд";
            this.брендDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.брендDataGridViewTextBoxColumn.Name = "брендDataGridViewTextBoxColumn";
            this.брендDataGridViewTextBoxColumn.Width = 125;
            // 
            // животноеDataGridViewTextBoxColumn
            // 
            this.животноеDataGridViewTextBoxColumn.DataPropertyName = "Животное";
            this.животноеDataGridViewTextBoxColumn.HeaderText = "Животное";
            this.животноеDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.животноеDataGridViewTextBoxColumn.Name = "животноеDataGridViewTextBoxColumn";
            this.животноеDataGridViewTextBoxColumn.Width = 125;
            // 
            // описаниеDataGridViewTextBoxColumn
            // 
            this.описаниеDataGridViewTextBoxColumn.DataPropertyName = "Описание";
            this.описаниеDataGridViewTextBoxColumn.HeaderText = "Описание";
            this.описаниеDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.описаниеDataGridViewTextBoxColumn.Name = "описаниеDataGridViewTextBoxColumn";
            this.описаниеDataGridViewTextBoxColumn.Width = 125;
            // 
            // составDataGridViewTextBoxColumn
            // 
            this.составDataGridViewTextBoxColumn.DataPropertyName = "Состав";
            this.составDataGridViewTextBoxColumn.HeaderText = "Состав";
            this.составDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.составDataGridViewTextBoxColumn.Name = "составDataGridViewTextBoxColumn";
            this.составDataGridViewTextBoxColumn.Width = 125;
            // 
            // единицаDataGridViewTextBoxColumn
            // 
            this.единицаDataGridViewTextBoxColumn.DataPropertyName = "Единица";
            this.единицаDataGridViewTextBoxColumn.HeaderText = "Единица";
            this.единицаDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.единицаDataGridViewTextBoxColumn.Name = "единицаDataGridViewTextBoxColumn";
            this.единицаDataGridViewTextBoxColumn.Width = 125;
            // 
            // стоимостьDataGridViewTextBoxColumn
            // 
            this.стоимостьDataGridViewTextBoxColumn.DataPropertyName = "Стоимость";
            this.стоимостьDataGridViewTextBoxColumn.HeaderText = "Стоимость";
            this.стоимостьDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.стоимостьDataGridViewTextBoxColumn.Name = "стоимостьDataGridViewTextBoxColumn";
            this.стоимостьDataGridViewTextBoxColumn.Width = 125;
            // 
            // количествонаскладеDataGridViewTextBoxColumn
            // 
            this.количествонаскладеDataGridViewTextBoxColumn.DataPropertyName = "Количество_на_складе";
            this.количествонаскладеDataGridViewTextBoxColumn.HeaderText = "Количество_на_складе";
            this.количествонаскладеDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.количествонаскладеDataGridViewTextBoxColumn.Name = "количествонаскладеDataGridViewTextBoxColumn";
            this.количествонаскладеDataGridViewTextBoxColumn.Width = 125;
            // 
            // Единица
            // 
            this.Единица.DataPropertyName = "Единица";
            this.Единица.HeaderText = "Единица";
            this.Единица.MinimumWidth = 6;
            this.Единица.Name = "Единица";
            this.Единица.Width = 125;
            // 
            // товарыBindingSource1
            // 
            this.товарыBindingSource1.DataMember = "Товары";
            this.товарыBindingSource1.DataSource = this.petStoreDataSet1;
            // 
            // petStoreDataSet1
            // 
            this.petStoreDataSet1.DataSetName = "PetStoreDataSet1";
            this.petStoreDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // petStoreDataSet
            // 
            this.petStoreDataSet.DataSetName = "PetStoreDataSet";
            this.petStoreDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // товарыBindingSource
            // 
            this.товарыBindingSource.DataMember = "Товары";
            this.товарыBindingSource.DataSource = this.petStoreDataSet;
            // 
            // товарыTableAdapter
            // 
            this.товарыTableAdapter.ClearBeforeFill = true;
            // 
            // товарыTableAdapter1
            // 
            this.товарыTableAdapter1.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(280, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(220, 55);
            this.button2.TabIndex = 2;
            this.button2.Text = "Удалить товар";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(280, 351);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(220, 55);
            this.button3.TabIndex = 3;
            this.button3.Text = "Сохранить изменения";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(515, 243);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(220, 55);
            this.button4.TabIndex = 4;
            this.button4.Text = "Обновить данные";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(363, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Товары";
            // 
            // SellerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(821, 451);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "SellerMenu";
            this.Text = "SellerMenu";
            this.Load += new System.EventHandler(this.SellerMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.товарыBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.petStoreDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.petStoreDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.товарыBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private PetStoreDataSet petStoreDataSet;
        private System.Windows.Forms.BindingSource товарыBindingSource;
        private PetStoreDataSetTableAdapters.ТоварыTableAdapter товарыTableAdapter;
        private PetStoreDataSet1 petStoreDataSet1;
        private System.Windows.Forms.BindingSource товарыBindingSource1;
        private PetStoreDataSet1TableAdapters.ТоварыTableAdapter товарыTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn артикулDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn названиеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn категорияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn брендDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn животноеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn описаниеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn составDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn единицаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn стоимостьDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn количествонаскладеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Единица;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
    }
}