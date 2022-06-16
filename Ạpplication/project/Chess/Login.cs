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
    public partial class Login : Form
    {
        public class Data
        {
            public string token { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string score { get; set; }
        }

        public class Root
        {
            public bool success { get; set; }
            public Data data { get; set; }
            public string message { get; set; }
        }
        public Login()
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidEmail(txt_User.Text))
            {
                // Create a request using a URL that can receive a post.
                WebRequest request = WebRequest.Create("http://dxl.wiki/api/login");
                // Set the Method property of the request to POST.
                request.Method = "POST";
                // Create POST data and convert it to a byte array.
                string postData = "email=" + txt_User.Text
                            + "&password=" + txt_Pass.Text;
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
                try
                {
                    lbl_Check.Text = "";
                    // Get the response.
                    WebResponse response = request.GetResponse();
                    Root datajson;
                    // Get the stream containing content returned by the server.
                    // The using block ensures the stream is automatically closed.
                    using (dataStream = response.GetResponseStream())
                    {
                        // Open the stream using a StreamReader for easy access.
                        StreamReader reader = new StreamReader(dataStream);
                        // Read the content.
                        string responseFromServer = reader.ReadToEnd();
                        // Display the content.
                        datajson = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(responseFromServer);
                        this.Hide();
                        MainForm p = new MainForm();
                        p.ShowDialog();
                        this.Show();
                    }
                    // Close the response.
                    response.Close();
                    request.Abort();
                }
                catch (Exception)
                {
                    lbl_Check.Text = "Đăng nhập không thành công.";
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txt_User.Text = "20520619@gm.uit.edu.vn";
            txt_Pass.Text = "FnKL6upRv7uhvQ5Mj";
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            Register p = new Register();
            p.Show();
        }
    }
}
