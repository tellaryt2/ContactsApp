namespace ContactsApp.View
{
    partial class AboutForm
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
            this.ContactsLabel = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.IconsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.InfoListBox = new System.Windows.Forms.ListBox();
            this.GitLinkLabel = new System.Windows.Forms.LinkLabel();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.GithubLabel = new System.Windows.Forms.Label();
            this.FixEmailLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.FooterPanel = new System.Windows.Forms.Panel();
            this.OKButton = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.FooterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContactsLabel
            // 
            this.ContactsLabel.AutoSize = true;
            this.ContactsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ContactsLabel.Location = new System.Drawing.Point(3, 6);
            this.ContactsLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.ContactsLabel.Name = "ContactsLabel";
            this.ContactsLabel.Size = new System.Drawing.Size(146, 25);
            this.ContactsLabel.TabIndex = 0;
            this.ContactsLabel.Text = "ContactsApp";
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.IconsLinkLabel);
            this.MainPanel.Controls.Add(this.label8);
            this.MainPanel.Controls.Add(this.InfoListBox);
            this.MainPanel.Controls.Add(this.GitLinkLabel);
            this.MainPanel.Controls.Add(this.EmailLabel);
            this.MainPanel.Controls.Add(this.NameLabel);
            this.MainPanel.Controls.Add(this.GithubLabel);
            this.MainPanel.Controls.Add(this.FixEmailLabel);
            this.MainPanel.Controls.Add(this.AuthorLabel);
            this.MainPanel.Controls.Add(this.VersionLabel);
            this.MainPanel.Controls.Add(this.ContactsLabel);
            this.MainPanel.Location = new System.Drawing.Point(12, 12);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(540, 417);
            this.MainPanel.TabIndex = 1;
            // 
            // IconsLinkLabel
            // 
            this.IconsLinkLabel.AutoSize = true;
            this.IconsLinkLabel.Location = new System.Drawing.Point(190, 355);
            this.IconsLinkLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.IconsLinkLabel.Name = "IconsLinkLabel";
            this.IconsLinkLabel.Size = new System.Drawing.Size(61, 13);
            this.IconsLinkLabel.TabIndex = 10;
            this.IconsLinkLabel.TabStop = true;
            this.IconsLinkLabel.Text = "icons8.com";
            this.IconsLinkLabel.Click += new System.EventHandler(this.IconsLinkLabel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 355);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "All used images are downloaded from";
            // 
            // InfoListBox
            // 
            this.InfoListBox.FormattingEnabled = true;
            this.InfoListBox.Items.AddRange(new object[] {
            "Copyright (c) 2023 Minnebaev Artem",
            "",
            "Permission is hereby granted, free of charge, to any person obtaining a copy of t" +
                "his software and ",
            "associated documentation files (the \"Software\"), to deal in the Software without " +
                "restriction, including ",
            "without limitation the rights to use, copy, modify, merge, publish, distribute, s" +
                "ublicense, and/or sell ",
            "copies of the Software, and to permit persons to whom the Software is furnished t" +
                "o do so, subject to the ",
            "following conditions:",
            "",
            "The above copyright notice and this permission notice shall be included in all co" +
                "pies or substantial ",
            "portions of the Software.",
            "",
            "THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR ",
            "IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, ",
            "FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL ",
            "THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR ",
            "OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ",
            "ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR ",
            "OTHER DEALINGS IN THE SOFTWARE. "});
            this.InfoListBox.Location = new System.Drawing.Point(8, 153);
            this.InfoListBox.Name = "InfoListBox";
            this.InfoListBox.Size = new System.Drawing.Size(529, 199);
            this.InfoListBox.TabIndex = 8;
            // 
            // GitLinkLabel
            // 
            this.GitLinkLabel.AutoSize = true;
            this.GitLinkLabel.Location = new System.Drawing.Point(117, 116);
            this.GitLinkLabel.Name = "GitLinkLabel";
            this.GitLinkLabel.Size = new System.Drawing.Size(136, 13);
            this.GitLinkLabel.TabIndex = 7;
            this.GitLinkLabel.TabStop = true;
            this.GitLinkLabel.Text = "https://github.com/tellaryt2";
            this.GitLinkLabel.Click += new System.EventHandler(this.GitLinkLabel_Click);
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(117, 93);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(143, 13);
            this.EmailLabel.TabIndex = 6;
            this.EmailLabel.Text = "minnebaevartem@gmail.com";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(117, 70);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(90, 13);
            this.NameLabel.TabIndex = 5;
            this.NameLabel.Text = "Minnebaev Artem";
            // 
            // GithubLabel
            // 
            this.GithubLabel.AutoSize = true;
            this.GithubLabel.Location = new System.Drawing.Point(5, 116);
            this.GithubLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.GithubLabel.Name = "GithubLabel";
            this.GithubLabel.Size = new System.Drawing.Size(41, 13);
            this.GithubLabel.TabIndex = 4;
            this.GithubLabel.Text = "Github:";
            // 
            // FixEmailLabel
            // 
            this.FixEmailLabel.AutoSize = true;
            this.FixEmailLabel.Location = new System.Drawing.Point(5, 93);
            this.FixEmailLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.FixEmailLabel.Name = "FixEmailLabel";
            this.FixEmailLabel.Size = new System.Drawing.Size(38, 13);
            this.FixEmailLabel.TabIndex = 3;
            this.FixEmailLabel.Text = "E-mail:";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(5, 70);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(41, 13);
            this.AuthorLabel.TabIndex = 2;
            this.AuthorLabel.Text = "Author:";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(5, 34);
            this.VersionLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(31, 13);
            this.VersionLabel.TabIndex = 1;
            this.VersionLabel.Text = "v 1.0";
            // 
            // FooterPanel
            // 
            this.FooterPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FooterPanel.Controls.Add(this.OKButton);
            this.FooterPanel.Location = new System.Drawing.Point(0, 393);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(563, 50);
            this.FooterPanel.TabIndex = 2;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(474, 13);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(564, 441);
            this.Controls.Add(this.FooterPanel);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.FooterPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ContactsLabel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.LinkLabel GitLinkLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label GithubLabel;
        private System.Windows.Forms.Label FixEmailLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.ListBox InfoListBox;
        private System.Windows.Forms.LinkLabel IconsLinkLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel FooterPanel;
        private System.Windows.Forms.Button OKButton;

       
    }
}