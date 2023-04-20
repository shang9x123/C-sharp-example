namespace WinFormsApp_Queue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Queue<Person> listdanhsach  = new Queue<Person>();
            listdanhsach.Enqueue(new Person { hoten = "hien" ,diachi="nam định"});
            listdanhsach.Enqueue(new Person { hoten = "tuyet" ,diachi="thanh hóa"});
            while(listdanhsach.Count > 0)
            {
                Person item = listdanhsach.Dequeue();
                System.Diagnostics.Debug.WriteLine(item.hoten);
                Thread.Sleep(5000);
            }
        }
    }
    class Person
    {
        public string hoten { get; set; }
        public string diachi { get; set; }

    }
}