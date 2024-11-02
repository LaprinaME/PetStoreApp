namespace PetStoreApp
{
    partial class AdminMenu
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.поставщикidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датапоставкиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номернакладнойDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.поставкиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.petStoreDataSet4 = new PetStoreApp.PetStoreDataSet4();
            this.поставкиTableAdapter = new PetStoreApp.PetStoreDataSet4TableAdapters.ПоставкиTableAdapter();
            this.petStoreDataSet5 = new PetStoreApp.PetStoreDataSet5();
            this.клиентыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.клиентыTableAdapter = new PetStoreApp.PetStoreDataSet5TableAdapters.КлиентыTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.поставкиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.petStoreDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.petStoreDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.клиентыBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(71, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(207, 281);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(359, 294);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(569, 314);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.поставщикidDataGridViewTextBoxColumn,
            this.датапоставкиDataGridViewTextBoxColumn,
            this.номернакладнойDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.поставкиBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(98, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(559, 150);
            this.dataGridView1.TabIndex = 5;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // поставщикidDataGridViewTextBoxColumn
            // 
            this.поставщикidDataGridViewTextBoxColumn.DataPropertyName = "Поставщик_id";
            this.поставщикidDataGridViewTextBoxColumn.HeaderText = "Поставщик_id";
            this.поставщикidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.поставщикidDataGridViewTextBoxColumn.Name = "поставщикidDataGridViewTextBoxColumn";
            this.поставщикidDataGridViewTextBoxColumn.Width = 125;
            // 
            // датапоставкиDataGridViewTextBoxColumn
            // 
            this.датапоставкиDataGridViewTextBoxColumn.DataPropertyName = "Дата_поставки";
            this.датапоставкиDataGridViewTextBoxColumn.HeaderText = "Дата_поставки";
            this.датапоставкиDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.датапоставкиDataGridViewTextBoxColumn.Name = "датапоставкиDataGridViewTextBoxColumn";
            this.датапоставкиDataGridViewTextBoxColumn.Width = 125;
            // 
            // номернакладнойDataGridViewTextBoxColumn
            // 
            this.номернакладнойDataGridViewTextBoxColumn.DataPropertyName = "Номер_накладной";
            this.номернакладнойDataGridViewTextBoxColumn.HeaderText = "Номер_накладной";
            this.номернакладнойDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.номернакладнойDataGridViewTextBoxColumn.Name = "номернакладнойDataGridViewTextBoxColumn";
            this.номернакладнойDataGridViewTextBoxColumn.Width = 125;
            // 
            // поставкиBindingSource
            // 
            this.поставкиBindingSource.DataMember = "Поставки";
            this.поставкиBindingSource.DataSource = this.petStoreDataSet4;
            // 
            // petStoreDataSet4
            // 
            this.petStoreDataSet4.DataSetName = "PetStoreDataSet4";
            this.petStoreDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // поставкиTableAdapter
            // 
            this.поставкиTableAdapter.ClearBeforeFill = true;
            // 
            // petStoreDataSet5
            // 
            this.petStoreDataSet5.DataSetName = "PetStoreDataSet5";
            this.petStoreDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // клиентыBindingSource
            // 
            this.клиентыBindingSource.DataMember = "Клиенты";
            this.клиентыBindingSource.DataSource = this.petStoreDataSet5;
            // 
            // клиентыTableAdapter
            // 
            this.клиентыTableAdapter.ClearBeforeFill = true;
            // 
            // AdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 397);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "AdminMenu";
            this.Text = "AdminMenu";
            this.Load += new System.EventHandler(this.AdminMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.поставкиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.petStoreDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.petStoreDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.клиентыBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private PetStoreDataSet4 petStoreDataSet4;
        private System.Windows.Forms.BindingSource поставкиBindingSource;
        private PetStoreDataSet4TableAdapters.ПоставкиTableAdapter поставкиTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn поставщикidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датапоставкиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номернакладнойDataGridViewTextBoxColumn;
        private PetStoreDataSet5 petStoreDataSet5;
        private System.Windows.Forms.BindingSource клиентыBindingSource;
        private PetStoreDataSet5TableAdapters.КлиентыTableAdapter клиентыTableAdapter;
    }
}