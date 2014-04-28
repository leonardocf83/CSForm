using System;
using System.Collections.Generic;
using System.Text;
using CSForms;
using System.Runtime.InteropServices;


namespace CSApplicationSample
{
  public class frmMain: CSForm
  {

    public CSButton btn;
    public CSButton btnSair;
    public CSButton btnMenu;
    public CSText txt;
    public CSLabel lbl2;
    public CSText txt2;
    public CSLabel lbl; 

    public frmMain(string name) : base(name)
    {
      
      this.Caption = "TELA PRINCIPAL";
      
      lbl = new CSLabel(this, "lblnomeA", 1, 10);
      lbl.Label = "NOME:     ";
      lbl2 = new CSLabel(this, "lblnome", 1, 11);
      lbl2.Label="ENDERECO:";
      lbl2.Width = 15;
      lbl2.TextAlign = CSTextAlign.RIGHT;
      txt = new CSText(this, "txtNome", lbl.PosX + lbl.Width, 10);
      txt.Filter = new InputFilter();
      txt.TabIndex = 1;
      //txt.Type = CSTextBoxType.NUMERIC;
      //txt.FormatString = "0,00";
      txt.MaxLength = (10);
      //txt.Enabled = false;
      txt.Text = " CASA ";
      txt.TextAlign = CSTextAlign.CENTER;
      txt.Filter = new InputFilter();
            
      //txt.FormatString = "N2";
      //txt.PasswordChar = "*";
      
      txt.Width = 20;

      txt.onKeyPress += new onKeyPress(txt_onKeyPress);
      txt2 = new CSText(this, "txtEndereco", lbl2.PosX + lbl2.Width, 11);
      txt2.TabIndex = 2;
      txt2.MaxLength = (50);
      //txt2.InputControlMethod = CSInputControlMethod.READLINE;
     // txt2.Type = CSTextBoxType.DATE;
      //txt.

      //txt2.Enabled = false;

      //button sample
      btn = new CSButton(this, "btnok", 5, 15);
      btn.Label ="COMBO";
      btn.TabIndex = 3;
      btn.Width = 8;
      btn.HotKey = ConsoleKey.F2;
      //btn.Enabled = false;

      //exit sample
      btnSair = new CSButton(this, "btnexit", 15, 15);
      btnSair.Label = "SAIR";
      btnSair.TabIndex = 4;
      btnSair.Width = 8;
      btnSair.HotKey = ConsoleKey.F12;

      // menu
      btnMenu = new CSButton(this, "btnmenu", 25, 15);
      btnMenu.Label = " MENU";
      btnMenu.TabIndex = 5;
      btnMenu.Width = 10;
      btnMenu.HotKey = ConsoleKey.F10;
      
      //add to the form
      addComponent(lbl);
      addComponent(lbl2);
      addComponent(txt);
      addComponent(txt2);
      addComponent(btn);
      addComponent(btnSair);
      addComponent(btnMenu);

      //events
      btnSair.onClick += new onClick(btnExit_onClick);
      btn.onClick += new onClick(btnOK_onClick);
      btnMenu.onClick += new onClick(btnMenu_onClick);

    }
    public void txt_onKeyPress(object sender, ConsoleKeyInfo key)
    {
      if (key.Key  == ConsoleKey.DownArrow || key.Key == ConsoleKey.Enter)
      {
        // move para proximo campo
        txt2.Focus();
        //TuboApplication.frmSelecao.txt2.Text = "HI GUYS";
        //btnMenu.Focus();        
      }
    }
    public void btnMenu_onClick(object sender)
    {
      TuboApplication.frmMain.Hide();
      TuboApplication.frmMenu.Show();
    }

    //button event sample
    public void btnOK_onClick(object sender)
    {
     // ObterSenhaVB("AUTSR1");
      TuboApplication.frmMain.Hide();
      TuboApplication.frmSelecao.Show();
      //txt.Focus();
    }
    public void btnExit_onClick(object sender)
    {
      Environment.Exit(0);
    }

    [DllImport("util.dll")]
    public static extern char ObterSenhaVB(string m);



  }
  class InputFilter: CSTextFilter 
  {
    public override bool Allowed(ConsoleKeyInfo key, CSText text)
    {
      if (key.KeyChar == 'T')
      {
        return false;
      }
      return true;
    }
  }

}
