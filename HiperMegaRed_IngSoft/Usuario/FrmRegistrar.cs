using HiperMegaRed.BE;
using HiperMegaRed.BLL;
using HiperMegaRed.Services;
using HiperMegaRed.DAL.MultiLenguaje;
using HiperMegaRed.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiperMegaRed_IngSoft.Usuario
{
    public partial class FrmRegistrar : Form
    {
        private readonly SessionBLL sessionBLL = SessionBLL.GetInstance();
        private readonly UserBLL userBLL = UserBLL.Instance;

        private void ClearData()
        {
            txtName.Text = txtLastname.Text = txtUsername.Text = txtPassword.Text = txtMail.Text = txtPhone.Text = txtDNI.Text = "";
            lblError.Text = "";
            lblError.Visible = false;
        }
        public FrmRegistrar()
        {
            InitializeComponent();
            TraducirTextos();
            MultiLang.SubscribeChangeLangEvent(TraducirTextos);
        }
        private void TraducirTextos()
        {
            WinformUtils.TraducirControl(this);
        }

        private bool ValidatePassword(string password)
        {
            var input = password;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void FrmRegistrar_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtUsername.Text) || string.IsNullOrWhiteSpace(this.txtPassword.Text)
                || string.IsNullOrWhiteSpace(this.txtDNI.Text) || string.IsNullOrWhiteSpace(this.txtName.Text)
                || string.IsNullOrWhiteSpace(this.txtLastname.Text) || string.IsNullOrWhiteSpace(this.txtPhone.Text)
                || string.IsNullOrWhiteSpace(txtMail.Text))
            {
                throw new ValidationException("Complete todos los campos");
            }  
            //else if (!ValidatePassword(txtPassword.Text))
            //{
            //    throw new ValidationException("La contraseña debe de contener: \nAl menos 1 minuscula. \nAl menos 1 mayuscula.\nAl menos 1 numero.\nAl menos un simbolo.");
            //} 
            else
            {
                var usuario = new User(txtUsername.Text, txtPassword.Text);
                usuario.DNI = long.Parse(txtDNI.Text);
                usuario.Name = this.txtName.Text;
                usuario.Lastname = this.txtLastname.Text;
                usuario.Mail = this.txtMail.Text;
                usuario.Phone = this.txtPhone.Text;
                try
                {
                    userBLL.Register(usuario);
                    MessageBox.Show("Usuario registrado correctamente");
                    ClearData();
                }
                catch (ValidationException ve)
                {
                    lblError.Text = ve.Message;
                    lblError.Visible = true;
                }
            }

        }
    }
}
