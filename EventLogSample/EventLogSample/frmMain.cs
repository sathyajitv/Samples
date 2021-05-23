
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace EventLogSample
{
    public partial class frmMain : Form
    {
        private const string SampleAppSource = "EventLogSampleSource";
        private readonly EventLog _appEventLog = new EventLog("Application");
        
        //------------------------------------------------------------------------------

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnWriteMessage_Click(object sender, EventArgs e)
        {
            WriteEventLog(txtMessage.Text);
        }

        private void btnWriteException_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                int j = 1 / i;
            }
            catch (Exception ex)
            {
                WriteEventLog(ex);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtMessage.Text = @"The current time is: " +  DateTime.Now.ToString("F");
            btnWriteMessage.Focus();

            CreateEventSource();
        }

        private void WriteEventLog(string message)
        {
            _appEventLog.WriteEntry(message, EventLogEntryType.Information);
        }

        private void WriteEventLog(Exception ex)
        {
            string message = "Message: ";
            message += Environment.NewLine;
            message += ex.Message;
            message += Environment.NewLine;
            message += "Stack Trace:" + Environment.NewLine;
            message += ex.StackTrace;

            _appEventLog.WriteEntry(message, EventLogEntryType.Warning);
        }

        private void CreateEventSource()
        {
            if (!EventLog.SourceExists(SampleAppSource))
            {
                EventLog.CreateEventSource(SampleAppSource, _appEventLog.LogDisplayName);
            }

            _appEventLog.Source = SampleAppSource;
        }
    }
}
