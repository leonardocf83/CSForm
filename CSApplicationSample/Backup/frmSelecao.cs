using System;
using System.Collections.Generic;
using System.Text;
using CSForms;
using System.Data;
using System.Data.OleDb;

namespace CSApplicationSample
{
  public class frmSelecao: CSForm
  {

    public CSLabel lbl3; 
    public CSCombo cmb;
    public CSCombo cmb1;
    public CSCombo cmb2;
    public CSButton btn2;
    public CSButton btn3;
    public CSButton btn;
    public CSButton btnSair;
    public CSText txt;
    public CSLabel lbl2;
    public CSText txt2;

    public CSLabel lbl; 
    private OleDbConnection cnn;
    private DataTable dt;
    private int  row;

    public frmSelecao(string name) : base(name)
    {
      
      this.Caption = "CADASTRO CLIENTE";

      lbl3 = new CSLabel(this, "lblcliente1", 2, 8);
      lbl3.Label = "CLIENTE:   ";

      cmb = new CSCombo(this, "cmbcliente", lbl3.Label.Length + 1, 8);
      cmb.Title = "SELECIONE O CLIENTE";
      cmb.Width = 20;
      cmb.Height = 1;
      cmb.TextAlign = CSTextAlign.RIGHT ;
      cmb.TabIndex = 3;

      //dt  = createTable("select codigo, nome as descricao from contatos where codigo in (select fornecedor from pedidoscompra) and id in (select contatoid from contatos_contato) order by nome asc");
      //fill(dt, cmb);
      //for (int i = 1; i < 50; i++)
      //  cmb.addOption("" + i, "" + i);
      cmb.onOptionSelected += new onOptionSelected(cmb_selected);

      cmb1 = new CSCombo(this, "cmbcliente1", lbl3.Label.Length + 1, 9);
      cmb1.Title = "COMBO 2";
      cmb1.Width = 20;
      cmb1.Height = 1;
      cmb1.TextAlign = CSTextAlign.RIGHT;
      cmb1.TabIndex = cmb.TabIndex + 1;
      //cmb1.addOption("10925", "TUBOS");
      //cmb1.addOption("10926", "RARIDADE");
      //cmb1.addOption("10927", "RARO");
      cmb1.onOptionSelected += new onOptionSelected(cmb1_selected);

      cmb2 = new CSCombo(this, "cmbcliente3", lbl3.Label.Length + 1, 10);
      cmb2.Title = "COMBO 3";
      cmb2.Width = 20;
      cmb2.Height = 1;
      cmb2.TabIndex = cmb1.TabIndex + 1;
      cmb2.TextAlign = CSTextAlign.RIGHT;
      //cmb2.addOption("10001", "3M");
      //cmb2.addOption("10920", "BOSCH");
      //cmb2.addOption("10921", "ACDELCO");
      cmb2.onOptionSelected += new onOptionSelected(cmb2_selected);
      

      lbl = new CSLabel(this, "lblnome", 1, 5);
      lbl.Label = "NOME: ";
      lbl2 = new CSLabel(this, "lblnomeA", 1, 6);
      lbl2.Label = "ENDERECO: ";
      txt = new CSText(this, "txtNome", lbl.PosX + lbl.Label.Length, 5);
      txt.TabIndex = 1;
      txt.MaxLength = (50);
      txt2 = new CSText(this, "txtEndereco", lbl2.PosX + lbl2.Label.Length, 6);
      txt2.TabIndex = 2;
      txt2.MaxLength = (50);

      btn2 = new CSButton(this, "btnok111", 2, 15);
      btn2.Label = " OK ";
      btn2.TabIndex = cmb2.TabIndex+1;
      btn2.Width = 8;

      btn = new CSButton(this, "btnmensagem", 5, 15);
      btn.Label = " MSGBOX ";
      btn.TabIndex = btn2.TabIndex+1;
      btn.Width = 8;


      btn3 = new CSButton(this, "btnfoco", 15, 15);
      btn3.Label = " FOCO ";
      btn3.TabIndex = btn.TabIndex + 1;
      btn3.Width = 8;
      btn3.HotKey = ConsoleKey.F10;
      btn3.onClick += new onClick(btn3_onClick);


      // add to the form
      addComponent(lbl3);
      addComponent(cmb);
      addComponent(cmb1);
      addComponent(cmb2);
      addComponent(btn2);
      addComponent(btn);
      addComponent(lbl);
      addComponent(lbl2);
      addComponent(txt);
      addComponent(txt2);
      addComponent(btn3);

      // events
      btn2.onClick += new onClick(btnOK2_onClick);
      btn.onClick += new onClick(btnMsg_onClick );
      //cmb.onOptionSelected += new onOptionSelected(cmb_onOptionSelected);

    }

    public void cmb_onOptionSelected(object sender, int index)
    {

      CSCombo cs = (CSCombo) sender;
      string text = cs.OptionText(index); //pega valor do texto por indice
      string value = cs.OptionValue(index); //pega valor do texto por indice
      txt.Text = text + value;
      
      //limpa segundo combo
      cmb2.Clear();
      
      //adiciona a opção selecionada em outro combo
      cmb2.addOption(value, text);

      //TuboApplication.frmMain.Show();
      
    }

    public void btnMsg_onClick(object sender)
    {
      showMessageBox("minha msg", "ESCOLHA", " ESCOLHA SUA OPCAO "+TuboApplication.frmMain.txt2.Text, MessageButton.SimNao  );
    }
    public override void MessageBoxPressed(string key, MessageButton button)
    {
      if (button == MessageButton.Yes)
      {
        txt.Text = "FOI YES";
      }
      else if (button == MessageButton.No)
      {
         txt.Text = "FOI NO"; 
      }
      this.txt2.Focus();
      
    }
    

    public void btnOK2_onClick(object sender)
    {
      TuboApplication.frmSelecao.Hide(); 
      TuboApplication.frmMain.Show();
    }
    public void btn3_onClick(object sender)
    {
      cmb.Focus();
    }
    

    public void cmb_selected(object sender, int index)
    {
      //carregar de acordo
      if (cmb.SelectedValue != "")
      {
        cmb1.Clear();
        dt = createTable("select cnt.codigo, ct.nome as descricao from contatos_contato ct inner join contatos cnt on ct.contatoid = cnt.id where cnt.codigo = '" + cmb.SelectedValue  + "' order by cnt.nome");
        fill(dt, cmb1);
        cmb1.Focus();
      }

    }

    public void cmb1_selected(object sender, int index)
    {
      if (cmb.SelectedValue != "")
      {
        cmb2.Clear();
        dt = createTable("select cast(pedido as varchar(25)) as codigo, cast(pedido as varchar(25))  as descricao from pedidoscompra where fornecedor = '" + cmb1.SelectedValue + "' order by data_pedido desc");
        fill(dt, cmb2);
        cmb2.Focus();
      }
    }

    public void cmb2_selected(object sender, int index)
    {
      if (cmb2.SelectedValue != "")
      {
        //btnOK2_onClick
        txt.Text = cmb2.OptionText(index);
        cmb.Focus();
      }
    }

    private DataTable createTable(string sql)
    {
      /*
      




       * */
      if (cnn==null){

        cnn = new OleDbConnection("provider=sqloledb;server=sqlserver;uid=sa;pwd=senha;database=erp");
        cnn.Open();   
      
      
      }
      OleDbCommand cmd = new OleDbCommand(sql, cnn);
      OleDbDataAdapter ada = new OleDbDataAdapter(cmd);
      DataSet ds = new DataSet();
      ada.Fill(ds);
      return(ds.Tables[0]);
    }

    private void fill(DataTable dt, CSCombo cmb)
    {
      for (row=0;row<dt.Rows.Count-1;row++) {
        cmb.addOption((string) dt.Rows[row]["codigo"], (string) dt.Rows[row]["descricao"]);
      }
    }

  }
}
