using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDA3
{

    public partial class Form1 : Form
    {
        private readonly Dictionary<State, CheckBox> stateIndicatorMap;

        private readonly SymbolReader symbolReader = new SymbolReader();
        private CurrentStateManager currentStateManager = new CurrentStateManager();
        private readonly Timer timer;

        public Form1()
        {
            InitializeComponent();
            this.timer = new Timer { Interval = 500 };
            timer.Tick += (o, args) => this.ResolveStates();

            this.stateIndicatorMap = new Dictionary<State, CheckBox>()
            {
                {State.Q0, this.checkBox1},
                {State.Q1, this.checkBox2},
                {State.Q2, this.checkBox3},
                {State.Q3, this.checkBox4},
                {State.Q4, this.checkBox5},
                {State.Q5, this.checkBox6},
                {State.Q6, this.checkBox7},
                {State.Q7, this.checkBox8},
                {State.Q8, this.checkBox9},
                {State.Q9, this.checkBox10},
                {State.Q10, this.checkBox11},
                {State.Q11, this.checkBox12},
            };
            this.textBox1.Text = "";
        }

        private void ReadButtonClick(object sender, System.EventArgs e)
        {
            ResolveStates();
        }

        private void ResolveStates()
        {
            var symbol = this.symbolReader.ReadOne();

            if (symbol != null)
            {
                this.currentStateManager.ExecuteSymbol((int)symbol);
            }
            else
            {
                this.resetState();
                return;
                
            }
            UpdateStateIndicators(symbol);
        }

        private void UpdateStateIndicators(int? symbol)
        {
            this.label2.Text = symbol == null ? "null" : symbol.ToString();
            this.label1.Text = this.symbolReader.lineIndex.ToString();
            if (symbol != null)
                this.textBox1.Text += symbol;
            this.stateIndicatorMap.Values.ToList().ForEach(x => x.Checked = false);
            this.stateIndicatorMap.Where(
                    y => this.currentStateManager.CurrentStates.Select(x => x.State).Contains(y.Key))
                .Select(x => x.Value)
                .ToList()
                .ForEach(x => x.Checked = true);
        }


        private void ReadOneByOne(object sender, System.EventArgs e)
        {
            if ((sender as CheckBox)?.Checked == true)
                this.timer.Start();
            else
                this.timer.Stop();
        }

        private void ResetButtonClick(object sender, System.EventArgs e)
        {
            resetState();
            this.symbolReader.Reset();
        }

        private void resetState()
        {
            this.currentStateManager = new CurrentStateManager();
    
            this.label2.Text = "";
            this.textBox1.Text = "";
            this.label1.Text = "";
            this.UpdateStateIndicators(null);
        }
    }
}
