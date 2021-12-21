namespace Aviv.Eleicao.Admin
{
    partial class EleicaoFrm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_numero_eleitores = new System.Windows.Forms.MaskedTextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txt_votos_nulos = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_votos_brancos = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_votos_validos = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_votos = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabEleicao = new System.Windows.Forms.TabControl();
            this.tabPageCargos = new System.Windows.Forms.TabPage();
            this.btnEditarCargo = new System.Windows.Forms.Button();
            this.btnEncerrarVotacaoCargo = new System.Windows.Forms.Button();
            this.btnIniciarVotacaoCargo = new System.Windows.Forms.Button();
            this.btnExcluirCargo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelarEdtCargo = new System.Windows.Forms.Button();
            this.btnInserirAtualizarCargo = new System.Windows.Forms.Button();
            this.txt_vagas_cargo = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_nome_cargo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gdvCargosEleicao = new System.Windows.Forms.DataGridView();
            this.tabPageCandidatos = new System.Windows.Forms.TabPage();
            this.btnEleger = new System.Windows.Forms.Button();
            this.btnExcluirCandSelecionados = new System.Windows.Forms.Button();
            this.btnAdicionarCandidatos = new System.Windows.Forms.Button();
            this.gdvCandidatos = new System.Windows.Forms.DataGridView();
            this.colSelecionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdCandidato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVotos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbCargos = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_data_fim = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_data_inicio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_data_cadastro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnFecharEleicao = new System.Windows.Forms.Button();
            this.btnAbrirEleicao = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.colCodCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNroVagas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataFim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVotosCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVotosVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVolBranco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVotosNull = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tabEleicao.SuspendLayout();
            this.tabPageCargos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvCargosEleicao)).BeginInit();
            this.tabPageCandidatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvCandidatos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txt_numero_eleitores);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.txt_votos_nulos);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txt_votos_brancos);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txt_votos_validos);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txt_votos);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.tabEleicao);
            this.panel1.Controls.Add(this.txt_data_fim);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_data_inicio);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_data_cadastro);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_codigo);
            this.panel1.Controls.Add(this.txt_nome);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 481);
            this.panel1.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(686, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 17);
            this.label13.TabIndex = 21;
            this.label13.Text = "Nr. Eleitores";
            // 
            // txt_numero_eleitores
            // 
            this.txt_numero_eleitores.Location = new System.Drawing.Point(689, 39);
            this.txt_numero_eleitores.Mask = "00000";
            this.txt_numero_eleitores.Name = "txt_numero_eleitores";
            this.txt_numero_eleitores.Size = new System.Drawing.Size(92, 20);
            this.txt_numero_eleitores.TabIndex = 20;
            this.txt_numero_eleitores.ValidatingType = typeof(int);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Image = global::Aviv.Eleicao.Admin.Properties.Resources.Page_refresh;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(689, 80);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 27);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txt_votos_nulos
            // 
            this.txt_votos_nulos.Location = new System.Drawing.Point(618, 87);
            this.txt_votos_nulos.Name = "txt_votos_nulos";
            this.txt_votos_nulos.ReadOnly = true;
            this.txt_votos_nulos.Size = new System.Drawing.Size(65, 20);
            this.txt_votos_nulos.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(615, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 17);
            this.label12.TabIndex = 17;
            this.label12.Text = "Nulos";
            // 
            // txt_votos_brancos
            // 
            this.txt_votos_brancos.Location = new System.Drawing.Point(547, 87);
            this.txt_votos_brancos.Name = "txt_votos_brancos";
            this.txt_votos_brancos.ReadOnly = true;
            this.txt_votos_brancos.Size = new System.Drawing.Size(65, 20);
            this.txt_votos_brancos.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(544, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "Brancos";
            // 
            // txt_votos_validos
            // 
            this.txt_votos_validos.Location = new System.Drawing.Point(475, 87);
            this.txt_votos_validos.Name = "txt_votos_validos";
            this.txt_votos_validos.ReadOnly = true;
            this.txt_votos_validos.Size = new System.Drawing.Size(65, 20);
            this.txt_votos_validos.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(472, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 17);
            this.label10.TabIndex = 13;
            this.label10.Text = "Válidos";
            // 
            // txt_votos
            // 
            this.txt_votos.Location = new System.Drawing.Point(405, 87);
            this.txt_votos.Name = "txt_votos";
            this.txt_votos.ReadOnly = true;
            this.txt_votos.Size = new System.Drawing.Size(65, 20);
            this.txt_votos.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(402, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "Votos";
            // 
            // tabEleicao
            // 
            this.tabEleicao.Controls.Add(this.tabPageCargos);
            this.tabEleicao.Controls.Add(this.tabPageCandidatos);
            this.tabEleicao.Location = new System.Drawing.Point(13, 113);
            this.tabEleicao.Name = "tabEleicao";
            this.tabEleicao.SelectedIndex = 0;
            this.tabEleicao.Size = new System.Drawing.Size(778, 363);
            this.tabEleicao.TabIndex = 10;
            this.tabEleicao.Visible = false;
            // 
            // tabPageCargos
            // 
            this.tabPageCargos.Controls.Add(this.btnEditarCargo);
            this.tabPageCargos.Controls.Add(this.btnEncerrarVotacaoCargo);
            this.tabPageCargos.Controls.Add(this.btnIniciarVotacaoCargo);
            this.tabPageCargos.Controls.Add(this.btnExcluirCargo);
            this.tabPageCargos.Controls.Add(this.groupBox1);
            this.tabPageCargos.Controls.Add(this.gdvCargosEleicao);
            this.tabPageCargos.Location = new System.Drawing.Point(4, 22);
            this.tabPageCargos.Name = "tabPageCargos";
            this.tabPageCargos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCargos.Size = new System.Drawing.Size(770, 337);
            this.tabPageCargos.TabIndex = 0;
            this.tabPageCargos.Text = "Cargos";
            this.tabPageCargos.UseVisualStyleBackColor = true;
            // 
            // btnEditarCargo
            // 
            this.btnEditarCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCargo.Image = global::Aviv.Eleicao.Admin.Properties.Resources.Page_white_edit;
            this.btnEditarCargo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarCargo.Location = new System.Drawing.Point(366, 271);
            this.btnEditarCargo.Name = "btnEditarCargo";
            this.btnEditarCargo.Size = new System.Drawing.Size(120, 23);
            this.btnEditarCargo.TabIndex = 5;
            this.btnEditarCargo.Text = "Editar cargo";
            this.btnEditarCargo.UseVisualStyleBackColor = true;
            this.btnEditarCargo.Click += new System.EventHandler(this.btnEditarCargo_Click);
            // 
            // btnEncerrarVotacaoCargo
            // 
            this.btnEncerrarVotacaoCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncerrarVotacaoCargo.Image = global::Aviv.Eleicao.Admin.Properties.Resources.Lock;
            this.btnEncerrarVotacaoCargo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEncerrarVotacaoCargo.Location = new System.Drawing.Point(179, 271);
            this.btnEncerrarVotacaoCargo.Name = "btnEncerrarVotacaoCargo";
            this.btnEncerrarVotacaoCargo.Size = new System.Drawing.Size(186, 23);
            this.btnEncerrarVotacaoCargo.TabIndex = 4;
            this.btnEncerrarVotacaoCargo.Text = "Encerrar votação cargo";
            this.btnEncerrarVotacaoCargo.UseVisualStyleBackColor = true;
            this.btnEncerrarVotacaoCargo.Click += new System.EventHandler(this.btnEncerrarVotacaoCargo_Click);
            // 
            // btnIniciarVotacaoCargo
            // 
            this.btnIniciarVotacaoCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarVotacaoCargo.Image = global::Aviv.Eleicao.Admin.Properties.Resources.Lock_open;
            this.btnIniciarVotacaoCargo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciarVotacaoCargo.Location = new System.Drawing.Point(6, 271);
            this.btnIniciarVotacaoCargo.Name = "btnIniciarVotacaoCargo";
            this.btnIniciarVotacaoCargo.Size = new System.Drawing.Size(172, 23);
            this.btnIniciarVotacaoCargo.TabIndex = 3;
            this.btnIniciarVotacaoCargo.Text = "Iniciar votação cargo";
            this.btnIniciarVotacaoCargo.UseVisualStyleBackColor = true;
            this.btnIniciarVotacaoCargo.Click += new System.EventHandler(this.btnIniciarVotacaoCargo_Click);
            // 
            // btnExcluirCargo
            // 
            this.btnExcluirCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirCargo.Image = global::Aviv.Eleicao.Admin.Properties.Resources.Delete_silk;
            this.btnExcluirCargo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluirCargo.Location = new System.Drawing.Point(489, 271);
            this.btnExcluirCargo.Name = "btnExcluirCargo";
            this.btnExcluirCargo.Size = new System.Drawing.Size(126, 23);
            this.btnExcluirCargo.TabIndex = 2;
            this.btnExcluirCargo.Text = "Excluir cargo";
            this.btnExcluirCargo.UseVisualStyleBackColor = true;
            this.btnExcluirCargo.Click += new System.EventHandler(this.btnExcluirCargo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelarEdtCargo);
            this.groupBox1.Controls.Add(this.btnInserirAtualizarCargo);
            this.groupBox1.Controls.Add(this.txt_vagas_cargo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_nome_cargo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 77);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inserir Cargo";
            // 
            // btnCancelarEdtCargo
            // 
            this.btnCancelarEdtCargo.Location = new System.Drawing.Point(382, 39);
            this.btnCancelarEdtCargo.Name = "btnCancelarEdtCargo";
            this.btnCancelarEdtCargo.Size = new System.Drawing.Size(82, 23);
            this.btnCancelarEdtCargo.TabIndex = 8;
            this.btnCancelarEdtCargo.Text = "Cancelar";
            this.btnCancelarEdtCargo.UseVisualStyleBackColor = true;
            this.btnCancelarEdtCargo.Visible = false;
            this.btnCancelarEdtCargo.Click += new System.EventHandler(this.btnCancelarEdtCargo_Click);
            // 
            // btnInserirAtualizarCargo
            // 
            this.btnInserirAtualizarCargo.Location = new System.Drawing.Point(287, 39);
            this.btnInserirAtualizarCargo.Name = "btnInserirAtualizarCargo";
            this.btnInserirAtualizarCargo.Size = new System.Drawing.Size(90, 23);
            this.btnInserirAtualizarCargo.TabIndex = 8;
            this.btnInserirAtualizarCargo.Text = "Inserir";
            this.btnInserirAtualizarCargo.UseVisualStyleBackColor = true;
            this.btnInserirAtualizarCargo.Click += new System.EventHandler(this.btnInserirCargo_Click);
            // 
            // txt_vagas_cargo
            // 
            this.txt_vagas_cargo.Location = new System.Drawing.Point(231, 39);
            this.txt_vagas_cargo.Mask = "0";
            this.txt_vagas_cargo.Name = "txt_vagas_cargo";
            this.txt_vagas_cargo.Size = new System.Drawing.Size(50, 23);
            this.txt_vagas_cargo.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(228, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Vagas";
            // 
            // txt_nome_cargo
            // 
            this.txt_nome_cargo.Location = new System.Drawing.Point(9, 39);
            this.txt_nome_cargo.MaxLength = 50;
            this.txt_nome_cargo.Name = "txt_nome_cargo";
            this.txt_nome_cargo.Size = new System.Drawing.Size(216, 23);
            this.txt_nome_cargo.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Nome:";
            // 
            // gdvCargosEleicao
            // 
            this.gdvCargosEleicao.AllowUserToAddRows = false;
            this.gdvCargosEleicao.AllowUserToDeleteRows = false;
            this.gdvCargosEleicao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvCargosEleicao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodCargo,
            this.colCargo,
            this.colNroVagas,
            this.colDataInicio,
            this.colDataFim,
            this.colVotosCargo,
            this.colVotosVal,
            this.colVolBranco,
            this.colVotosNull});
            this.gdvCargosEleicao.Location = new System.Drawing.Point(6, 100);
            this.gdvCargosEleicao.Name = "gdvCargosEleicao";
            this.gdvCargosEleicao.ReadOnly = true;
            this.gdvCargosEleicao.Size = new System.Drawing.Size(758, 165);
            this.gdvCargosEleicao.TabIndex = 0;
            // 
            // tabPageCandidatos
            // 
            this.tabPageCandidatos.Controls.Add(this.btnEleger);
            this.tabPageCandidatos.Controls.Add(this.btnExcluirCandSelecionados);
            this.tabPageCandidatos.Controls.Add(this.btnAdicionarCandidatos);
            this.tabPageCandidatos.Controls.Add(this.gdvCandidatos);
            this.tabPageCandidatos.Controls.Add(this.cbCargos);
            this.tabPageCandidatos.Controls.Add(this.label8);
            this.tabPageCandidatos.Location = new System.Drawing.Point(4, 22);
            this.tabPageCandidatos.Name = "tabPageCandidatos";
            this.tabPageCandidatos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCandidatos.Size = new System.Drawing.Size(770, 337);
            this.tabPageCandidatos.TabIndex = 1;
            this.tabPageCandidatos.Text = "Candidatos";
            this.tabPageCandidatos.UseVisualStyleBackColor = true;
            // 
            // btnEleger
            // 
            this.btnEleger.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEleger.Image = global::Aviv.Eleicao.Admin.Properties.Resources.Accept;
            this.btnEleger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEleger.Location = new System.Drawing.Point(7, 308);
            this.btnEleger.Name = "btnEleger";
            this.btnEleger.Size = new System.Drawing.Size(171, 23);
            this.btnEleger.TabIndex = 9;
            this.btnEleger.Text = "Eleger Selecionado";
            this.btnEleger.UseVisualStyleBackColor = true;
            this.btnEleger.Click += new System.EventHandler(this.btnEleger_Click);
            // 
            // btnExcluirCandSelecionados
            // 
            this.btnExcluirCandSelecionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirCandSelecionados.Image = global::Aviv.Eleicao.Admin.Properties.Resources.Delete_silk;
            this.btnExcluirCandSelecionados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluirCandSelecionados.Location = new System.Drawing.Point(593, 308);
            this.btnExcluirCandSelecionados.Name = "btnExcluirCandSelecionados";
            this.btnExcluirCandSelecionados.Size = new System.Drawing.Size(171, 23);
            this.btnExcluirCandSelecionados.TabIndex = 8;
            this.btnExcluirCandSelecionados.Text = "Excluir Selecionados";
            this.btnExcluirCandSelecionados.UseVisualStyleBackColor = true;
            this.btnExcluirCandSelecionados.Click += new System.EventHandler(this.btnExcluirCandSelecionados_Click);
            // 
            // btnAdicionarCandidatos
            // 
            this.btnAdicionarCandidatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarCandidatos.Image = global::Aviv.Eleicao.Admin.Properties.Resources.Add;
            this.btnAdicionarCandidatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdicionarCandidatos.Location = new System.Drawing.Point(307, 25);
            this.btnAdicionarCandidatos.Name = "btnAdicionarCandidatos";
            this.btnAdicionarCandidatos.Size = new System.Drawing.Size(173, 23);
            this.btnAdicionarCandidatos.TabIndex = 7;
            this.btnAdicionarCandidatos.Text = "Adicionar Candidatos";
            this.btnAdicionarCandidatos.UseVisualStyleBackColor = true;
            this.btnAdicionarCandidatos.Click += new System.EventHandler(this.btnAdicionarCandidatos_Click);
            // 
            // gdvCandidatos
            // 
            this.gdvCandidatos.AllowUserToAddRows = false;
            this.gdvCandidatos.AllowUserToDeleteRows = false;
            this.gdvCandidatos.AllowUserToOrderColumns = true;
            this.gdvCandidatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvCandidatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelecionar,
            this.colId,
            this.colIdCandidato,
            this.colNome,
            this.colVotos,
            this.colStatus});
            this.gdvCandidatos.Location = new System.Drawing.Point(7, 54);
            this.gdvCandidatos.Name = "gdvCandidatos";
            this.gdvCandidatos.ReadOnly = true;
            this.gdvCandidatos.Size = new System.Drawing.Size(758, 248);
            this.gdvCandidatos.TabIndex = 6;
            this.gdvCandidatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvCandidatos_CellContentClick);
            // 
            // colSelecionar
            // 
            this.colSelecionar.HeaderText = "";
            this.colSelecionar.Name = "colSelecionar";
            this.colSelecionar.ReadOnly = true;
            this.colSelecionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSelecionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSelecionar.Width = 40;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "int_id_eleicao_cargo_candidato";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 60;
            // 
            // colIdCandidato
            // 
            this.colIdCandidato.DataPropertyName = "int_id_candidato";
            this.colIdCandidato.HeaderText = "ID Candidato";
            this.colIdCandidato.Name = "colIdCandidato";
            this.colIdCandidato.ReadOnly = true;
            // 
            // colNome
            // 
            this.colNome.DataPropertyName = "str_nome_candidato";
            this.colNome.HeaderText = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            this.colNome.Width = 200;
            // 
            // colVotos
            // 
            this.colVotos.DataPropertyName = "int_votos";
            this.colVotos.HeaderText = "Votos";
            this.colVotos.Name = "colVotos";
            this.colVotos.ReadOnly = true;
            this.colVotos.Width = 60;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "str_nome_status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 200;
            // 
            // cbCargos
            // 
            this.cbCargos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCargos.FormattingEnabled = true;
            this.cbCargos.Location = new System.Drawing.Point(7, 25);
            this.cbCargos.Name = "cbCargos";
            this.cbCargos.Size = new System.Drawing.Size(294, 21);
            this.cbCargos.TabIndex = 5;
            this.cbCargos.SelectedIndexChanged += new System.EventHandler(this.cbCargos_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Cargo:";
            // 
            // txt_data_fim
            // 
            this.txt_data_fim.Location = new System.Drawing.Point(275, 87);
            this.txt_data_fim.Name = "txt_data_fim";
            this.txt_data_fim.ReadOnly = true;
            this.txt_data_fim.Size = new System.Drawing.Size(125, 20);
            this.txt_data_fim.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(272, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Dt. Fim";
            // 
            // txt_data_inicio
            // 
            this.txt_data_inicio.Location = new System.Drawing.Point(144, 87);
            this.txt_data_inicio.Name = "txt_data_inicio";
            this.txt_data_inicio.ReadOnly = true;
            this.txt_data_inicio.Size = new System.Drawing.Size(125, 20);
            this.txt_data_inicio.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(141, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Dt. Início";
            // 
            // txt_data_cadastro
            // 
            this.txt_data_cadastro.Location = new System.Drawing.Point(13, 87);
            this.txt_data_cadastro.Name = "txt_data_cadastro";
            this.txt_data_cadastro.ReadOnly = true;
            this.txt_data_cadastro.Size = new System.Drawing.Size(125, 20);
            this.txt_data_cadastro.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dt. Cadastro:";
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(13, 40);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.ReadOnly = true;
            this.txt_codigo.Size = new System.Drawing.Size(125, 20);
            this.txt_codigo.TabIndex = 1;
            // 
            // txt_nome
            // 
            this.txt_nome.Location = new System.Drawing.Point(144, 40);
            this.txt_nome.MaxLength = 50;
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(539, 20);
            this.txt_nome.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(141, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Image = global::Aviv.Eleicao.Admin.Properties.Resources.search;
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(689, 2);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(105, 23);
            this.btnPesquisar.TabIndex = 6;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnFecharEleicao
            // 
            this.btnFecharEleicao.Enabled = false;
            this.btnFecharEleicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecharEleicao.Image = global::Aviv.Eleicao.Admin.Properties.Resources.Lock;
            this.btnFecharEleicao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFecharEleicao.Location = new System.Drawing.Point(556, 2);
            this.btnFecharEleicao.Name = "btnFecharEleicao";
            this.btnFecharEleicao.Size = new System.Drawing.Size(131, 23);
            this.btnFecharEleicao.TabIndex = 5;
            this.btnFecharEleicao.Text = "Fechar Eleição";
            this.btnFecharEleicao.UseVisualStyleBackColor = true;
            this.btnFecharEleicao.Click += new System.EventHandler(this.btnFecharEleicao_Click);
            // 
            // btnAbrirEleicao
            // 
            this.btnAbrirEleicao.Enabled = false;
            this.btnAbrirEleicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirEleicao.Image = global::Aviv.Eleicao.Admin.Properties.Resources.Lock_open;
            this.btnAbrirEleicao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbrirEleicao.Location = new System.Drawing.Point(438, 2);
            this.btnAbrirEleicao.Name = "btnAbrirEleicao";
            this.btnAbrirEleicao.Size = new System.Drawing.Size(117, 23);
            this.btnAbrirEleicao.TabIndex = 4;
            this.btnAbrirEleicao.Text = "Abrir Eleição";
            this.btnAbrirEleicao.UseVisualStyleBackColor = true;
            this.btnAbrirEleicao.Click += new System.EventHandler(this.btnAbrirEleicao_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Image = global::Aviv.Eleicao.Admin.Properties.Resources.Delete_silk;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(332, 2);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(105, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = global::Aviv.Eleicao.Admin.Properties.Resources.Icons_mini_action_save;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(119, 2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(105, 23);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Enabled = false;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Image = global::Aviv.Eleicao.Admin.Properties.Resources.Add;
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.Location = new System.Drawing.Point(12, 2);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(105, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Enabled = false;
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Image = global::Aviv.Eleicao.Admin.Properties.Resources.Page_white_excel;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(225, 2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(105, 23);
            this.btnExportar.TabIndex = 20;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // colCodCargo
            // 
            this.colCodCargo.DataPropertyName = "int_id_eleicao_cargo";
            this.colCodCargo.HeaderText = "ID";
            this.colCodCargo.Name = "colCodCargo";
            this.colCodCargo.ReadOnly = true;
            this.colCodCargo.Width = 50;
            // 
            // colCargo
            // 
            this.colCargo.DataPropertyName = "str_nome_cargo";
            this.colCargo.HeaderText = "Cargo";
            this.colCargo.Name = "colCargo";
            this.colCargo.ReadOnly = true;
            this.colCargo.Width = 160;
            // 
            // colNroVagas
            // 
            this.colNroVagas.DataPropertyName = "int_numero_vagas";
            this.colNroVagas.HeaderText = "Nro. Vagas";
            this.colNroVagas.Name = "colNroVagas";
            this.colNroVagas.ReadOnly = true;
            this.colNroVagas.Width = 90;
            // 
            // colDataInicio
            // 
            this.colDataInicio.DataPropertyName = "dte_data_inicio";
            this.colDataInicio.HeaderText = "Dt. Início";
            this.colDataInicio.Name = "colDataInicio";
            this.colDataInicio.ReadOnly = true;
            // 
            // colDataFim
            // 
            this.colDataFim.DataPropertyName = "dte_data_fim";
            this.colDataFim.HeaderText = "Dt. Fim";
            this.colDataFim.Name = "colDataFim";
            this.colDataFim.ReadOnly = true;
            // 
            // colVotosCargo
            // 
            this.colVotosCargo.DataPropertyName = "int_votos";
            this.colVotosCargo.HeaderText = "Votos";
            this.colVotosCargo.Name = "colVotosCargo";
            this.colVotosCargo.ReadOnly = true;
            this.colVotosCargo.Width = 50;
            // 
            // colVotosVal
            // 
            this.colVotosVal.DataPropertyName = "int_votos_validos";
            this.colVotosVal.HeaderText = "Válidos";
            this.colVotosVal.Name = "colVotosVal";
            this.colVotosVal.ReadOnly = true;
            this.colVotosVal.Width = 50;
            // 
            // colVolBranco
            // 
            this.colVolBranco.DataPropertyName = "int_votos_brancos";
            this.colVolBranco.HeaderText = "Brancos";
            this.colVolBranco.Name = "colVolBranco";
            this.colVolBranco.ReadOnly = true;
            this.colVolBranco.Width = 50;
            // 
            // colVotosNull
            // 
            this.colVotosNull.DataPropertyName = "int_votos_nulos";
            this.colVotosNull.HeaderText = "Nulos";
            this.colVotosNull.Name = "colVotosNull";
            this.colVotosNull.ReadOnly = true;
            this.colVotosNull.Width = 60;
            // 
            // EleicaoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 532);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnFecharEleicao);
            this.Controls.Add(this.btnAbrirEleicao);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EleicaoFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro e Administração de Eleição";
            this.Activated += new System.EventHandler(this.EleicaoFrm_Activated);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabEleicao.ResumeLayout(false);
            this.tabPageCargos.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvCargosEleicao)).EndInit();
            this.tabPageCandidatos.ResumeLayout(false);
            this.tabPageCandidatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvCandidatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_data_fim;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_data_inicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_data_cadastro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabEleicao;
        private System.Windows.Forms.TabPage tabPageCargos;
        private System.Windows.Forms.TabPage tabPageCandidatos;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAbrirEleicao;
        private System.Windows.Forms.Button btnFecharEleicao;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.DataGridView gdvCargosEleicao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInserirAtualizarCargo;
        private System.Windows.Forms.MaskedTextBox txt_vagas_cargo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_nome_cargo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnEditarCargo;
        private System.Windows.Forms.Button btnEncerrarVotacaoCargo;
        private System.Windows.Forms.Button btnIniciarVotacaoCargo;
        private System.Windows.Forms.Button btnExcluirCargo;
        private System.Windows.Forms.Button btnCancelarEdtCargo;
        private System.Windows.Forms.ComboBox cbCargos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView gdvCandidatos;
        private System.Windows.Forms.Button btnAdicionarCandidatos;
        private System.Windows.Forms.Button btnExcluirCandSelecionados;
        private System.Windows.Forms.TextBox txt_votos_nulos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_votos_brancos;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_votos_validos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_votos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelecionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCandidato;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVotos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Button btnEleger;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox txt_numero_eleitores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNroVagas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataFim;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVotosCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVotosVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVolBranco;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVotosNull;
    }
}