namespace spotify_data
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataViewShowData = new DataGridView();
            BtnSelect = new Button();
            ((System.ComponentModel.ISupportInitialize)DataViewShowData).BeginInit();
            SuspendLayout();
            // 
            // DataViewShowData
            // 
            DataViewShowData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataViewShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataViewShowData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DataViewShowData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataViewShowData.Location = new Point(316, 24);
            DataViewShowData.Name = "DataViewShowData";
            DataViewShowData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataViewShowData.Size = new Size(450, 414);
            DataViewShowData.TabIndex = 0;
            DataViewShowData.CellContentClick += DataViewShowData_CellContentClickAsync;
            // 
            // BtnSelect
            // 
            BtnSelect.Location = new Point(114, 214);
            BtnSelect.Name = "BtnSelect";
            BtnSelect.Size = new Size(75, 23);
            BtnSelect.TabIndex = 1;
            BtnSelect.Text = "select";
            BtnSelect.UseVisualStyleBackColor = true;
            BtnSelect.Click += BtnSelect_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnSelect);
            Controls.Add(DataViewShowData);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)DataViewShowData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DataViewShowData;
        private Button BtnSelect;
    }
}
