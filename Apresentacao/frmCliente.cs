﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Dados;
using Negocio;

namespace Apresentacao
{
    public partial class frmCliente : Form
    {
        private readonly ClienteService _clienteService;
        private DataTable tblCliente = new DataTable();
        public frmCliente()
        {
            InitializeComponent();
            _clienteService = new ClienteService();

            dgCliente.Columns.Add("Id", "ID");
            dgCliente.Columns.Add("Nome", "NOME");
            dgCliente.Columns.Add("tipoPesso", "TIPO PESSOA");
            dgCliente.Columns.Add("email", "EMAIL");

            tblCliente = _clienteService.getAll();
        }

        private void frmCliente_Load(object sender, System.EventArgs e)
        {
            radioPessoaFisica.Text = TipoPessoa.PESSOA_FISICA.ToString();
            radioPessoaJuridica.Text = TipoPessoa.PESSOA_JURIDICA.ToString();

            // NOVO ====================
            dgCliente.ColumnCount = 4;
            dgCliente.AutoGenerateColumns = false;
            dgCliente.Columns[0].Width = 20;
            dgCliente.Columns[0].HeaderText = "ID";
            dgCliente.Columns[0].DataPropertyName = "Id";
            //dgCliente.Columns[0].Visible = false;
            dgCliente.Columns[1].Width = 275;
            dgCliente.Columns[1].HeaderText = "NOME";
            dgCliente.Columns[1].DataPropertyName = "Nome";
            dgCliente.Columns[2].Width = 300;
            dgCliente.Columns[2].HeaderText = "EMAIL";
            dgCliente.Columns[2].DataPropertyName = "email";
            dgCliente.Columns[3].Width = 100;
            dgCliente.Columns[3].HeaderText = "TIPO";
            dgCliente.Columns[3].DataPropertyName = "tipoPessoa";

            dgCliente.AllowUserToAddRows = false;
            dgCliente.AllowUserToDeleteRows = false;
            dgCliente.MultiSelect = false;
            dgCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            atualizaListaCliente();

        }

        private void atualizaListaCliente()
        {
            dgCliente.DataSource = _clienteService.getAll();
            dgCliente.Refresh();
        }

        private void btnAdicionar_Click(object sender, System.EventArgs e)
        {
            int id;
            string nome;
            string email;

                nome = txtNome.Text;
                email = txtEmail.Text;

                TipoPessoa tp = radioPessoaFisica.Checked ? TipoPessoa.PESSOA_FISICA : TipoPessoa.PESSOA_JURIDICA;

                _clienteService.Insert(new Cliente(null, tp, nome, email));


                atualizaListaCliente();

        }
    }
}
