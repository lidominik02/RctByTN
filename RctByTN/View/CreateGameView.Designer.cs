
namespace RctByTN.View
{
    partial class CreateGameView
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
            this.acceptedButton = new System.Windows.Forms.Button();
            this.notAcceptedButton = new System.Windows.Forms.Button();
            this.userInputTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ticketPriceLabel = new System.Windows.Forms.Label();
            this.minCapacityLabel = new System.Windows.Forms.Label();
            this.ticketPriceTextBox = new System.Windows.Forms.TextBox();
            this.minCapacityTextBox = new System.Windows.Forms.TextBox();
            this.userInputTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // acceptedButton
            // 
            this.acceptedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.acceptedButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptedButton.Location = new System.Drawing.Point(18, 201);
            this.acceptedButton.Margin = new System.Windows.Forms.Padding(4);
            this.acceptedButton.Name = "acceptedButton";
            this.acceptedButton.Size = new System.Drawing.Size(218, 52);
            this.acceptedButton.TabIndex = 0;
            this.acceptedButton.Text = "Építés";
            this.acceptedButton.UseVisualStyleBackColor = true;
            this.acceptedButton.Click += new System.EventHandler(this.acceptedButton_Click);
            // 
            // notAcceptedButton
            // 
            this.notAcceptedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.notAcceptedButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.notAcceptedButton.Location = new System.Drawing.Point(370, 201);
            this.notAcceptedButton.Margin = new System.Windows.Forms.Padding(4);
            this.notAcceptedButton.Name = "notAcceptedButton";
            this.notAcceptedButton.Size = new System.Drawing.Size(218, 52);
            this.notAcceptedButton.TabIndex = 0;
            this.notAcceptedButton.Text = "Mégsem";
            this.notAcceptedButton.UseVisualStyleBackColor = true;
            this.notAcceptedButton.Click += new System.EventHandler(this.notAcceptedButton_Click);
            // 
            // userInputTableLayout
            // 
            this.userInputTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userInputTableLayout.ColumnCount = 2;
            this.userInputTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.userInputTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.userInputTableLayout.Controls.Add(this.ticketPriceLabel, 0, 0);
            this.userInputTableLayout.Controls.Add(this.minCapacityLabel, 0, 1);
            this.userInputTableLayout.Controls.Add(this.ticketPriceTextBox, 1, 0);
            this.userInputTableLayout.Controls.Add(this.minCapacityTextBox, 1, 1);
            this.userInputTableLayout.Location = new System.Drawing.Point(18, 18);
            this.userInputTableLayout.Margin = new System.Windows.Forms.Padding(4);
            this.userInputTableLayout.Name = "userInputTableLayout";
            this.userInputTableLayout.RowCount = 2;
            this.userInputTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.userInputTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.userInputTableLayout.Size = new System.Drawing.Size(570, 150);
            this.userInputTableLayout.TabIndex = 1;
            // 
            // ticketPriceLabel
            // 
            this.ticketPriceLabel.AutoSize = true;
            this.ticketPriceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ticketPriceLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ticketPriceLabel.Location = new System.Drawing.Point(4, 0);
            this.ticketPriceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ticketPriceLabel.Name = "ticketPriceLabel";
            this.ticketPriceLabel.Size = new System.Drawing.Size(277, 75);
            this.ticketPriceLabel.TabIndex = 0;
            this.ticketPriceLabel.Text = "Jegyár:";
            this.ticketPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // minCapacityLabel
            // 
            this.minCapacityLabel.AutoSize = true;
            this.minCapacityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minCapacityLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minCapacityLabel.Location = new System.Drawing.Point(4, 75);
            this.minCapacityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.minCapacityLabel.Name = "minCapacityLabel";
            this.minCapacityLabel.Size = new System.Drawing.Size(277, 75);
            this.minCapacityLabel.TabIndex = 1;
            this.minCapacityLabel.Text = "Minimum kapcitás:";
            this.minCapacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ticketPriceTextBox
            // 
            this.ticketPriceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ticketPriceTextBox.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ticketPriceTextBox.Location = new System.Drawing.Point(289, 4);
            this.ticketPriceTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ticketPriceTextBox.Name = "ticketPriceTextBox";
            this.ticketPriceTextBox.Size = new System.Drawing.Size(277, 47);
            this.ticketPriceTextBox.TabIndex = 2;
            // 
            // minCapacityTextBox
            // 
            this.minCapacityTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minCapacityTextBox.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minCapacityTextBox.Location = new System.Drawing.Point(289, 79);
            this.minCapacityTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.minCapacityTextBox.Name = "minCapacityTextBox";
            this.minCapacityTextBox.Size = new System.Drawing.Size(277, 47);
            this.minCapacityTextBox.TabIndex = 3;
            // 
            // CreateGameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(606, 272);
            this.Controls.Add(this.userInputTableLayout);
            this.Controls.Add(this.notAcceptedButton);
            this.Controls.Add(this.acceptedButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "CreateGameView";
            this.Text = "Játék építése";
            this.userInputTableLayout.ResumeLayout(false);
            this.userInputTableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button acceptedButton;
        private System.Windows.Forms.Button notAcceptedButton;
        private System.Windows.Forms.TableLayoutPanel userInputTableLayout;
        private System.Windows.Forms.Label ticketPriceLabel;
        private System.Windows.Forms.Label minCapacityLabel;
        private System.Windows.Forms.TextBox ticketPriceTextBox;
        private System.Windows.Forms.TextBox minCapacityTextBox;
    }
}