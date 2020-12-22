using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OMW15.Models;
using OMW15.Models.ProductionModel;


namespace OMW15.Views.Productions
{
	public partial class BOM : Form
	{

		#region class field member
		private string selecteBomModel = string.Empty;
		private TreeNode topNode;
		private int selectedItemId = 0;
		private ListViewItem item;

		#endregion

		#region class helper

		private void updateUI()
		{
			this.tsbtnEdit.Enabled = (selectedItemId > 0);
		}

		private void getTopNode(string model)
		{
			this.tvBom.BeginUpdate();
			this.tvBom.Nodes.Clear();
			this.lvBom.Items.Clear();

			DataTable dt = new Models.ProductionModel.BOMDal().GetTopBomItem(model);

			// create ListViewColumns
			this.addListViewColumns(dt);

			// add top node
			topNode = new TreeNode(model);

			foreach (DataRow dr in dt.Rows)
			{
				// add item into ListViewItem
				item = new ListViewItem(dr["ID"].ToString());

				foreach (DataColumn dc in dt.Columns)
				{
					if (dc.Ordinal > 0)
					{
						item.SubItems.Add(dr[dc.ColumnName].ToString());
					}
				}

				this.lvBom.Items.Add(item);

				// add TreeView Node
				string t = dr["PARTNO"].ToString();
				TreeNode _node = new TreeNode(t);
				_node.Tag = dr["ID"].ToString();

				// add sub-node depending on node reference (tag)
				getSubNodes(model,
					dr["PARTNO"].ToString(),
					Convert.ToInt32(dr["PART_REV"]),
					Convert.ToInt32(dr["ID"]),
					ref _node);

				topNode.Nodes.Add(_node);
			};

			this.tvBom.Nodes.Add(topNode);
			this.tvBom.EndUpdate();
			this.tvBom.ExpandAll();

			this.lbNodeCount.Text = $"{tvBom.GetNodeCount(true)}";

		}

		private void getModelListFromBOM()
		{
			this.cbxModel.DataSource = new BOMDal().GetBomModel();
			this.cbxModel.DisplayMember = "MODEL";
			this.cbxModel.ValueMember = "MODEL";
		}

		private void getSubNodes(string model, string partno, int partRev, int parentId, ref TreeNode N)
		{
			DataTable dt = new Models.ProductionModel.BOMDal().GetBomItems(model, partno, partRev, parentId);

			if (dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					// add item into ListViewItem
					item = new ListViewItem(dr["ID"].ToString());
					foreach (DataColumn dc in dt.Columns)
					{
						if (dc.Ordinal > 0)
						{
							var l = string.IsNullOrEmpty(dr[dc.ColumnName].ToString()) ? "<NO DATA>" :
								dr[dc.ColumnName].ToString();
							item.SubItems.Add(l);
						}
					}
					this.lvBom.Items.Add(item);

					// add treeview node
					TreeNode node;
					string t = string.IsNullOrEmpty(dr["PARTNO"].ToString()) ? "<NO DATA>" : dr["PARTNO"].ToString();
					node = new TreeNode(t);
					node.Tag = dr["ID"].ToString();
					N.Nodes.Add(node);

					// add recursive method
					if (new BOMDal().GetNodeAvailable(model, dr["PARTNO"].ToString()))
					{
						try
						{
							this.getSubNodes(model,
								dr["PARTNO"].ToString(),
								Convert.ToInt32(dr["PART_REV"]),
								Convert.ToInt32(dr["ID"]),
								ref node);
						}
						catch (Exception ex)
						{
							throw new Exception("Error", ex);
						}
					}
				}
			}
		}


		private void addListViewColumns(DataTable dt)
		{
			this.lvBom.Columns.Clear();
			this.lvBom.BeginUpdate();

			foreach (DataColumn dc in dt.Columns)
			{
				ColumnHeader ch = new ColumnHeader();
				ch.Name = dc.ColumnName;
				switch (dc.DataType.ToString())
				{
					case "System.Decimal":
					case "System.Int32":
						ch.TextAlign = HorizontalAlignment.Right;
						ch.Width = 70;
						break;

					case "System.String":
						ch.TextAlign = HorizontalAlignment.Left;
						ch.Width = 150;
						break;

					default:
						ch.TextAlign = HorizontalAlignment.Left;
						ch.Width = 200;
						break;
				}
				ch.Text = dc.ColumnName;
				this.lvBom.Columns.Add(ch);
			}

			this.lvBom.EndUpdate();
		}

		#endregion

		public BOM()
		{
			InitializeComponent();
		}

		private void BOM_Load(object sender, EventArgs e)
		{
			this.CenterToScreen();
			this.getModelListFromBOM();
		}

		private void cbxModel_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				this.selecteBomModel = this.cbxModel.SelectedValue.ToString();
			}
			catch
			{
				this.selecteBomModel = "";
			}

			if (string.IsNullOrEmpty(this.selecteBomModel))
			{
				MessageBox.Show("No BOM matching as selected.....");
				return;
			}

			getTopNode(this.selecteBomModel);
		}

		private void tvBom_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			try
			{
				selectedItemId = int.Parse(e.Node.Tag.ToString());
				this.lbNodeId.Text = $"Node id = {selectedItemId}";

				ListViewItem im = lvBom.FindItemWithText(selectedItemId.ToString());
				im.Focused = true;
				im.Selected = true;
				im.EnsureVisible();
			}
			catch { }

			this.updateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			using (BOMItemInfo binfo = new BOMItemInfo(selectedItemId))
			{
				binfo.StartPosition = FormStartPosition.CenterScreen;
				binfo.ShowDialog(this);
			}
		}
	}
}
