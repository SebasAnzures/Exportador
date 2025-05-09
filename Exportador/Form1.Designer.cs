namespace Exportador
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
            gd = new DataGridView();
            btMostrar = new Button();
            btExport = new Button();
            btImportar = new Button();
            ((System.ComponentModel.ISupportInitialize)gd).BeginInit();
            SuspendLayout();
            // 
            // gd
            // 
            gd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gd.Location = new Point(12, 12);
            gd.Name = "gd";
            gd.Size = new Size(776, 315);
            gd.TabIndex = 0;
            // 
            // btMostrar
            // 
            btMostrar.Location = new Point(109, 373);
            btMostrar.Name = "btMostrar";
            btMostrar.Size = new Size(75, 23);
            btMostrar.TabIndex = 1;
            btMostrar.Text = "Mostrar";
            btMostrar.UseVisualStyleBackColor = true;
            btMostrar.Click += btMostrar_Click;
            // 
            // btExport
            // 
            btExport.Location = new Point(190, 373);
            btExport.Name = "btExport";
            btExport.Size = new Size(75, 23);
            btExport.TabIndex = 2;
            btExport.Text = "Exportar";
            btExport.UseVisualStyleBackColor = true;
            btExport.Click += btExport_Click;
            // 
            // btImportar
            // 
            btImportar.Location = new Point(271, 373);
            btImportar.Name = "btImportar";
            btImportar.Size = new Size(75, 23);
            btImportar.TabIndex = 3;
            btImportar.Text = "Importar";
            btImportar.UseVisualStyleBackColor = true;
            btImportar.Click += btImportar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btImportar);
            Controls.Add(btExport);
            Controls.Add(btMostrar);
            Controls.Add(gd);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)gd).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gd;
        private Button btMostrar;
        private Button btExport;
        private Button btImportar;
    }
}
