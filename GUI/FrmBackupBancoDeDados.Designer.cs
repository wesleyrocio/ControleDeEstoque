namespace GUI
{
    partial class FrmBackupBancoDeDados
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
            btnBackup = new Button();
            btnRestaurar = new Button();
            SuspendLayout();
            // 
            // btnBackup
            // 
            btnBackup.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackup.Location = new Point(12, 35);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(758, 217);
            btnBackup.TabIndex = 0;
            btnBackup.Text = "Backup do  Banco de Dados";
            btnBackup.UseVisualStyleBackColor = true;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnRestaurar
            // 
            btnRestaurar.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRestaurar.Location = new Point(12, 272);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(758, 217);
            btnRestaurar.TabIndex = 1;
            btnRestaurar.Text = "Restaurar o Banco de Dados";
            btnRestaurar.UseVisualStyleBackColor = true;
            btnRestaurar.Click += btnRestaurar_Click;
            // 
            // FrmBackupBancoDeDados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(btnRestaurar);
            Controls.Add(btnBackup);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmBackupBancoDeDados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Backup Banco de Dados";
            ResumeLayout(false);
        }

        #endregion

        private Button btnBackup;
        private Button btnRestaurar;
    }
}