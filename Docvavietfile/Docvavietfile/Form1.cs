using System.Text;

namespace Docvavietfile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                string[] lines = File.ReadAllLines(ofd.FileName);
                foreach (string line in lines)
                {
                    System.Diagnostics.Debug.WriteLine(line);
                    string[] array_line = line.Split('|');
                    ListViewItem item = new ListViewItem() { Text = array_line[0] };
                    item.SubItems.Add(array_line[1]);
                    item.SubItems.Add(array_line[2]);
                    listView1.Items.Add(item);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Filter = "Text file(*.txt)|txt";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // tìm đường dẫn và lưu lại
                StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName,false,Encoding.UTF8);
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    ListViewItem item = listView1.Items[i]; 
                    string line_insert = item.SubItems[0].Text +"|"+ item.SubItems[1].Text;
                    streamWriter.WriteLine(line_insert);
                } 
                streamWriter.Close();
                MessageBox.Show("Ghi thanh cong");
                
            }

        }
    }
}