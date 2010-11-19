namespace TcApplication
{
	partial class FormRecipe
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node1");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node2");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecipe));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.timerListbox = new System.Windows.Forms.Timer(this.components);
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.labelOrder = new System.Windows.Forms.Label();
			this.textBoxAuftrag = new System.Windows.Forms.TextBox();
			this.textBoxKunde = new System.Windows.Forms.TextBox();
			this.treeView2 = new System.Windows.Forms.TreeView();
			this.button1 = new System.Windows.Forms.Button();
			this.tcRecipeValueLabel10 = new Beckhoff.App.TcRecipeValueLabel();
			this.tcRecipeValueLabel9 = new Beckhoff.App.TcRecipeValueLabel();
			this.tcRecipeValueLabel8 = new Beckhoff.App.TcRecipeValueLabel();
			this.tcRecipeValueLabel7 = new Beckhoff.App.TcRecipeValueLabel();
			this.tcRecipeValueLabel6 = new Beckhoff.App.TcRecipeValueLabel();
			this.tcRecipeValueLabel5 = new Beckhoff.App.TcRecipeValueLabel();
			this.tcRecipeValueLabel4 = new Beckhoff.App.TcRecipeValueLabel();
			this.tcRecipeValueLabel3 = new Beckhoff.App.TcRecipeValueLabel();
			this.tcRecipeValueLabel2 = new Beckhoff.App.TcRecipeValueLabel();
			this.tcRecipeValueLabel1 = new Beckhoff.App.TcRecipeValueLabel();
			this.tcRecipeStringLabel2 = new Beckhoff.App.TcRecipeStringLabel();
			this.tcRecipeStringLabel1 = new Beckhoff.App.TcRecipeStringLabel();
			this.tcRecipe1 = new Beckhoff.App.TcRecipeGrid();
			this.tcRecipeStringLabel3 = new Beckhoff.App.TcRecipeStringLabel();
			this.tcRecipeStringLabel4 = new Beckhoff.App.TcRecipeStringLabel();
			this.labelRecipe = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// timerListbox
			// 
			this.timerListbox.Interval = 250;
			this.timerListbox.Tick += new System.EventHandler(this.timerListbox_Tick);
			// 
			// treeView1
			// 
			this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.treeView1.HideSelection = false;
			this.treeView1.ImageIndex = 2;
			this.treeView1.ImageList = this.imageList1;
			this.treeView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.treeView1.Location = new System.Drawing.Point(9, 38);
			this.treeView1.Name = "treeView1";
			treeNode1.Name = "Node1";
			treeNode1.Text = "Node1";
			treeNode2.Name = "Node2";
			treeNode2.Text = "Node2";
			treeNode3.Name = "Node0";
			treeNode3.Text = "Node0";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
			this.treeView1.SelectedImageIndex = 1;
			this.treeView1.ShowPlusMinus = false;
			this.treeView1.ShowRootLines = false;
			this.treeView1.Size = new System.Drawing.Size(171, 117);
			this.treeView1.TabIndex = 40;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "Folder211.ico");
			this.imageList1.Images.SetKeyName(1, "Folder079.ico");
			this.imageList1.Images.SetKeyName(2, "Folder082.ico");
			// 
			// labelOrder
			// 
			this.labelOrder.AutoSize = true;
			this.labelOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelOrder.Location = new System.Drawing.Point(200, 36);
			this.labelOrder.Name = "labelOrder";
			this.labelOrder.Size = new System.Drawing.Size(74, 20);
			this.labelOrder.TabIndex = 41;
			this.labelOrder.Text = "Auftrag:";
			// 
			// textBoxAuftrag
			// 
			this.textBoxAuftrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.textBoxAuftrag.Location = new System.Drawing.Point(557, 36);
			this.textBoxAuftrag.Name = "textBoxAuftrag";
			this.textBoxAuftrag.ReadOnly = true;
			this.textBoxAuftrag.Size = new System.Drawing.Size(323, 26);
			this.textBoxAuftrag.TabIndex = 42;
			// 
			// textBoxKunde
			// 
			this.textBoxKunde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.textBoxKunde.Location = new System.Drawing.Point(330, 36);
			this.textBoxKunde.Name = "textBoxKunde";
			this.textBoxKunde.ReadOnly = true;
			this.textBoxKunde.Size = new System.Drawing.Size(217, 26);
			this.textBoxKunde.TabIndex = 43;
			// 
			// treeView2
			// 
			this.treeView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)));
			this.treeView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.treeView2.HideSelection = false;
			this.treeView2.ImageIndex = 0;
			this.treeView2.ImageList = this.imageList1;
			this.treeView2.Location = new System.Drawing.Point(9, 161);
			this.treeView2.Name = "treeView2";
			this.treeView2.SelectedImageIndex = 0;
			this.treeView2.ShowLines = false;
			this.treeView2.ShowPlusMinus = false;
			this.treeView2.ShowRootLines = false;
			this.treeView2.Size = new System.Drawing.Size(171, 308);
			this.treeView2.TabIndex = 45;
			this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(120, 38);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(60, 21);
			this.button1.TabIndex = 66;
			this.button1.Text = "Config";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tcRecipeValueLabel10
			// 
			this.tcRecipeValueLabel10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tcRecipeValueLabel10.ConfigMode = false;
			this.tcRecipeValueLabel10.Cursor = System.Windows.Forms.Cursors.Default;
			this.tcRecipeValueLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.tcRecipeValueLabel10.Index = ((uint)(10u));
			this.tcRecipeValueLabel10.LabelText = "Label:";
			this.tcRecipeValueLabel10.Location = new System.Drawing.Point(557, 218);
			this.tcRecipeValueLabel10.Margin = new System.Windows.Forms.Padding(50, 1, 1, 1);
			this.tcRecipeValueLabel10.Name = "tcRecipeValueLabel10";
			this.tcRecipeValueLabel10.Settings = null;
			this.tcRecipeValueLabel10.Size = new System.Drawing.Size(192, 23);
			this.tcRecipeValueLabel10.TabIndex = 65;
			this.tcRecipeValueLabel10.Tooltip = null;
			this.tcRecipeValueLabel10.TooltipText = "";
			this.tcRecipeValueLabel10.Value = 0;
			// 
			// tcRecipeValueLabel9
			// 
			this.tcRecipeValueLabel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tcRecipeValueLabel9.ConfigMode = false;
			this.tcRecipeValueLabel9.Cursor = System.Windows.Forms.Cursors.Default;
			this.tcRecipeValueLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.tcRecipeValueLabel9.Index = ((uint)(9u));
			this.tcRecipeValueLabel9.LabelText = "Label:";
			this.tcRecipeValueLabel9.Location = new System.Drawing.Point(557, 196);
			this.tcRecipeValueLabel9.Margin = new System.Windows.Forms.Padding(50, 1, 1, 1);
			this.tcRecipeValueLabel9.Name = "tcRecipeValueLabel9";
			this.tcRecipeValueLabel9.Settings = null;
			this.tcRecipeValueLabel9.Size = new System.Drawing.Size(192, 20);
			this.tcRecipeValueLabel9.TabIndex = 64;
			this.tcRecipeValueLabel9.Tooltip = null;
			this.tcRecipeValueLabel9.TooltipText = "";
			this.tcRecipeValueLabel9.Value = 0;
			// 
			// tcRecipeValueLabel8
			// 
			this.tcRecipeValueLabel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tcRecipeValueLabel8.ConfigMode = false;
			this.tcRecipeValueLabel8.Cursor = System.Windows.Forms.Cursors.Default;
			this.tcRecipeValueLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.tcRecipeValueLabel8.Index = ((uint)(8u));
			this.tcRecipeValueLabel8.LabelText = "Label:";
			this.tcRecipeValueLabel8.Location = new System.Drawing.Point(557, 174);
			this.tcRecipeValueLabel8.Margin = new System.Windows.Forms.Padding(50, 1, 1, 1);
			this.tcRecipeValueLabel8.Name = "tcRecipeValueLabel8";
			this.tcRecipeValueLabel8.Settings = null;
			this.tcRecipeValueLabel8.Size = new System.Drawing.Size(192, 20);
			this.tcRecipeValueLabel8.TabIndex = 63;
			this.tcRecipeValueLabel8.Tooltip = null;
			this.tcRecipeValueLabel8.TooltipText = "";
			this.tcRecipeValueLabel8.Value = 0;
			// 
			// tcRecipeValueLabel7
			// 
			this.tcRecipeValueLabel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tcRecipeValueLabel7.ConfigMode = false;
			this.tcRecipeValueLabel7.Cursor = System.Windows.Forms.Cursors.Default;
			this.tcRecipeValueLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.tcRecipeValueLabel7.Index = ((uint)(7u));
			this.tcRecipeValueLabel7.LabelText = "Label:";
			this.tcRecipeValueLabel7.Location = new System.Drawing.Point(557, 152);
			this.tcRecipeValueLabel7.Margin = new System.Windows.Forms.Padding(5, 1, 1, 1);
			this.tcRecipeValueLabel7.Name = "tcRecipeValueLabel7";
			this.tcRecipeValueLabel7.Settings = null;
			this.tcRecipeValueLabel7.Size = new System.Drawing.Size(192, 20);
			this.tcRecipeValueLabel7.TabIndex = 62;
			this.tcRecipeValueLabel7.Tooltip = null;
			this.tcRecipeValueLabel7.TooltipText = "";
			this.tcRecipeValueLabel7.Value = 0;
			// 
			// tcRecipeValueLabel6
			// 
			this.tcRecipeValueLabel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tcRecipeValueLabel6.ConfigMode = false;
			this.tcRecipeValueLabel6.Cursor = System.Windows.Forms.Cursors.Default;
			this.tcRecipeValueLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.tcRecipeValueLabel6.Index = ((uint)(6u));
			this.tcRecipeValueLabel6.LabelText = "Label:";
			this.tcRecipeValueLabel6.Location = new System.Drawing.Point(557, 130);
			this.tcRecipeValueLabel6.Margin = new System.Windows.Forms.Padding(5, 1, 1, 1);
			this.tcRecipeValueLabel6.Name = "tcRecipeValueLabel6";
			this.tcRecipeValueLabel6.Settings = null;
			this.tcRecipeValueLabel6.Size = new System.Drawing.Size(192, 20);
			this.tcRecipeValueLabel6.TabIndex = 61;
			this.tcRecipeValueLabel6.Tooltip = null;
			this.tcRecipeValueLabel6.TooltipText = "";
			this.tcRecipeValueLabel6.Value = 0;
			// 
			// tcRecipeValueLabel5
			// 
			this.tcRecipeValueLabel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tcRecipeValueLabel5.ConfigMode = false;
			this.tcRecipeValueLabel5.Cursor = System.Windows.Forms.Cursors.Default;
			this.tcRecipeValueLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.tcRecipeValueLabel5.Index = ((uint)(5u));
			this.tcRecipeValueLabel5.LabelText = "Label:";
			this.tcRecipeValueLabel5.Location = new System.Drawing.Point(204, 218);
			this.tcRecipeValueLabel5.Margin = new System.Windows.Forms.Padding(5, 1, 1, 1);
			this.tcRecipeValueLabel5.Name = "tcRecipeValueLabel5";
			this.tcRecipeValueLabel5.Settings = null;
			this.tcRecipeValueLabel5.Size = new System.Drawing.Size(192, 23);
			this.tcRecipeValueLabel5.TabIndex = 60;
			this.tcRecipeValueLabel5.Tooltip = null;
			this.tcRecipeValueLabel5.TooltipText = "";
			this.tcRecipeValueLabel5.Value = 0;
			// 
			// tcRecipeValueLabel4
			// 
			this.tcRecipeValueLabel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tcRecipeValueLabel4.ConfigMode = false;
			this.tcRecipeValueLabel4.Cursor = System.Windows.Forms.Cursors.Default;
			this.tcRecipeValueLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.tcRecipeValueLabel4.Index = ((uint)(4u));
			this.tcRecipeValueLabel4.LabelText = "Label:";
			this.tcRecipeValueLabel4.Location = new System.Drawing.Point(204, 196);
			this.tcRecipeValueLabel4.Margin = new System.Windows.Forms.Padding(5, 1, 1, 1);
			this.tcRecipeValueLabel4.Name = "tcRecipeValueLabel4";
			this.tcRecipeValueLabel4.Settings = null;
			this.tcRecipeValueLabel4.Size = new System.Drawing.Size(192, 20);
			this.tcRecipeValueLabel4.TabIndex = 59;
			this.tcRecipeValueLabel4.Tooltip = null;
			this.tcRecipeValueLabel4.TooltipText = "";
			this.tcRecipeValueLabel4.Value = 0;
			// 
			// tcRecipeValueLabel3
			// 
			this.tcRecipeValueLabel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tcRecipeValueLabel3.ConfigMode = false;
			this.tcRecipeValueLabel3.Cursor = System.Windows.Forms.Cursors.Default;
			this.tcRecipeValueLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.tcRecipeValueLabel3.Index = ((uint)(3u));
			this.tcRecipeValueLabel3.LabelText = "Label:";
			this.tcRecipeValueLabel3.Location = new System.Drawing.Point(204, 174);
			this.tcRecipeValueLabel3.Margin = new System.Windows.Forms.Padding(5, 1, 1, 1);
			this.tcRecipeValueLabel3.Name = "tcRecipeValueLabel3";
			this.tcRecipeValueLabel3.Settings = null;
			this.tcRecipeValueLabel3.Size = new System.Drawing.Size(192, 20);
			this.tcRecipeValueLabel3.TabIndex = 58;
			this.tcRecipeValueLabel3.Tooltip = null;
			this.tcRecipeValueLabel3.TooltipText = "";
			this.tcRecipeValueLabel3.Value = 0;
			// 
			// tcRecipeValueLabel2
			// 
			this.tcRecipeValueLabel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tcRecipeValueLabel2.ConfigMode = false;
			this.tcRecipeValueLabel2.Cursor = System.Windows.Forms.Cursors.Default;
			this.tcRecipeValueLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.tcRecipeValueLabel2.Index = ((uint)(2u));
			this.tcRecipeValueLabel2.LabelText = "Label:";
			this.tcRecipeValueLabel2.Location = new System.Drawing.Point(204, 152);
			this.tcRecipeValueLabel2.Margin = new System.Windows.Forms.Padding(5, 1, 1, 1);
			this.tcRecipeValueLabel2.Name = "tcRecipeValueLabel2";
			this.tcRecipeValueLabel2.Settings = null;
			this.tcRecipeValueLabel2.Size = new System.Drawing.Size(192, 20);
			this.tcRecipeValueLabel2.TabIndex = 57;
			this.tcRecipeValueLabel2.Tooltip = null;
			this.tcRecipeValueLabel2.TooltipText = "";
			this.tcRecipeValueLabel2.Value = 0;
			// 
			// tcRecipeValueLabel1
			// 
			this.tcRecipeValueLabel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tcRecipeValueLabel1.ConfigMode = false;
			this.tcRecipeValueLabel1.Cursor = System.Windows.Forms.Cursors.Default;
			this.tcRecipeValueLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.tcRecipeValueLabel1.Index = ((uint)(0u));
			this.tcRecipeValueLabel1.LabelText = "Label:";
			this.tcRecipeValueLabel1.Location = new System.Drawing.Point(204, 130);
			this.tcRecipeValueLabel1.Margin = new System.Windows.Forms.Padding(5, 1, 1, 1);
			this.tcRecipeValueLabel1.Name = "tcRecipeValueLabel1";
			this.tcRecipeValueLabel1.Settings = null;
			this.tcRecipeValueLabel1.Size = new System.Drawing.Size(192, 20);
			this.tcRecipeValueLabel1.TabIndex = 56;
			this.tcRecipeValueLabel1.Tooltip = null;
			this.tcRecipeValueLabel1.TooltipText = "";
			this.tcRecipeValueLabel1.Value = 0;
			// 
			// tcRecipeStringLabel2
			// 
			this.tcRecipeStringLabel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tcRecipeStringLabel2.ConfigMode = false;
			this.tcRecipeStringLabel2.Cursor = System.Windows.Forms.Cursors.Default;
			this.tcRecipeStringLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.tcRecipeStringLabel2.Index = ((uint)(2u));
			this.tcRecipeStringLabel2.LabelText = "Label:";
			this.tcRecipeStringLabel2.Location = new System.Drawing.Point(204, 92);
			this.tcRecipeStringLabel2.Margin = new System.Windows.Forms.Padding(1);
			this.tcRecipeStringLabel2.Name = "tcRecipeStringLabel2";
			this.tcRecipeStringLabel2.Settings = null;
			this.tcRecipeStringLabel2.Size = new System.Drawing.Size(343, 22);
			this.tcRecipeStringLabel2.TabIndex = 47;
			this.tcRecipeStringLabel2.Tooltip = null;
			this.tcRecipeStringLabel2.TooltipText = "";
			this.tcRecipeStringLabel2.Value = null;
			// 
			// tcRecipeStringLabel1
			// 
			this.tcRecipeStringLabel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tcRecipeStringLabel1.ConfigMode = false;
			this.tcRecipeStringLabel1.Cursor = System.Windows.Forms.Cursors.Default;
			this.tcRecipeStringLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.tcRecipeStringLabel1.Index = ((uint)(1u));
			this.tcRecipeStringLabel1.LabelText = "Label:";
			this.tcRecipeStringLabel1.Location = new System.Drawing.Point(204, 68);
			this.tcRecipeStringLabel1.Margin = new System.Windows.Forms.Padding(1);
			this.tcRecipeStringLabel1.Name = "tcRecipeStringLabel1";
			this.tcRecipeStringLabel1.Settings = null;
			this.tcRecipeStringLabel1.Size = new System.Drawing.Size(343, 22);
			this.tcRecipeStringLabel1.TabIndex = 46;
			this.tcRecipeStringLabel1.Tooltip = null;
			this.tcRecipeStringLabel1.TooltipText = "";
			this.tcRecipeStringLabel1.Value = null;
			// 
			// tcRecipe1
			// 
			this.tcRecipe1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.tcRecipe1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tcRecipe1.CellStyle = dataGridViewCellStyle1;
			this.tcRecipe1.ConfigFileName = "";
			this.tcRecipe1.ConfigMode = false;
			this.tcRecipe1.FileName = "";
			this.tcRecipe1.headerStringLabel01 = this.tcRecipeStringLabel1;
			this.tcRecipe1.headerStringLabel02 = this.tcRecipeStringLabel2;
			this.tcRecipe1.headerStringLabel03 = this.tcRecipeStringLabel3;
			this.tcRecipe1.headerStringLabel04 = this.tcRecipeStringLabel4;
			this.tcRecipe1.headerStringLabel05 = null;
			this.tcRecipe1.headerStringLabel06 = null;
			this.tcRecipe1.headerStringLabel07 = null;
			this.tcRecipe1.headerStringLabel08 = null;
			this.tcRecipe1.headerStringLabel09 = null;
			this.tcRecipe1.headerStringLabel10 = null;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.tcRecipe1.HeaderStyle = dataGridViewCellStyle2;
			this.tcRecipe1.headerValueLabel01 = this.tcRecipeValueLabel1;
			this.tcRecipe1.headerValueLabel02 = this.tcRecipeValueLabel2;
			this.tcRecipe1.headerValueLabel03 = this.tcRecipeValueLabel3;
			this.tcRecipe1.headerValueLabel04 = this.tcRecipeValueLabel4;
			this.tcRecipe1.headerValueLabel05 = this.tcRecipeValueLabel5;
			this.tcRecipe1.headerValueLabel06 = this.tcRecipeValueLabel6;
			this.tcRecipe1.headerValueLabel07 = this.tcRecipeValueLabel7;
			this.tcRecipe1.headerValueLabel08 = this.tcRecipeValueLabel8;
			this.tcRecipe1.headerValueLabel09 = this.tcRecipeValueLabel9;
			this.tcRecipe1.headerValueLabel10 = this.tcRecipeValueLabel10;
			this.tcRecipe1.headerValueLabel11 = null;
			this.tcRecipe1.headerValueLabel12 = null;
			this.tcRecipe1.headerValueLabel13 = null;
			this.tcRecipe1.headerValueLabel14 = null;
			this.tcRecipe1.headerValueLabel15 = null;
			this.tcRecipe1.headerValueLabel16 = null;
			this.tcRecipe1.headerValueLabel17 = null;
			this.tcRecipe1.headerValueLabel18 = null;
			this.tcRecipe1.headerValueLabel19 = null;
			this.tcRecipe1.headerValueLabel20 = null;
			this.tcRecipe1.headerValueLabel21 = null;
			this.tcRecipe1.headerValueLabel22 = null;
			this.tcRecipe1.headerValueLabel23 = null;
			this.tcRecipe1.headerValueLabel24 = null;
			this.tcRecipe1.headerValueLabel25 = null;
			this.tcRecipe1.headerValueLabel26 = null;
			this.tcRecipe1.headerValueLabel27 = null;
			this.tcRecipe1.headerValueLabel28 = null;
			this.tcRecipe1.headerValueLabel29 = null;
			this.tcRecipe1.headerValueLabel30 = null;
			this.tcRecipe1.LanguageManager = null;
			this.tcRecipe1.Location = new System.Drawing.Point(204, 245);
			this.tcRecipe1.Name = "tcRecipe1";
			this.tcRecipe1.PlcVar = ".RecipeData";
			this.tcRecipe1.Size = new System.Drawing.Size(683, 224);
			this.tcRecipe1.TabIndex = 2;
			this.tcRecipe1.TclmText = "Recipe.";
			// 
			// tcRecipeStringLabel3
			// 
			this.tcRecipeStringLabel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tcRecipeStringLabel3.ConfigMode = false;
			this.tcRecipeStringLabel3.Cursor = System.Windows.Forms.Cursors.Default;
			this.tcRecipeStringLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.tcRecipeStringLabel3.Index = ((uint)(0u));
			this.tcRecipeStringLabel3.LabelText = "Label:";
			this.tcRecipeStringLabel3.Location = new System.Drawing.Point(557, 68);
			this.tcRecipeStringLabel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tcRecipeStringLabel3.Name = "tcRecipeStringLabel3";
			this.tcRecipeStringLabel3.Settings = null;
			this.tcRecipeStringLabel3.Size = new System.Drawing.Size(323, 22);
			this.tcRecipeStringLabel3.TabIndex = 67;
			this.tcRecipeStringLabel3.Tooltip = null;
			this.tcRecipeStringLabel3.TooltipText = "";
			this.tcRecipeStringLabel3.Value = null;
			// 
			// tcRecipeStringLabel4
			// 
			this.tcRecipeStringLabel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tcRecipeStringLabel4.ConfigMode = false;
			this.tcRecipeStringLabel4.Cursor = System.Windows.Forms.Cursors.Default;
			this.tcRecipeStringLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.tcRecipeStringLabel4.Index = ((uint)(0u));
			this.tcRecipeStringLabel4.LabelText = "Label:";
			this.tcRecipeStringLabel4.Location = new System.Drawing.Point(557, 92);
			this.tcRecipeStringLabel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tcRecipeStringLabel4.Name = "tcRecipeStringLabel4";
			this.tcRecipeStringLabel4.Settings = null;
			this.tcRecipeStringLabel4.Size = new System.Drawing.Size(323, 22);
			this.tcRecipeStringLabel4.TabIndex = 68;
			this.tcRecipeStringLabel4.Tooltip = null;
			this.tcRecipeStringLabel4.TooltipText = "";
			this.tcRecipeStringLabel4.Value = null;
			// 
			// labelRecipe
			// 
			this.labelRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.labelRecipe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
			this.labelRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelRecipe.ForeColor = System.Drawing.Color.White;
			this.labelRecipe.Location = new System.Drawing.Point(0, 0);
			this.labelRecipe.Name = "labelRecipe";
			this.labelRecipe.Size = new System.Drawing.Size(900, 32);
			this.labelRecipe.TabIndex = 69;
			this.labelRecipe.Text = "Recipe";
			this.labelRecipe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormRecipe
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(896, 472);
			this.Controls.Add(this.labelRecipe);
			this.Controls.Add(this.tcRecipeStringLabel4);
			this.Controls.Add(this.tcRecipeStringLabel3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tcRecipeValueLabel10);
			this.Controls.Add(this.tcRecipeValueLabel9);
			this.Controls.Add(this.tcRecipeValueLabel8);
			this.Controls.Add(this.tcRecipeValueLabel7);
			this.Controls.Add(this.tcRecipeValueLabel6);
			this.Controls.Add(this.tcRecipeValueLabel5);
			this.Controls.Add(this.tcRecipeValueLabel4);
			this.Controls.Add(this.tcRecipeValueLabel3);
			this.Controls.Add(this.tcRecipeValueLabel2);
			this.Controls.Add(this.tcRecipeValueLabel1);
			this.Controls.Add(this.tcRecipeStringLabel2);
			this.Controls.Add(this.tcRecipeStringLabel1);
			this.Controls.Add(this.treeView2);
			this.Controls.Add(this.textBoxKunde);
			this.Controls.Add(this.textBoxAuftrag);
			this.Controls.Add(this.labelOrder);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.tcRecipe1);
			this.Name = "FormRecipe";
			this.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.Text = "FormRecipe";
			this.Deactivate += new System.EventHandler(this.FormRecipe_Deactivate);
			this.Load += new System.EventHandler(this.FormRecipe_Load);
			this.Activated += new System.EventHandler(this.FormRecipe_Activated);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Beckhoff.App.TcRecipeGrid tcRecipe1;
		private System.Windows.Forms.Timer timerListbox;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Label labelOrder;
		private System.Windows.Forms.TextBox textBoxAuftrag;
		private System.Windows.Forms.TextBox textBoxKunde;
		private System.Windows.Forms.TreeView treeView2;
		private Beckhoff.App.TcRecipeStringLabel tcRecipeStringLabel1;
		private Beckhoff.App.TcRecipeStringLabel tcRecipeStringLabel2;
		private Beckhoff.App.TcRecipeValueLabel tcRecipeValueLabel1;
		private Beckhoff.App.TcRecipeValueLabel tcRecipeValueLabel2;
		private Beckhoff.App.TcRecipeValueLabel tcRecipeValueLabel3;
		private Beckhoff.App.TcRecipeValueLabel tcRecipeValueLabel4;
		private Beckhoff.App.TcRecipeValueLabel tcRecipeValueLabel5;
		private Beckhoff.App.TcRecipeValueLabel tcRecipeValueLabel6;
		private Beckhoff.App.TcRecipeValueLabel tcRecipeValueLabel7;
		private Beckhoff.App.TcRecipeValueLabel tcRecipeValueLabel8;
		private Beckhoff.App.TcRecipeValueLabel tcRecipeValueLabel9;
		private Beckhoff.App.TcRecipeValueLabel tcRecipeValueLabel10;
		private System.Windows.Forms.Button button1;
		private Beckhoff.App.TcRecipeStringLabel tcRecipeStringLabel3;
		private Beckhoff.App.TcRecipeStringLabel tcRecipeStringLabel4;
		private System.Windows.Forms.Label labelRecipe;
		private System.Windows.Forms.ImageList imageList1;

	}
}