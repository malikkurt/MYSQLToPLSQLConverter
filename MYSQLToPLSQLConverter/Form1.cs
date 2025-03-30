using SqlConverter.Domain.Interfaces;
using SqlConverter.Domain.Models;
using Serilog;

namespace MYSQLToPLSQLConverter
{
    public partial class Form1 : Form
    {
        private readonly IConverterHandler _converterHandler;
        private readonly ILogger _logger;

        public Form1(IConverterHandler converterHandler, ILogger logger)
        {
            InitializeComponent();
            _converterHandler = converterHandler;
            _logger = logger;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void ConverterButton_Click(object sender, EventArgs e)
        {
            try
            {
                string userInput = QueryInput.Text;
                _logger.Information("Starting conversion for query: {Query}", userInput);

                var queryParser = new QueryParser(userInput);
                _converterHandler.Convert(queryParser);

                QueryOuput.Text = queryParser.FormattedQuery;
                _logger.Information("Conversion completed successfully");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error during conversion");
                MessageBox.Show($"An error occurred during conversion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QueryInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}