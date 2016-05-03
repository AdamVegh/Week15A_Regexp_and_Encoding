using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace InputValidation
{

	public partial class FormValidator : Form
	{
		public FormValidator()
		{
			InitializeComponent();
		}

		void btnSave_Click(object sender, EventArgs e)
		{
			string namePattern = @"^(\w+\s*)+$";
			string phonePattern = @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$";
			string emailPattern = @"^([a-zA-Z0-9_\-\.]+)@
								  ((\[([0-9]{1,3}\.){3})|(([a-zA-Z0-9\-]+\.)+))
								  ([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

			if (!Regex.IsMatch(txtName.Text, namePattern))
				MessageBox.Show("The name is invalid (only alphabetical characters are allowed)");
			else
				txtName.Text = ReformatName(txtName.Text);

			if (!Regex.IsMatch(txtPhone.Text, phonePattern))
				MessageBox.Show("The phone number is not a valid US phone number");
			else
				txtPhone.Text = ReformatPhone(txtPhone.Text, phonePattern);

			if (!Regex.IsMatch(txtEmail.Text, emailPattern))
				MessageBox.Show("The e-mail address is not valid.");
		}

		static string ReformatName(string s)
		{
			string space = Regex.Replace(s, @"\s+", " ");
			return new Regex(@"\b[A-Z]", RegexOptions.IgnoreCase).Replace(space, m=>m.ToString().ToUpper());
		}

		static string ReformatPhone(string s, string pattern)
		{
			Match m = Regex.Match(s, pattern);
			return string.Format("({0}) {1}-{2}", m.Groups[1], m.Groups[2], m.Groups[3]);
		}
	}
}
