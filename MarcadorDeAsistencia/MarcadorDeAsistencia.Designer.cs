namespace MarcadorDeAsistencia
{
    partial class MarcadorDeAsistencia
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbCamera = new System.Windows.Forms.PictureBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.gbTipoAsistencia = new System.Windows.Forms.GroupBox();
            this.btnFinDescanso = new System.Windows.Forms.Button();
            this.btnInicioDescanso = new System.Windows.Forms.Button();
            this.btnSalida = new System.Windows.Forms.Button();
            this.btnEntrada = new System.Windows.Forms.Button();
            this.timerHora = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnValidar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblValidacion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).BeginInit();
            this.gbTipoAsistencia.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbCamera
            // 
            this.pbCamera.Location = new System.Drawing.Point(16, 15);
            this.pbCamera.Margin = new System.Windows.Forms.Padding(4);
            this.pbCamera.Name = "pbCamera";
            this.pbCamera.Size = new System.Drawing.Size(529, 489);
            this.pbCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCamera.TabIndex = 0;
            this.pbCamera.TabStop = false;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(866, 29);
            this.lblHora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(34, 16);
            this.lblHora.TabIndex = 1;
            this.lblHora.Text = "hora";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(574, 29);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 16);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "fecha";
            // 
            // gbTipoAsistencia
            // 
            this.gbTipoAsistencia.Controls.Add(this.btnFinDescanso);
            this.gbTipoAsistencia.Controls.Add(this.btnInicioDescanso);
            this.gbTipoAsistencia.Controls.Add(this.btnSalida);
            this.gbTipoAsistencia.Controls.Add(this.btnEntrada);
            this.gbTipoAsistencia.Location = new System.Drawing.Point(562, 169);
            this.gbTipoAsistencia.Margin = new System.Windows.Forms.Padding(4);
            this.gbTipoAsistencia.Name = "gbTipoAsistencia";
            this.gbTipoAsistencia.Padding = new System.Windows.Forms.Padding(4);
            this.gbTipoAsistencia.Size = new System.Drawing.Size(387, 106);
            this.gbTipoAsistencia.TabIndex = 2;
            this.gbTipoAsistencia.TabStop = false;
            this.gbTipoAsistencia.Text = "Tipo de Asistencia: ";
            // 
            // btnFinDescanso
            // 
            this.btnFinDescanso.Location = new System.Drawing.Point(215, 64);
            this.btnFinDescanso.Margin = new System.Windows.Forms.Padding(4);
            this.btnFinDescanso.Name = "btnFinDescanso";
            this.btnFinDescanso.Size = new System.Drawing.Size(138, 28);
            this.btnFinDescanso.TabIndex = 3;
            this.btnFinDescanso.Text = "Fin de Descanso";
            this.btnFinDescanso.UseVisualStyleBackColor = true;
            // 
            // btnInicioDescanso
            // 
            this.btnInicioDescanso.Location = new System.Drawing.Point(47, 65);
            this.btnInicioDescanso.Margin = new System.Windows.Forms.Padding(4);
            this.btnInicioDescanso.Name = "btnInicioDescanso";
            this.btnInicioDescanso.Size = new System.Drawing.Size(139, 28);
            this.btnInicioDescanso.TabIndex = 2;
            this.btnInicioDescanso.Text = "Inicio de Descanso";
            this.btnInicioDescanso.UseVisualStyleBackColor = true;
            // 
            // btnSalida
            // 
            this.btnSalida.Location = new System.Drawing.Point(215, 23);
            this.btnSalida.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(138, 28);
            this.btnSalida.TabIndex = 1;
            this.btnSalida.Text = "Salida";
            this.btnSalida.UseVisualStyleBackColor = true;
            // 
            // btnEntrada
            // 
            this.btnEntrada.Location = new System.Drawing.Point(47, 23);
            this.btnEntrada.Margin = new System.Windows.Forms.Padding(4);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(139, 28);
            this.btnEntrada.TabIndex = 0;
            this.btnEntrada.Text = "Entrada";
            this.btnEntrada.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblValidacion);
            this.groupBox3.Controls.Add(this.btnValidar);
            this.groupBox3.Controls.Add(this.txtCodigo);
            this.groupBox3.Location = new System.Drawing.Point(560, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(387, 89);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Código";
            // 
            // btnValidar
            // 
            this.btnValidar.Location = new System.Drawing.Point(278, 26);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(75, 23);
            this.btnValidar.TabIndex = 1;
            this.btnValidar.Text = "Validar";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(47, 27);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(181, 22);
            this.txtCodigo.TabIndex = 0;
            // 
            // lblValidacion
            // 
            this.lblValidacion.AutoSize = true;
            this.lblValidacion.BackColor = System.Drawing.SystemColors.Control;
            this.lblValidacion.ForeColor = System.Drawing.Color.Red;
            this.lblValidacion.Location = new System.Drawing.Point(46, 61);
            this.lblValidacion.Name = "lblValidacion";
            this.lblValidacion.Size = new System.Drawing.Size(41, 16);
            this.lblValidacion.TabIndex = 4;
            this.lblValidacion.Text = "Texto";
            // 
            // MarcadorDeAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 525);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.gbTipoAsistencia);
            this.Controls.Add(this.pbCamera);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MarcadorDeAsistencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Asistencia";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MarcadorDeAsistencia_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).EndInit();
            this.gbTipoAsistencia.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCamera;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox gbTipoAsistencia;
        private System.Windows.Forms.Button btnFinDescanso;
        private System.Windows.Forms.Button btnInicioDescanso;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Timer timerHora;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblValidacion;
    }
}

