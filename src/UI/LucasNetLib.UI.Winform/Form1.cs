using System.ComponentModel;

namespace LucasNetLib.UI.Winform;

public partial class Form1 : Form
{
    public List<Students> Students = new List<Students>();
    public Form1()
    {
        InitializeComponent();
        Students.Add(new Students()
        {
            Name = "Name",
            Sex = "Man",
            Age = 1,
        });


        Students.Add(new Students()
        {
            Name = "Name1",
            Sex = "Man1",
            Age = 2,
        });

        this.dataGridView1.DataSource = Students;

        backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (!backgroundWorker1.IsBusy)
            backgroundWorker1.RunWorkerAsync();
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        int counter = 0;
        int max = 10;

        while (counter <= max)
        {
            backgroundWorker1.ReportProgress(0, counter.ToString());
            System.Threading.Thread.Sleep(1000);
            counter++;
        }
    }

    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) =>
        textBox1.Text = (string)e.UserState;

    private void clearableTextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}
