using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        FrmDashboard frm = new FrmDashboard();

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş geçilemez", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            using (var context = new FinancialCrmDbEntities())
            {
                var user = context.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
                if (user != null)
                {
                    MessageBox.Show("Giriş onaylandı");
                    frm.Show();

                }
                else
                {
                    MessageBox.Show("Giriş Bilgileriniz Hatalı Lütfen Tekrar Deneyiniz");
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
