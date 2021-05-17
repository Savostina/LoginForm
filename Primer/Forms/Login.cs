﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primer.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(textBoxLogin.Text) || (string.IsNullOrWhiteSpace(maskedTextBoxPas.Text) ||
                    (string.IsNullOrEmpty(maskedTextBoxPas.Text) || (string.IsNullOrWhiteSpace(textBoxLogin.Text))))))
                    throw new Exception();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Заполните все поля", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (var context = new EntityCodeFirst.EntityContext())
                {
                    var user = context.Userdate.FirstOrDefault(u => u.Login == textBoxLogin.Text && u.Password == maskedTextBoxPas.Text);
                    if (user != null) 
                    { 
                        MessageBox.Show("Пользователь найден", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else throw new Exception();
                }
            }
            catch(Exception es) 
            {
                MessageBox.Show("Ошибка", "Пользователь не найден", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void checkBoxPasOpenClose_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPasOpenClose.Checked)
            {
                maskedTextBoxPas.PasswordChar = '\0';
            }
            else maskedTextBoxPas.PasswordChar = '*';
        }
    }
}
