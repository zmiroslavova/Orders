using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Orders
{
    public partial class Form_order : Form
    {
        public Form_order()
        {
            InitializeComponent();
            this.ActiveControl = textBox_numberOrder;
            textBox_numberOrder.Focus();

            this.button_save.Enabled = false;
            this.button_review.Enabled = true;
        }

        private void validateFields()
        {
            if (textBox_numberOrder.Text == "" ||
               textBox_client.Text == "" ||
               textBox_mobNumber.Text == "" ||
               textBox_email.Text == "" ||
               textBox_articleNumber.Text == "")
            {
                MessageBox.Show("Моля попълнете празните полета");
            }

            if (textBox_numberMedalsGold.Text == "" ||
                textBox_numberMedalsSilver.Text == "" ||
                textBox_numberMedalsBronze.Text == "")
            {
                MessageBox.Show("Ако не желаете от този вид медал запишете 0 (нула)");
            }

            if (!(textBox_email.Text.Contains("@")))
            {
                MessageBox.Show("Въведете коректно email адреса");
                return;
            }

            if (!(textBox_email.Text.Contains(".")))
            {
                MessageBox.Show("Въведете коректно email адреса");
                return;
            }

            if (textBox_email.Text.Contains(" "))
            {
                MessageBox.Show("Въведете коректно email адреса");
                return;
            }
        }

        private int totalMedals()
        {
            return int.Parse(textBox_numberMedalsGold.Text)
                + int.Parse(textBox_numberMedalsSilver.Text)
                + int.Parse(textBox_numberMedalsBronze.Text);
        }
        
        private void textBox_numberOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox_client.Focus();
            }
        }

        private void textBox_client_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox_mobNumber.Focus();
            }
        }

        private void textBox_mobNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox_email.Focus();
            }
        }

        private void textBox_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox_articleNumber.Focus();
            }
        }

        private void textBox_articleNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox_numberMedalsGold.Focus();
            }
        }

        private void textBox_numberMedalsGold_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox_numberMedalsSilver.Focus();
            }
        }

        private void textBox_numberMedalsSilver_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox_numberMedalsBronze.Focus();
            }
        }

        private void textBox_numberMedalsBronze_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                richTextBox_textFront.Focus();
            }
        }

        private void richTextBox_textFront_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                richTextBox_textBack.Focus();
            }
        }

        private void richTextBox_textBack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_review.PerformClick();
            }
        } 
                                
        private void button_review_Click(object sender, EventArgs e)
        {
            this.button_save.Enabled = true;

            validateFields();

            string output;
            output = "Номер поръчка: " + this.textBox_numberOrder.Text + "\r\n";
            output += "Клиент: " + this.textBox_client.Text + "\r\n";
            output += "Телефонен номер: " + this.textBox_mobNumber.Text + "\r\n";
            output += "Имейл: " + this.textBox_email.Text + "\r\n"; 
            
            if(checkBox_invoice.Checked)
                output += "Желае ли фактура: Да \r\n";
            else
                output += "Желае ли фактура: Не \r\n";

            if(radioButton_company.Checked)
                output += "Юридическо лице \r\n";
            else
                output += "Физическо лице \r\n";

            if(radioButton_paymentCash.Checked == true)
                output += "Вид плащане: В брой \r\n";
            if (radioButton_paymentCard.Checked == true)
                output += "Вид плащане: С карта \r\n";
            if (radioButton_paymentBank.Checked == true)
                output += "Вид плащане: По банков път \r\n";

            output += "Артикулен номер: " + this.textBox_articleNumber.Text + "\r\n";
            output += "Брой златни: " + this.textBox_numberMedalsGold.Text + "\r\n";
            output += "Брой сребърни: " + this.textBox_numberMedalsSilver.Text + "\r\n";
            output += "Брой бронзови: " + this.textBox_numberMedalsBronze.Text + "\r\n";
            output += "Общ брой медали: " + totalMedals().ToString() + "\r\n";
        
            if (radioButton_stripYes.Checked)
                output += "Брой ленти: " + totalMedals().ToString() + "\r\n";
            else
                output += "Ленти: Без \r\n";

            if (radioButton_stripYes.Checked == true)
            {
                if (radioButton_stripColorBlue.Checked == true)
                    output += "Цвят ленти: Сини \r\n";
                if (radioButton_stripColorRed.Checked == true)
                    output += "Цвят ленти: Червени  \r\n";
                if (radioButton_stripColorTricolor.Checked == true)
                    output += "Цвят ленти: Трикольор \r\n";
            }    
            output += "Надпис на лице: " + this.richTextBox_textFront.Text + "\r\n";
            output += "Надпис на гръб: " + this.richTextBox_textBack.Text + "\r\n";
            this.richTextBox_finalPreview.Text = output;            
        } 

        private void textBox_numberOrder_TextChanged(object sender, EventArgs e)
        {
            Boolean match = System.Text.RegularExpressions.Regex.IsMatch(textBox_numberOrder.Text, "^[0-9]*$");
            if (match == false)
            {
                textBox_numberOrder.Text = RemoveNonNumbersFromString(textBox_numberOrder.Text);
            }
        }

        private void textBox_mobNumber_TextChanged(object sender, EventArgs e)
        {
            Boolean match = System.Text.RegularExpressions.Regex.IsMatch(textBox_mobNumber.Text, "^[0-9]*$");
            if (match == false)
            {
                textBox_mobNumber.Text = RemoveNonNumbersFromString(textBox_mobNumber.Text);
            }
        }        

        private void textBox_articleNumber_TextChanged(object sender, EventArgs e)
        {
            Boolean match = System.Text.RegularExpressions.Regex.IsMatch(textBox_articleNumber.Text, "^[0-9]*$");
            if (match == false)
            {
                textBox_articleNumber.Text = RemoveNonNumbersFromString(textBox_articleNumber.Text);
            }        
        }

        private void textBox_numberMedalsGold_TextChanged(object sender, EventArgs e)
        {
            Boolean match = System.Text.RegularExpressions.Regex.IsMatch(textBox_numberMedalsGold.Text, "^[0-9]*$");
            if (match == false)
            {
                textBox_numberMedalsGold.Text = RemoveNonNumbersFromString(textBox_numberMedalsGold.Text);
            }
        }

        private void textBox_numberMedalsSilver_TextChanged(object sender, EventArgs e)
        {
            Boolean match = System.Text.RegularExpressions.Regex.IsMatch(textBox_numberMedalsSilver.Text, "^[0-9]*$");
            if (match == false)
            {
                textBox_numberMedalsSilver.Text = RemoveNonNumbersFromString(textBox_numberMedalsSilver.Text);
            }
        }

        private void textBox_numberMedalsBronze_TextChanged(object sender, EventArgs e)
        {
            Boolean match = System.Text.RegularExpressions.Regex.IsMatch(textBox_numberMedalsBronze.Text, "^[0-9]*$");
            if (match == false)
            {
                textBox_numberMedalsBronze.Text = RemoveNonNumbersFromString(textBox_numberMedalsBronze.Text);
            }
        }
        
        public static string RemoveNonNumbersFromString(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }        

        private void button_save_Click(object sender, EventArgs e)
        {
            System.IO.TextWriter txt = new System.IO.StreamWriter("Order.txt");
            txt.Write(richTextBox_finalPreview.Text);
            txt.Close();
            
            MessageBox.Show("Файла е записан в папката, в която се изпълнява приложенето");
        }
        
        private void button_new_Click(object sender, EventArgs e) => clear();

        void clear()
        {
            textBox_numberOrder.Clear();
            textBox_client.Clear();
            textBox_mobNumber.Clear();
            textBox_email.Clear();
            textBox_articleNumber.Clear();
            textBox_numberMedalsGold.Clear();
            textBox_numberMedalsSilver.Clear();
            textBox_numberMedalsBronze.Clear();
            richTextBox_textFront.Clear();
            richTextBox_textBack.Clear();
            richTextBox_finalPreview.Clear();

            textBox_numberOrder.Focus();
        }
        
        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_order_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }       
    }
}
