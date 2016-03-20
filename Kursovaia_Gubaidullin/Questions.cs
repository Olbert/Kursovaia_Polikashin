using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace Kursovaia_Gubaidullin
{

    public partial class Questions : Form
    {
        public Questions()
        {
            InitializeComponent();
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader("Kursovaia.Info");
                CCompilerPath = file.ReadLine();
                SCompilerPath = file.ReadLine();
                //PCompilerPath = file.ReadLine();
                GameTheory = Convert.ToBoolean(file.ReadLine());
                file.Close();
            }
            catch (Exception ex) { }
        }
    }

}
