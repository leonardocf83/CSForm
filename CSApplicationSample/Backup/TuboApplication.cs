using System;
using System.Collections.Generic;
using System.Text;
using CSForms;

namespace CSApplicationSample
{
  public class TuboApplication
  {

    public static frmMain frmMain = new frmMain("main");
    public static frmSelecao frmSelecao = new frmSelecao("tubos");
    public static frmMenu frmMenu = new frmMenu("menu"); 

    public void iniciar()
    {
      frmMain.Show();            
    }
      
    

  }
}

