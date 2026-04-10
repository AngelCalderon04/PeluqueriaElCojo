namespace PeluqueriaElCojo
{
    partial class peluqueriaelcojo
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chkCorteNormal = new System.Windows.Forms.CheckBox();
            this.chkDegradado = new System.Windows.Forms.CheckBox();
            this.numNivel = new System.Windows.Forms.NumericUpDown();
            this.chkAfeitado = new System.Windows.Forms.CheckBox();
            this.chkToalla = new System.Windows.Forms.CheckBox();
            this.chkCejas = new System.Windows.Forms.CheckBox();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.txtRecibo = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.CLIENTES = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstClientes = new System.Windows.Forms.ListBox();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numNivel)).BeginInit();
            this.CLIENTES.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // chkCorteNormal
            // 
            this.chkCorteNormal.AutoSize = true;
            this.chkCorteNormal.Location = new System.Drawing.Point(14, 45);
            this.chkCorteNormal.Name = "chkCorteNormal";
            this.chkCorteNormal.Size = new System.Drawing.Size(206, 25);
            this.chkCorteNormal.TabIndex = 6;
            this.chkCorteNormal.Text = "Corte Normal (RD$200)";
            this.chkCorteNormal.UseVisualStyleBackColor = true;
            // 
            // chkDegradado
            // 
            this.chkDegradado.AutoSize = true;
            this.chkDegradado.Location = new System.Drawing.Point(14, 87);
            this.chkDegradado.Name = "chkDegradado";
            this.chkDegradado.Size = new System.Drawing.Size(118, 25);
            this.chkDegradado.TabIndex = 7;
            this.chkDegradado.Text = "Degradado";
            this.chkDegradado.UseVisualStyleBackColor = true;
            // 
            // numNivel
            // 
            this.numNivel.Location = new System.Drawing.Point(139, 83);
            this.numNivel.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numNivel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNivel.Name = "numNivel";
            this.numNivel.Size = new System.Drawing.Size(54, 29);
            this.numNivel.TabIndex = 8;
            this.numNivel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNivel.ValueChanged += new System.EventHandler(this.numNivel_ValueChanged);
            // 
            // chkAfeitado
            // 
            this.chkAfeitado.AutoSize = true;
            this.chkAfeitado.Location = new System.Drawing.Point(14, 134);
            this.chkAfeitado.Name = "chkAfeitado";
            this.chkAfeitado.Size = new System.Drawing.Size(168, 25);
            this.chkAfeitado.TabIndex = 9;
            this.chkAfeitado.Text = "Afeitado (RD$150)";
            this.chkAfeitado.UseVisualStyleBackColor = true;
            // 
            // chkToalla
            // 
            this.chkToalla.AutoSize = true;
            this.chkToalla.Location = new System.Drawing.Point(14, 181);
            this.chkToalla.Name = "chkToalla";
            this.chkToalla.Size = new System.Drawing.Size(154, 25);
            this.chkToalla.TabIndex = 10;
            this.chkToalla.Text = "+ Toalla (RD$50)";
            this.chkToalla.UseVisualStyleBackColor = true;
            // 
            // chkCejas
            // 
            this.chkCejas.AutoSize = true;
            this.chkCejas.Location = new System.Drawing.Point(14, 234);
            this.chkCejas.Name = "chkCejas";
            this.chkCejas.Size = new System.Drawing.Size(136, 25);
            this.chkCejas.TabIndex = 11;
            this.chkCejas.Text = "Cejas (RD$75)";
            this.chkCejas.UseVisualStyleBackColor = true;
            // 
            // btnCobrar
            // 
            this.btnCobrar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobrar.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.ForeColor = System.Drawing.Color.White;
            this.btnCobrar.Location = new System.Drawing.Point(57, 321);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(125, 41);
            this.btnCobrar.TabIndex = 12;
            this.btnCobrar.Text = "COBRAR";
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // txtRecibo
            // 
            this.txtRecibo.BackColor = System.Drawing.Color.White;
            this.txtRecibo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRecibo.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecibo.ForeColor = System.Drawing.Color.Black;
            this.txtRecibo.Location = new System.Drawing.Point(6, 43);
            this.txtRecibo.Multiline = true;
            this.txtRecibo.Name = "txtRecibo";
            this.txtRecibo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRecibo.Size = new System.Drawing.Size(471, 444);
            this.txtRecibo.TabIndex = 13;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(133, 457);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(128, 28);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "TOTAL: RD$0";
            // 
            // CLIENTES
            // 
            this.CLIENTES.Controls.Add(this.comboBox1);
            this.CLIENTES.Controls.Add(this.cmbClientes);
            this.CLIENTES.Controls.Add(this.lstClientes);
            this.CLIENTES.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLIENTES.Location = new System.Drawing.Point(3, 71);
            this.CLIENTES.Name = "CLIENTES";
            this.CLIENTES.Size = new System.Drawing.Size(274, 451);
            this.CLIENTES.TabIndex = 15;
            this.CLIENTES.TabStop = false;
            this.CLIENTES.Text = "CLIENTES";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCobrar);
            this.groupBox2.Controls.Add(this.chkCejas);
            this.groupBox2.Controls.Add(this.chkToalla);
            this.groupBox2.Controls.Add(this.chkAfeitado);
            this.groupBox2.Controls.Add(this.numNivel);
            this.groupBox2.Controls.Add(this.chkDegradado);
            this.groupBox2.Controls.Add(this.chkCorteNormal);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(301, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 438);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SERVICIOS";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTotal);
            this.groupBox3.Controls.Add(this.txtRecibo);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(598, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(491, 488);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FACTURA";
            // 
            // lstClientes
            // 
            this.lstClientes.FormattingEnabled = true;
            this.lstClientes.ItemHeight = 28;
            this.lstClientes.Location = new System.Drawing.Point(25, 143);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.Size = new System.Drawing.Size(230, 116);
            this.lstClientes.TabIndex = 5;
            this.lstClientes.SelectedIndexChanged += new System.EventHandler(this.lstClientes_SelectedIndexChanged);
            // 
            // cmbClientes
            // 
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(25, 48);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(231, 36);
            this.cmbClientes.TabIndex = 6;
            this.cmbClientes.SelectedIndexChanged += new System.EventHandler(this.cmbClientes_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(35, 318);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(208, 36);
            this.comboBox1.TabIndex = 7;
            // 
            // peluqueriaelcojo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1101, 630);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CLIENTES);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "peluqueriaelcojo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numNivel)).EndInit();
            this.CLIENTES.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.CheckBox chkCorteNormal;
        private System.Windows.Forms.CheckBox chkDegradado;
        private System.Windows.Forms.NumericUpDown numNivel;
        private System.Windows.Forms.CheckBox chkAfeitado;
        private System.Windows.Forms.CheckBox chkToalla;
        private System.Windows.Forms.CheckBox chkCejas;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.TextBox txtRecibo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox CLIENTES;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.ListBox lstClientes;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

