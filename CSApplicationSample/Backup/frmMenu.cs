using System;
using System.Collections.Generic;
using System.Text;
using CSForms;




namespace CSApplicationSample
{
  public class frmMenu : CSForm
  {

    public CSMenu menu;

    public frmMenu(string name)
      : base(name)
    {

      this.Caption = "MENU DO SISTEMA";

      menu = new CSMenu(this, "mnu", 5, 5);
      menu.addOption(1, "Primeira opcao.");
      menu.addOption(2, "Segunda opção.");
      menu.addOption(3, "Terceira opção.");
      menu.addOption(4, "Terceira opção.");
      menu.addOption(5, "Terceira opção.");
      menu.addOption(6, "Terceira opção.");
      menu.addOption(7, "Terceira opção.");
      menu.addOption(8, "Terceira opção.");
      menu.addOption(9, "Terceira opção.");
      menu.addOption(10, "Terceira opção.");
      menu.Width = this.Width;
      menu.Height = 15;
      menu.Title = "Enviar";
      //menu.VisibleCount = 10;

      // add to the form
      addComponent(menu);
      menu.onChoose += new onChoose(mnuChoose);

      // events
      //btn2.onClick += new onClick(btnOK2_onClick);
      //btn.onClick += new onClick(btnMsg_onClick );

    }

    public void mnuChoose(object sender, short option)
    {
      this.Hide();
      TuboApplication.frmMain.Show();
    }


    public override void MessageBoxPressed(string key, MessageButton button)
    {
      //txt.Text = key; 
      
    }



  }
}



//namespace CSApplicationSample
//{
//  public class frmMenu : CSForm
//  {

//    public CSMenu menu;
//    public string[] _strVALORES = new string[7];

//    public frmMenu(string name)
//      : base(name)
//    {
//      int _intQTD = 0;
//      short _intX;


//      this.Caption = "Tela C - Menu do Sistema";

//      _intQTD = _strVALORES.GetLength(0);

//      menu = new CSMenu(this, "mnu", 5, 5);


//      for (_intX = 1; _intX <= _intQTD; _intX++)
//      {
//        menu.addOption(_intX, _strVALORES[_intX - 1]);
//      }

//      menu.Width = this.Width;
//      menu.Height = 15;
//      menu.Title = "Menu";

//      // add to the form
//      if (_intQTD > 0)
//      {
//        addComponent(menu);
//        menu.onChoose += new onChoose(mnuChoose);
//      }

//      // events
//      //btn2.onClick += new onClick(btnOK2_onClick);
//      //btn.onClick += new onClick(btnMsg_onClick );

//    }

//    public void mnuChoose(object sender, short option)
//    {
//      this.Hide();
//      TuboApplication.frmMain.Show();
//    }


//    public override void MessageBoxPressed(string key, MessageButton button)
//    {
//      //txt.Text = key; 
//    }


//    public void Show()
//    {

//      //faca o carregamento de suas opcoes aqui.
//      int _intQTD = 0;
//      short _intX;


//      this.Caption = "Tela C - Menu do Sistema";

//      _intQTD = _strVALORES.GetLength(0);

//      menu = new CSMenu(this, "mnu", 5, 5);


//      for (_intX = 1; _intX <= _intQTD; _intX++)
//      {
//        menu.addOption(_intX, _strVALORES[_intX - 1]);
//      }

//      menu.Width = this.Width;
//      menu.Height = 15;
//      menu.Title = "Menu";

//      // add to the form
//      if (_intQTD > 0)
//      {
//        addComponent(menu);
//        menu.onChoose += new onChoose(mnuChoose);
//      }

//      // chame o Show na superclasse, que ira redsenhar de acordo
//      base.Show();

//    }




//  }
//}
