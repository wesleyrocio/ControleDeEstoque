namespace GUI
{
    partial class FrmPrincipal
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
            menuStrip1 = new MenuStrip();
            cadastroToolStripMenuItem = new ToolStripMenuItem();
            categoriaToolStripMenuItem = new ToolStripMenuItem();
            subCategoriaToolStripMenuItem = new ToolStripMenuItem();
            unidadeDeMedidaToolStripMenuItem = new ToolStripMenuItem();
            produtoToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            clienteToolStripMenuItem = new ToolStripMenuItem();
            fornecedorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            tipoDePagamentoToolStripMenuItem = new ToolStripMenuItem();
            consultaToolStripMenuItem = new ToolStripMenuItem();
            categoriaToolStripMenuItem1 = new ToolStripMenuItem();
            subCategoriaToolStripMenuItem1 = new ToolStripMenuItem();
            unidadeDeMedidaToolStripMenuItem1 = new ToolStripMenuItem();
            produtoToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            clienteToolStripMenuItem1 = new ToolStripMenuItem();
            fornecedorToolStripMenuItem1 = new ToolStripMenuItem();
            movimentacaoToolStripMenuItem = new ToolStripMenuItem();
            relatorioToolStripMenuItem = new ToolStripMenuItem();
            ferramentasToolStripMenuItem = new ToolStripMenuItem();
            configuraçãoDoBancoDeDadosToolStripMenuItem = new ToolStripMenuItem();
            backupDoBancoDeDadosToolStripMenuItem = new ToolStripMenuItem();
            sobreToolStripMenuItem = new ToolStripMenuItem();
            compraToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastroToolStripMenuItem, consultaToolStripMenuItem, movimentacaoToolStripMenuItem, relatorioToolStripMenuItem, ferramentasToolStripMenuItem, sobreToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(782, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastroToolStripMenuItem
            // 
            cadastroToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { categoriaToolStripMenuItem, subCategoriaToolStripMenuItem, unidadeDeMedidaToolStripMenuItem, produtoToolStripMenuItem, toolStripSeparator1, clienteToolStripMenuItem, fornecedorToolStripMenuItem, toolStripSeparator3, tipoDePagamentoToolStripMenuItem });
            cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            cadastroToolStripMenuItem.Size = new Size(82, 24);
            cadastroToolStripMenuItem.Text = "Cadastro";
            // 
            // categoriaToolStripMenuItem
            // 
            categoriaToolStripMenuItem.Name = "categoriaToolStripMenuItem";
            categoriaToolStripMenuItem.Size = new Size(224, 26);
            categoriaToolStripMenuItem.Text = "Categoria";
            categoriaToolStripMenuItem.Click += categoriaToolStripMenuItem_Click;
            // 
            // subCategoriaToolStripMenuItem
            // 
            subCategoriaToolStripMenuItem.Name = "subCategoriaToolStripMenuItem";
            subCategoriaToolStripMenuItem.Size = new Size(224, 26);
            subCategoriaToolStripMenuItem.Text = "SubCategoria";
            subCategoriaToolStripMenuItem.Click += subCategoriaToolStripMenuItem_Click;
            // 
            // unidadeDeMedidaToolStripMenuItem
            // 
            unidadeDeMedidaToolStripMenuItem.Name = "unidadeDeMedidaToolStripMenuItem";
            unidadeDeMedidaToolStripMenuItem.Size = new Size(224, 26);
            unidadeDeMedidaToolStripMenuItem.Text = "Unidade de Medida";
            unidadeDeMedidaToolStripMenuItem.Click += unidadeDeMedidaToolStripMenuItem_Click;
            // 
            // produtoToolStripMenuItem
            // 
            produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            produtoToolStripMenuItem.Size = new Size(224, 26);
            produtoToolStripMenuItem.Text = "Produto";
            produtoToolStripMenuItem.Click += produtoToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(221, 6);
            // 
            // clienteToolStripMenuItem
            // 
            clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            clienteToolStripMenuItem.Size = new Size(224, 26);
            clienteToolStripMenuItem.Text = "Cliente";
            clienteToolStripMenuItem.Click += clienteToolStripMenuItem_Click;
            // 
            // fornecedorToolStripMenuItem
            // 
            fornecedorToolStripMenuItem.Name = "fornecedorToolStripMenuItem";
            fornecedorToolStripMenuItem.Size = new Size(224, 26);
            fornecedorToolStripMenuItem.Text = "Fornecedor";
            fornecedorToolStripMenuItem.Click += fornecedorToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(221, 6);
            // 
            // tipoDePagamentoToolStripMenuItem
            // 
            tipoDePagamentoToolStripMenuItem.Name = "tipoDePagamentoToolStripMenuItem";
            tipoDePagamentoToolStripMenuItem.Size = new Size(224, 26);
            tipoDePagamentoToolStripMenuItem.Text = "Tipo de Pagamento";
            tipoDePagamentoToolStripMenuItem.Click += tipoDePagamentoToolStripMenuItem_Click;
            // 
            // consultaToolStripMenuItem
            // 
            consultaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { categoriaToolStripMenuItem1, subCategoriaToolStripMenuItem1, unidadeDeMedidaToolStripMenuItem1, produtoToolStripMenuItem1, toolStripSeparator2, clienteToolStripMenuItem1, fornecedorToolStripMenuItem1 });
            consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            consultaToolStripMenuItem.Size = new Size(80, 24);
            consultaToolStripMenuItem.Text = "Consulta";
            // 
            // categoriaToolStripMenuItem1
            // 
            categoriaToolStripMenuItem1.Name = "categoriaToolStripMenuItem1";
            categoriaToolStripMenuItem1.Size = new Size(224, 26);
            categoriaToolStripMenuItem1.Text = "Categoria";
            categoriaToolStripMenuItem1.Click += categoriaToolStripMenuItem1_Click;
            // 
            // subCategoriaToolStripMenuItem1
            // 
            subCategoriaToolStripMenuItem1.Name = "subCategoriaToolStripMenuItem1";
            subCategoriaToolStripMenuItem1.Size = new Size(224, 26);
            subCategoriaToolStripMenuItem1.Text = "SubCategoria";
            subCategoriaToolStripMenuItem1.Click += subCategoriaToolStripMenuItem1_Click;
            // 
            // unidadeDeMedidaToolStripMenuItem1
            // 
            unidadeDeMedidaToolStripMenuItem1.Name = "unidadeDeMedidaToolStripMenuItem1";
            unidadeDeMedidaToolStripMenuItem1.Size = new Size(224, 26);
            unidadeDeMedidaToolStripMenuItem1.Text = "Unidade de Medida";
            // 
            // produtoToolStripMenuItem1
            // 
            produtoToolStripMenuItem1.Name = "produtoToolStripMenuItem1";
            produtoToolStripMenuItem1.Size = new Size(224, 26);
            produtoToolStripMenuItem1.Text = "Produto";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(221, 6);
            // 
            // clienteToolStripMenuItem1
            // 
            clienteToolStripMenuItem1.Name = "clienteToolStripMenuItem1";
            clienteToolStripMenuItem1.Size = new Size(224, 26);
            clienteToolStripMenuItem1.Text = "Cliente";
            // 
            // fornecedorToolStripMenuItem1
            // 
            fornecedorToolStripMenuItem1.Name = "fornecedorToolStripMenuItem1";
            fornecedorToolStripMenuItem1.Size = new Size(224, 26);
            fornecedorToolStripMenuItem1.Text = "Fornecedor";
            // 
            // movimentacaoToolStripMenuItem
            // 
            movimentacaoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { compraToolStripMenuItem });
            movimentacaoToolStripMenuItem.Name = "movimentacaoToolStripMenuItem";
            movimentacaoToolStripMenuItem.Size = new Size(122, 24);
            movimentacaoToolStripMenuItem.Text = "Movimentação";
            // 
            // relatorioToolStripMenuItem
            // 
            relatorioToolStripMenuItem.Name = "relatorioToolStripMenuItem";
            relatorioToolStripMenuItem.Size = new Size(84, 24);
            relatorioToolStripMenuItem.Text = "Relatório";
            // 
            // ferramentasToolStripMenuItem
            // 
            ferramentasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { configuraçãoDoBancoDeDadosToolStripMenuItem, backupDoBancoDeDadosToolStripMenuItem });
            ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            ferramentasToolStripMenuItem.Size = new Size(104, 24);
            ferramentasToolStripMenuItem.Text = "Ferramentas";
            // 
            // configuraçãoDoBancoDeDadosToolStripMenuItem
            // 
            configuraçãoDoBancoDeDadosToolStripMenuItem.Name = "configuraçãoDoBancoDeDadosToolStripMenuItem";
            configuraçãoDoBancoDeDadosToolStripMenuItem.Size = new Size(316, 26);
            configuraçãoDoBancoDeDadosToolStripMenuItem.Text = "Configuração do Banco de Dados";
            configuraçãoDoBancoDeDadosToolStripMenuItem.Click += configuraçãoDoBancoDeDadosToolStripMenuItem_Click;
            // 
            // backupDoBancoDeDadosToolStripMenuItem
            // 
            backupDoBancoDeDadosToolStripMenuItem.Name = "backupDoBancoDeDadosToolStripMenuItem";
            backupDoBancoDeDadosToolStripMenuItem.Size = new Size(316, 26);
            backupDoBancoDeDadosToolStripMenuItem.Text = "Backup do Banco de Dados";
            backupDoBancoDeDadosToolStripMenuItem.Click += backupDoBancoDeDadosToolStripMenuItem_Click;
            // 
            // sobreToolStripMenuItem
            // 
            sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            sobreToolStripMenuItem.Size = new Size(62, 24);
            sobreToolStripMenuItem.Text = "Sobre";
            // 
            // compraToolStripMenuItem
            // 
            compraToolStripMenuItem.Name = "compraToolStripMenuItem";
            compraToolStripMenuItem.Size = new Size(224, 26);
            compraToolStripMenuItem.Text = "Compra";
            compraToolStripMenuItem.Click += compraToolStripMenuItem_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Controle de Estoque";
            Load += FrmPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastroToolStripMenuItem;
        private ToolStripMenuItem categoriaToolStripMenuItem;
        private ToolStripMenuItem subCategoriaToolStripMenuItem;
        private ToolStripMenuItem unidadeDeMedidaToolStripMenuItem;
        private ToolStripMenuItem produtoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem clienteToolStripMenuItem;
        private ToolStripMenuItem fornecedorToolStripMenuItem;
        private ToolStripMenuItem consultaToolStripMenuItem;
        private ToolStripMenuItem movimentacaoToolStripMenuItem;
        private ToolStripMenuItem relatorioToolStripMenuItem;
        private ToolStripMenuItem ferramentasToolStripMenuItem;
        private ToolStripMenuItem sobreToolStripMenuItem;
        private ToolStripMenuItem categoriaToolStripMenuItem1;
        private ToolStripMenuItem subCategoriaToolStripMenuItem1;
        private ToolStripMenuItem unidadeDeMedidaToolStripMenuItem1;
        private ToolStripMenuItem produtoToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem clienteToolStripMenuItem1;
        private ToolStripMenuItem fornecedorToolStripMenuItem1;
        private ToolStripMenuItem configuraçãoDoBancoDeDadosToolStripMenuItem;
        private ToolStripMenuItem backupDoBancoDeDadosToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem tipoDePagamentoToolStripMenuItem;
        private ToolStripMenuItem compraToolStripMenuItem;
    }
}