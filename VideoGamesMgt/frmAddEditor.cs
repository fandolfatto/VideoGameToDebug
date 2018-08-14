using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoGamesMgt
{
    /// <summary>
    /// manages the form that enables to add or create an editor
    /// </summary>
    public partial class frmAddEditor : Form
    {

        private ConnectionBD connection;
        public List<Editor> listEditor;

        /// <summary>
        /// constructor
        /// </summary>
        public frmAddEditor()
        {
            InitializeComponent();
        }

        public void SetConnection(ConnectionBD conn)
        {
            connection = conn;
        }

        /// <summary>
        /// load the editors that already exists in the DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEditor_Load(object sender, EventArgs e)
        {
            try { 
                List<Editor> listEditor = connection.GetEditor();
                foreach (Editor editor in listEditor)
                {
                    lstEditor.Items.Add(editor);
                }
            } catch (VgSQLException vgex)
            {
                MessageBox.Show(vgex.Message);
            }
}
        /// <summary>
        /// cancel the call of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        /// <summary>
        /// add the editors selected or created on the calling form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (lstEditor.SelectedItems.Count == 0 && txtEditor.Text == "")
            {
                MessageBox.Show("Vous devez sélectionner un éditeur déjà existant ou en ajouter un");
            } else
            {
                listEditor = new List<Editor>();
                foreach (Editor editor in lstEditor.SelectedItems)
                {
                    //editor in the list
                    listEditor.Add(editor);
                }
                if (txtEditor.Text != "")
                {
                    //new editor to add in the list
                    
                }
                DialogResult = DialogResult.OK;
            }
            

        }
    }
}
