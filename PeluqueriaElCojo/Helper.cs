using System.Drawing;
using System.Windows.Forms;

public static class FormHelper
{
    public static void PosicionFija(Form f)
    {
        f.StartPosition = FormStartPosition.Manual;
        f.Location = new Point(300, 150);
    }
}