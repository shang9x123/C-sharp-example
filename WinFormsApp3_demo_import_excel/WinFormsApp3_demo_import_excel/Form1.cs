using OfficeOpenXml;

namespace WinFormsApp3_demo_import_excel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var package = new ExcelPackage(new FileInfo(openFileDialog.FileName));
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                for (int i = worksheet.Dimension.Start.Row; i <= worksheet.Dimension.End.Row; i++)
                {
                    try
                    {
                        int j = 1;
                        string hang1 = worksheet.Cells[i, j++].Value.ToString();
                        string hang2 = worksheet.Cells[i, j++].Value.ToString();
                        ListViewItem item = new ListViewItem() { Text= hang1};
                        item.SubItems.Add(hang2);
                        listView1.Items.Add(item);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}