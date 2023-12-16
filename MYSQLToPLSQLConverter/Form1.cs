using SqlConverter.Converter;
using SqlConverter;
using System.Text;
using System.Diagnostics.Metrics;

namespace MYSQLToPLSQLConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            string userInput = QueryInput.Text;

            string result = MYSQLToOracleConvert(userInput);


            QueryOuput.Text = result;
        }

        private string MYSQLToOracleConvert(string userInput)
        {
            QueryParser queryParser = new QueryParser(userInput);

            List<ConverterHandler> handlers = new List<ConverterHandler>
            {
                new ConverterDateFunctions(),
                new ConverterSmallDiff(),
                new ConverterQuestion(),
                new ConverterAdvancedFunctions(),
                new ConverterStringFunctions(),
                new ConverterTableName(),
                new ConverterTimes(),
                new ConverterNumericFunctions()
            };

            for (int i = 0; i < handlers.Count - 1; i++)
            {
                handlers[i].setNextConverterHandler(handlers[i + 1]);
            }
            handlers[0].Convert(queryParser);




            return queryParser.formattedQuery.ToString();
        }

        private void QueryInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}