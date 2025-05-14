using AmazonFbaFormUI.Services;

namespace AmazonFbaFormUI
{
    public partial class Form1 : Form
    {
        private readonly ProductService _productService;

        public Form1()
        {
            InitializeComponent();
            _productService = new ProductService();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Cursor = Cursors.WaitCursor;

            var urunler = await _productService.GetProductsAsync();
            dataGridView1.DataSource = urunler;

            button1.Enabled = true;
            Cursor = Cursors.Default;
        }
    }
}
