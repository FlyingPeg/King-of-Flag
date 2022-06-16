using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;

namespace Chess
{
    public partial class Register : Form
    {
        public class Data
        {
            public string token { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public int score { get; set; }
        }

        public class Root
        {
            public bool success { get; set; }
            public Data data { get; set; }
            public string message { get; set; }
        }
        public Register()
        {
            InitializeComponent();
            InitializeMyControl();
        }
        private void InitializeMyControl()
        {
            // Set to no text.
            txt_Pass.Text = "";
            // The password character is an asterisk.
            txt_Pass.PasswordChar = '*';
            txt_CfPass.Text = "";
            txt_CfPass.PasswordChar = '*';
        }
        private int check;
        private bool Valid()
        {
            check = 0;
            if (IsValidEmail(txt_Email.Text)
                    && txt_Email.Text.Length <= 40
                    && txt_Email.Text.Length >= 11)
            {
                lb_MC.Text = "";
            }
            else
            {
                lb_MC.Text = "Email không hợp lệ";
                check--;
            }

            if (txt_Pass.Text.Length >= 8)
            {
                lb_PC.Text = "";
            }
            else
            {
                lb_PC.Text = "Phải nhập mật khẩu từ 8 kí tự trở lên";
                check--;
            }

            if (txt_Pass.Text == txt_CfPass.Text)
            {

                lb_CPC.Text = "";
            }
            else
            {
                check--;
                lb_CPC.Text = "Mật khẩu xác nhận không giống.";
            }

            if (txt_Name.Text != "")
            {
                lb_NC.Text = "";
            }
            else
            {
                check--;
                lb_NC.Text = "Họ và tên không hợp lệ";
            }
            if (check == 0) return true;
            else return false;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            txt_Email.Text = "123@gmail.com";
            txt_Name.Text = "Ngo Van Pham";
            txt_Pass.Text = "12345678";
            txt_CfPass.Text = "12345678";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbl_Check.Text = "";
            if (Valid())
            {
                // Create a request using a URL that can receive a post.
                WebRequest request = WebRequest.Create("http://dxl.wiki/api/register");
                // Set the Method property of the request to POST.
                request.Method = "POST";
                // Create POST data and convert it to a byte array.
                string postData = "email=" + txt_Email.Text
                            + "&password=" + txt_Pass.Text
                            + "&confirm_password=" + txt_CfPass.Text
                            + "&name=" + txt_Name.Text;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;

                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();

                // Get the response.
                try
                {
                    WebResponse response = request.GetResponse();              
                    lbl_Check.Text = "Đăng kí thành công.";
                    btn_Reg.FlatStyle = FlatStyle.Flat;
                    btn_Reg.FlatAppearance.BorderColor = BackColor;
                    btn_Reg.FlatAppearance.MouseOverBackColor = BackColor;
                    btn_Reg.FlatAppearance.MouseDownBackColor = BackColor;
                    btn_Reg.Enabled = false;
                    response.Close();
                }
                catch (Exception)
                {
                    lbl_Check.Text = "Email đã tồn tại.";
                }
                request.Abort();
            }
            else
                lbl_Check.Text = "Đăng kí không thành công.";
        }
    }
}
