using System;
using System.Data;
using System.Windows.Forms;

namespace CRUDElasticsearch
{
    public partial class Form1 : Form
    {
        string documentID = "";
        string id = "";
        string name = "";
        string originalVoiceActor = "";
        string animatedDebut = "";

        string[] arrCharacter = new string[4];
        ListViewItem itm;

        public Form1()
        {
            InitializeComponent();
        }

        #region Search Button

        private void btnSearch_Click(object sender, EventArgs e)
        {
            documentID = tbxID.Text;
            var disneyCharacter = CRUD.getDocument(documentID);

            tbxID.Text = disneyCharacter.Item1;
            tbxName.Text = disneyCharacter.Item2;
            tbxVoiceActor.Text = disneyCharacter.Item3;
            tbxDebut.Text = disneyCharacter.Item4;
        }

        #endregion Search Button

        #region Get All Button

        private void btnGetAllData_Click(object sender, EventArgs e)
        {
            //Clear ListView before loading new data
            lvwDisneyCharacter.Items.Clear();

            DataTable dataTable = CRUD.getAllDocument();
            DataRow[] rulesRow = dataTable.Select();

            foreach (DataRow row in rulesRow)
            {
                id = row[0].ToString();
                name = row[1].ToString();
                originalVoiceActor = row[2].ToString();
                animatedDebut = row[3].ToString();

                //Add item to listview
                arrCharacter[0] = id;
                arrCharacter[1] = name;
                arrCharacter[2] = originalVoiceActor;
                arrCharacter[3] = animatedDebut;

                itm = new ListViewItem(arrCharacter);
                lvwDisneyCharacter.Items.Add(itm);
            }
        }
           


        #endregion Get All Button

        #region Insert Button

        private void btnIndex_Click(object sender, EventArgs e)
        {
            bool status;

            id = tbxID.Text;
            name = tbxName.Text;
            originalVoiceActor = tbxVoiceActor.Text;
            animatedDebut = tbxDebut.Text;

            status = CRUD.insertDocument(id, name, originalVoiceActor, animatedDebut);

            if (status == true)
            {
                MessageBox.Show("Document Inserted/ Indexed Successfully");
            }
            else
            {
                MessageBox.Show("Error! Occured During Document Insert/ Index!");
            }
        }

        #endregion Insert Button

        #region Update Button

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool status;

            id = tbxID.Text;
            name = tbxName.Text;
            originalVoiceActor = tbxVoiceActor.Text;
            animatedDebut = tbxDebut.Text;

            status = CRUD.updateDocument(id, name, originalVoiceActor, animatedDebut);

            if(status==true)
            {
                MessageBox.Show("Document Updated Successfully");
            }
            else
            {
                MessageBox.Show("Error! Occured During Document Update!");
            }
        }

        #endregion Update Button

        #region Delete Button

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool status;
            documentID = tbxID.Text;

            status = CRUD.deleteDocument(documentID);

            if (status == true)
            {
                MessageBox.Show("Document Deleted Successfully");
            }
            else
            {
                MessageBox.Show("Error Occured During Document Delete!");
            }
        }

        #endregion Delete Button

        #region Reset all Flag

        private void tbxID_TextChanged(object sender, EventArgs e)
        {
            //Clear all Text when search for new ID
            tbxName.Text = "";
            tbxVoiceActor.Text = "";
            tbxDebut.Text = "";
            
        }

        #endregion Reset all Flag       
    }
}
