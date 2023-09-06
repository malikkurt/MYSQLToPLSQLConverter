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

        private void button1_Click(object sender, EventArgs e)
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
                new ConverterTimes(),
                new ConverterAdvancedFunctions(),
                new ConverterSQLReferences(),
                new ConverterTableName()
            };

            for (int i = 0; i < handlers.Count - 1; i++)
            {
                handlers[i].setNextConverterHandler(handlers[i + 1]);
            }
            handlers[0].Convert(queryParser);

            StringBuilder convertedQueries = new StringBuilder();

            foreach (string s in queryParser.queryList)
            {
                
                string cleanQuery = s.Replace("\r\n", "");

                
                convertedQueries.AppendLine(cleanQuery);
            }

            return convertedQueries.ToString();
        }

        private void QueryInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}