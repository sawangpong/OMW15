using OMW15.Models.ToolModel;
using OMW15.Shared;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OMW15.Views.ToolViews
{
	public partial class UserLogin : Form
	{

		#region class field

		private const int _groupHeight = 190;
		private const int _parentHeight = 540;

		//private LOGINEF  _log;

		private readonly string _machineName = Environment.MachineName;

		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd,
			int Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		private static bool _incorrectUserName = true;
		private static bool _incorrectPassword = true;

		private LOGIN login;

		#endregion

		#region class property

		public int UserId { get; set; }

		public int PermissionId { get; set; }

		public string PermissionClass { get; set; }


		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnLogin.Enabled = !string.IsNullOrEmpty(txtUserName.Text);
		} // end UpdateUI

		private int GetUserPermission(string UserName, string Password, out int workgroup)
		{
			var _permissionId = 0;

			// check valid user
			login = new LoginDAL().CheckValidUserName(UserName);

			if (login == null)
			{
				_incorrectUserName = true;
				_incorrectPassword = true;
				_permissionId = 0;
				this.UserId = 0;
				workgroup = 0;
				this.PermissionClass = string.Empty;
				MessageBox.Show("ชื่อผุ้ใช้งานไม่ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return _permissionId;
			}
			else if (login.password == Password)
			{
				_incorrectUserName = false;
				_incorrectPassword = false;
				_permissionId = login.permissionid;
				PermissionClass = login.auditclass;
				workgroup = login.DepartmentID.Value;
				return _permissionId;
			}
			else
			{
				_incorrectUserName = false;
				_incorrectPassword = true;
				this.UserId = 0;
				_permissionId = 0;
				PermissionClass = string.Empty;
				workgroup = 0;
				MessageBox.Show("รหัสผ่านไม่ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return _permissionId;
			}

		} // end GetUserPermission

		private int GetNewUserId()
		{
			var _userInfo = new USERLOG();
			_userInfo.APPNAME = omglobal.APP_NAME;
			_userInfo.APPVERSION = Application.ProductVersion;
			_userInfo.AUDITCLASS = PermissionClass;
			_userInfo.DATABASENAME = omglobal.SysDatabase;
			_userInfo.LOGINDT = DateTime.Now;
			_userInfo.SERVERNAME = omglobal.SysServer;
			_userInfo.USERNAME = txtUserName.Text;
			_userInfo.WORKSTATION = _machineName;

			var _newId = new LoginDAL().GetNewUserId(_userInfo);

			// log
			omglobal._log.AppendLine($"{++omglobal.logLine,-10} Get new User id = {_newId}");

			return _newId;
		} // end GetNewUserId

		private void GetCurrentConfigFromShareParameter()
		{
			txtMainServer.Text = omglobal.SysServer;
			txtSysDatabase.Text = omglobal.SysDatabase;
			txtERPServer.Text = omglobal.ERPServer;
			txtERPDatabase.Text = omglobal.ERPDatabase;
		} // end GetCurrentConfig

		#endregion

		// CONSTRUCTOR
		public UserLogin()
		{
			InitializeComponent();
			SetStyle(
				ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint |
				ControlStyles.AllPaintingInWmPaint, true);

			BackColor = omglobal.OM_LOGIN_PAGE_COLOR;
			rpnlHeader.BackColor = omglobal.OM_LOGIN_PAGE_COLOR;
			cgrb1.Collapsed = true;

			omglobal.GetCurrentConfig();

			Invalidate();
		}

		private void UserLogin_Load(object sender, EventArgs e)
		{
			// display current Configuration from registry
			GetCurrentConfigFromShareParameter();

			// get user name from default environment
			// production programm
			txtUserName.Text = ""; 

			// testing programm - auto input username
			//txtUserName.Text = "sawangpong";
			
			txtPassword.Text = string.Empty;
			lbProductInfo.Text = $"Product : {omglobal.AssemblyInformation}";
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtUserName.Focus();
		}

		private void txtUserName_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			if ((PermissionId = GetUserPermission(txtUserName.Text, txtPassword.Text, out omglobal.WorkGroupId)) > 0)
			{
				omglobal.UserName = txtUserName.Text;
				omglobal.PassWord = txtPassword.Text;
				omglobal.WorkStation = _machineName;
				omglobal.PermisionId = PermissionId;
				omglobal.PermissionClass = PermissionClass;
				omglobal.UserInfo = $"{omglobal.WorkStation}::{omglobal.UserName}";
				this.UserId = GetNewUserId();

				if (this.UserId > 0)
				{
					this.Close();
				}
			}
			else
			{
				this.UserId = 0;
				if (_incorrectUserName)
				{
					this.txtUserName.Text = "";
					this.txtUserName.Focus();
				}

				if (_incorrectPassword)
				{
					this.txtPassword.Text = "";
					this.Focus();
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.UserId = 0;
		}

		private void txt_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
				btnLogin.PerformClick();
		}

		private void lklbChangeAppConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			using (var _configMgr = new ConfigManager(omglobal.APP_REGISTRY_SUBKEY))
			{
				_configMgr.Mode = ActionMode.Edit;
				_configMgr.StartPosition = FormStartPosition.CenterParent;
				_configMgr.ShowDialog(this);

				// re-load Current Configuration
				GetCurrentConfigFromShareParameter();
			}
		}

		private void UserLogin_FormClosing(object sender, FormClosingEventArgs e)
		{
			//_om.Dispose();
		}

		private void UserLogin_Paint(object sender, PaintEventArgs e)
		{
			var CornerRadius = 25;
			var _rec = ClientRectangle;
			using (var gp = new GraphicsPath())
			{
				var top = 0;
				var left = 0;
				var right = Width;
				var bottom = Height;

				gp.AddArc(left, top, CornerRadius, CornerRadius, 180, 90);
				gp.AddArc(right - CornerRadius, top, CornerRadius, CornerRadius, 270, 90);
				gp.AddArc(right - CornerRadius, bottom - CornerRadius,
					CornerRadius, CornerRadius, 0, 90);
				gp.AddArc(left, bottom - CornerRadius, CornerRadius, CornerRadius, 90, 90);
				gp.CloseAllFigures();
				Region = new Region(gp);
			}
		}

		private void UserLogin_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		private void UserLogin_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.X <= 2 && e.Y <= 2 || e.X + 2 >= Width && e.Y + 2 >= Height)
				Cursor = Cursors.SizeNWSE;
			else if (e.X + 2 >= Width && e.Y <= 2 || e.X <= 2 && e.Y + 2 >= Height)
				Cursor = Cursors.SizeNESW;
			else if (e.X <= 2 || e.X + 2 >= Width)
				Cursor = Cursors.SizeWE;
			else if (e.Y <= 2 || e.Y + 2 >= Height)
				Cursor = Cursors.SizeNS;
			else
				Cursor = Cursors.Default;
		}

		private void cgrb1_CollapsedChanged(object sender, EventArgs e)
		{
			if (cgrb1.Collapsed)
				Size = new Size(Size.Width, _parentHeight - _groupHeight);
			else
				Size = new Size(Size.Width, _parentHeight);
			StartPosition = FormStartPosition.CenterParent;
		}


	}
}