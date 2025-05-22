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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFinDescanso = new System.Windows.Forms.Button();
            this.btnInicioDescanso = new System.Windows.Forms.Button();
            this.btnSalida = new System.Windows.Forms.Button();
            this.btnEntrada = new System.Windows.Forms.Button();
            this.btnActivarCamara = new System.Windows.Forms.Button();
            this.btnDesactivarCamara = new System.Windows.Forms.Button();
            this.btnRegistrarAsistencia = new System.Windows.Forms.Button();
            this.timerHora = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(397, 397);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblHora);
            this.groupBox1.Controls.Add(this.lblFecha);
            this.groupBox1.Location = new System.Drawing.Point(415, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 74);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sistema: ";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(21, 50);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(28, 13);
            this.lblHora.TabIndex = 1;
            this.lblHora.Text = "hora";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(21, 25);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(34, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "fecha";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFinDescanso);
            this.groupBox2.Controls.Add(this.btnInicioDescanso);
            this.groupBox2.Controls.Add(this.btnSalida);
            this.groupBox2.Controls.Add(this.btnEntrada);
            this.groupBox2.Location = new System.Drawing.Point(415, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 77);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Asistencia: ";
            // 
            // btnFinDescanso
            // 
            this.btnFinDescanso.Location = new System.Drawing.Point(202, 48);
            this.btnFinDescanso.Name = "btnFinDescanso";
            this.btnFinDescanso.Size = new System.Drawing.Size(165, 23);
            this.btnFinDescanso.TabIndex = 3;
            this.btnFinDescanso.Text = "Fin de Descanso";
            this.btnFinDescanso.UseVisualStyleBackColor = true;
            // 
            // btnInicioDescanso
            // 
            this.btnInicioDescanso.Location = new System.Drawing.Point(6, 48);
            this.btnInicioDescanso.Name = "btnInicioDescanso";
            this.btnInicioDescanso.Size = new System.Drawing.Size(165, 23);
            this.btnInicioDescanso.TabIndex = 2;
            this.btnInicioDescanso.Text = "Inicio de Descanso";
            this.btnInicioDescanso.UseVisualStyleBackColor = true;
            // 
            // btnSalida
            // 
            this.btnSalida.Location = new System.Drawing.Point(202, 19);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(165, 23);
            this.btnSalida.TabIndex = 1;
            this.btnSalida.Text = "Salida";
            this.btnSalida.UseVisualStyleBackColor = true;
            // 
            // btnEntrada
            // 
            this.btnEntrada.Location = new System.Drawing.Point(6, 19);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(165, 23);
            this.btnEntrada.TabIndex = 0;
            this.btnEntrada.Text = "Entrada";
            this.btnEntrada.UseVisualStyleBackColor = true;
            // 
            // btnActivarCamara
            // 
            this.btnActivarCamara.Location = new System.Drawing.Point(12, 415);
            this.btnActivarCamara.Name = "btnActivarCamara";
            this.btnActivarCamara.Size = new System.Drawing.Size(160, 23);
            this.btnActivarCamara.TabIndex = 4;
            this.btnActivarCamara.Text = "Activar Cámara";
            this.btnActivarCamara.UseVisualStyleBackColor = true;
            // 
            // btnDesactivarCamara
            // 
            this.btnDesactivarCamara.Location = new System.Drawing.Point(249, 415);
            this.btnDesactivarCamara.Name = "btnDesactivarCamara";
            this.btnDesactivarCamara.Size = new System.Drawing.Size(160, 23);
            this.btnDesactivarCamara.TabIndex = 5;
            this.btnDesactivarCamara.Text = "Desactivar Cámara";
            this.btnDesactivarCamara.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarAsistencia
            // 
            this.btnRegistrarAsistencia.Location = new System.Drawing.Point(508, 190);
            this.btnRegistrarAsistencia.Name = "btnRegistrarAsistencia";
            this.btnRegistrarAsistencia.Size = new System.Drawing.Size(182, 23);
            this.btnRegistrarAsistencia.TabIndex = 6;
            this.btnRegistrarAsistencia.Text = "Registrar Asistencia";
            this.btnRegistrarAsistencia.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegistrarAsistencia);
            this.Controls.Add(this.btnDesactivarCamara);
            this.Controls.Add(this.btnActivarCamara);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Asistencia";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFinDescanso;
        private System.Windows.Forms.Button btnInicioDescanso;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Button btnActivarCamara;
        private System.Windows.Forms.Button btnDesactivarCamara;
        private System.Windows.Forms.Button btnRegistrarAsistencia;
        private System.Windows.Forms.Timer timerHora;
    }
}

